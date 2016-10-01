using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace Personas.Consultas
{
    public partial class ConsultaPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            DataTable dt = new DataTable();
            string filtro = "1=1";

            if (DropDownListBucarPor.SelectedIndex == 0) //ID
            {
                if (TextBoxBuscarPor.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {
                    filtro = "PersonaId = " + TextBoxBuscarPor.Text;
                }
            }
            else if (DropDownListBucarPor.SelectedIndex == 1) //Nombre
                if (TextBoxBuscarPor.Text.Trim().Length == 0)
                {
                    filtro = "1=1";
                }
                else
                {

                    filtro = "Nombre like '%" + TextBoxBuscarPor.Text + "%'";
                }
           

            dt = persona.Listado("PersonaId, Nombre", filtro, "UsuarioId ASC");
            GridViewPersona.DataSource = dt;
            GridViewPersona.DataBind();
        }
    }
}