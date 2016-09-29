using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class PersonasTelefonos
    {
       
        
        public string Telefono { get; set; }
        public TiposTelefonos TipoTelefono { get; set; }

       

        public string Tipo
        {
            get { return this.TipoTelefono.ToString(); }
        }

        public PersonasTelefonos()
        {
            this.TipoTelefono = TiposTelefonos.Casa;
            this.Telefono="";
        }
      

        public PersonasTelefonos(TiposTelefonos tipo,string telefono)
        {
            this.TipoTelefono = tipo;
            this.Telefono = telefono;
        }


        /* probando algo

      
        public PersonasTelefonos()
        {
            this.personasTelefonosId = 0;
            this.tipoTelefono = "";
            this.Telefono = "";
        }


        public bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Insert Into PersonaTelefono(PersonaTelefonId,PersonaId,TipoTelefono,Telefono) Values('" + this.personasTelefonosId + "','" + this.personaId + "','" + this.tipoTelefono + "','" + this.Telefono+ ") Select @@Identity");
            return retorno;

        }

        public bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Update PersonaTelefono set PersonaId = '" + this.personaId + "' where PersonaTelefonoId = " + this.personasTelefonosId);
            return retorno;
        }

        public bool Eliminar()
        {
            bool retorna = false;
            ConexionDb conexion = new ConexionDb();
            retorna = conexion.Ejecutar("delete from PersonaTelefono where PersonaTelefonoId =" + this.personasTelefonosId);
            return retorna;

        }

        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();

            dt = conexion.ObtenerDatos(String.Format("Select *from PersonaTelefono Where PersonaTelefonoId = {0}", IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.personasTelefonosId = (int)dt.Rows[0]["PersonaTelefonoId"];
                this.personaId = (int)dt.Rows[0]["PersonaId"];
                this.tipoTelefono = dt.Rows[0]["TipoTelefono"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
            }
            return dt.Rows.Count > 0;
        }

        public DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            ConexionDb conexion = new ConexionDb();

            if (!Orden.Equals(""))
                ordenFinal = " Orden by " + Orden;
            return conexion.ObtenerDatos("Select " + Campos + " From PersonaTelefono Where " + Condicion + " " + ordenFinal);
        }*/
    }
}