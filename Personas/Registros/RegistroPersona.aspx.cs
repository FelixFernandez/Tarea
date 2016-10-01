using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Personas.Registros
{
    public partial class RegistroPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownListTipoTelefono.DataSource = Enum.GetValues(typeof(TiposTelefonos));
                DropDownListTipoTelefono.DataBind();
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxPersonaId.Text) || string.IsNullOrWhiteSpace(TextBoxNombre.Text) || string.IsNullOrWhiteSpace(DropDownListSexo.Text))
                Response.Write("hay uno o dos campos vacios");

            else

            {
                Persona persona;
                if (Session["Persona"] == null)
                    Session["Persona"] = new Persona();

                persona = (Persona)Session["Persona"];

                persona.Nombre = TextBoxNombre.Text.Trim();

                persona.Sexo = DropDownListSexo.Text;

                if (persona.Insertar())
                {
                    TextBoxPersonaId.Text = persona.PersonaId.ToString();
                    DropDownListSexo.Text = persona.Sexo.ToString();


                }


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
                Persona persona = new Persona();
                persona.PersonaId = Convert.ToInt32(TextBoxPersonaId.Text);

                if (persona.Eliminar())
                {
                    Response.Write("se elimino correctamente");
                    TextBoxPersonaId.Text = string.Empty;
                    TextBoxNombre.Text = string.Empty;
                    TextBoxTelefono.Text = string.Empty;
               }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Persona persona;
            if (Session["Persona"] == null)
                Session["Persona"] = new Persona();

            persona = (Persona)Session["Persona"];

            TiposTelefonos tipo;

            tipo = (TiposTelefonos)Enum.Parse(typeof(TiposTelefonos), DropDownListTipoTelefono.SelectedValue);

            persona.AgregarTelefono(tipo, TextBoxTelefono.Text);

            Session["Persona"] = persona;

            GridView1.DataSource = persona.Telefonos;
            GridView1.DataBind();

            TextBoxTelefono.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBoxPersonaId.Text = string.Empty;
            TextBoxNombre.Text = string.Empty;
            TextBoxTelefono.Text = string.Empty;
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}