using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }

        public List<PersonasTelefonos> Telefonos { get; set; }


        public Persona()
        {
            this.PersonaId = 0;
            this.Nombre = "";
            this.Sexo = "";
            Telefonos = new List<PersonasTelefonos>();
        }

        public void AgregarTelefono(TiposTelefonos tipo, string telefono)
        {
            Telefonos.Add(new PersonasTelefonos(tipo, telefono));
        }

        public bool Insertar()
        {
            int retorno = 0;
            ConexionDb conexion = new ConexionDb();
            object identity;
            try
            {
                identity = conexion.ObtenerValor("Insert Into Persona(PersonaId,Nombre,Sexo) Values('" + this.PersonaId + "','" + this.Nombre + "','" + this.Sexo + "') Select @@Identity");
                int.TryParse(identity.ToString(), out retorno);
                this.PersonaId = retorno;
                foreach (PersonasTelefonos item in this.Telefonos)
                {
                    conexion.Ejecutar(string.Format("Insert into PersonasTelefonos(PersonasTelefonos(PersonaId,Telefono) Values ({0},{1},'{2}')", retorno, (int)item.TipoTelefono, item.Telefono));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno > 0;
        }
           // retorno = conexion.Ejecutar("Insert Into Persona(PersonaId,Nombre,Sexo) Values('" + this.PersonaId + "','" + this.Nombre + "','" + this.Sexo + "') Select @@Identity");
           // return retorno;

        public bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Update Persona set Nombre = '" + this.Nombre + "' where PersonaId = " + this.PersonaId);
            return retorno;
        }

        public bool Eliminar()
        {
            bool retorna = false;
            ConexionDb conexion = new ConexionDb();
            retorna = conexion.Ejecutar("delete from Persona where PersonaId =" + this.PersonaId);
            return retorna;

        }

        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();

            dt = conexion.ObtenerDatos(String.Format("Select *from Persona Where PersonaId = {0}", IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.PersonaId = (int)dt.Rows[0]["PersonaId"];
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
                this.Sexo = dt.Rows[0]["Sexo"].ToString();
            }
            return dt.Rows.Count > 0;
        }

        public DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            ConexionDb conexion = new ConexionDb();

            if (!Orden.Equals(""))
                ordenFinal = " Orden by " + Orden;
            return conexion.ObtenerDatos("Select " + Campos + " From Persona Where " + Condicion + " " + ordenFinal);
        }

        public DataTable Listar(string campos = "*", string Filtro = "1=1")
        {

            ConexionDb conexion = new ConexionDb();
            return conexion.ObtenerDatos("Select " + campos + " from Compras where " + Filtro);
        }
    }
}