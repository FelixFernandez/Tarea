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
        public int personaId { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }


        public Persona()
        {
            this.personaId = 0;
            this.nombre = "";
            this.sexo = "";
        }

        public bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Insert Into Persona(PersonaId,Nombre,Sexo) Values('" + this.personaId + "','" + this.nombre + "','" + this.sexo + "') Select @@Identity");
            return retorno;

        }

        public bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Update Persona set Nombre = '" + this.nombre + "' where PersonaId = " + this.personaId);
            return retorno;
        }

        public bool Eliminar()
        {
            bool retorna = false;
            ConexionDb conexion = new ConexionDb();
            retorna = conexion.Ejecutar("delete from Persona where PersonaId =" + this.personaId);
            return retorna;

        }

        public bool Buscar(int IdBuscado)
       {
           DataTable dt = new DataTable();
           ConexionDb conexion = new ConexionDb();

           dt = conexion.ObtenerDatos(String.Format("Select *from Persona Where PersonaId = {0}", IdBuscado));
           if (dt.Rows.Count > 0)
           {
               this.personaId = (int)dt.Rows[0]["PersonaId"];
               this.nombre = dt.Rows[0]["Nombre"].ToString();
                this.sexo = dt.Rows[0]["Sexo"].ToString();
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
    }
}