using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DAL;
using BLL;


namespace Personas 
{
    public partial class Site : System.Web.UI.MasterPage
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxPersonaId.Text) || string.IsNullOrWhiteSpace(TextBoxNombre.Text) || string.IsNullOrWhiteSpace(DropDownListSexo.Text))
                Response.Write("hay uno o dos campos vacios");

            else

            {
                Persona persona = new Persona();
                PersonasTelefonos personastelefonos = new PersonasTelefonos();
                    
                persona.PersonaId = Convert.ToInt32(TextBoxPersonaId.Text.Trim());
                persona.Nombre = TextBoxNombre.Text.Trim();
                persona.Sexo = DropDownListSexo.Text.Trim();
               // personastelefonos.TipoTelefono = DropDownListTipoTelefono.Text.Trim();
                personastelefonos.Telefono = TextBoxTelefono.Text.Trim();
            
                if (persona.PersonaId > 0)
                {

                    persona.Insertar();
                    Response.Write("se guardo correctamente");
                    TextBoxPersonaId.Text = string.Empty;
                    TextBoxNombre.Text = string.Empty;
                    TextBoxTelefono.Text = string.Empty;

                }
                else if (persona.PersonaId < 0)
                {
                    Response.Write("no se guardo correctamente");
                }

            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBoxPersonaId.Text = string.Empty;
            TextBoxNombre.Text = string.Empty;
            TextBoxTelefono.Text = string.Empty;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {


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
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscarGridView_Click(object sender, EventArgs e)
        {
      

        }

    }
}

