using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Persona : ClaseMaestra
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

        public override bool Insertar()
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
                    conexion.Ejecutar(string.Format("Insert into PersonaTelefono(PersonaId,TipoTelefono,Telefono) Values ({0},{1},'{2}')", retorno, (int)item.TipoTelefono, item.Telefono));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();

            try
            {
                retorno = conexion.Ejecutar(string.Format("Update Persona set Nombre = '{0}' where PersonaId=" + this.Nombre, this.PersonaId));
                if (retorno)
                {
                    foreach (PersonasTelefonos numero in this.Telefonos)
                    {
                        retorno = conexion.Ejecutar("Delete from PersonaTelefono Where PersonaId=" + this.PersonaId.ToString());
                    }

                }
            } catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
      

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            try
            {
                retorno = conexion.Ejecutar(string.Format("delete from Persona where PersonaId =" + this.PersonaId));

                if (retorno)
                    conexion.Ejecutar("Delete from PersonaTelefono where PersonaId=" + this.PersonaId.ToString());
            }    
            catch(Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            ConexionDb conexion = new ConexionDb();

            try
            {

                dt = conexion.ObtenerDatos(String.Format("Select *from Persona Where PersonaId =" + IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.PersonaId = (int)dt.Rows[0]["PersonaId"];
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Sexo = dt.Rows[0]["Sexo"].ToString();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            ConexionDb conexion = new ConexionDb();

            if (!Orden.Equals(""))
                ordenFinal = " Orden by " + Orden;
            return conexion.ObtenerDatos("Select " + Campos + " From Persona Where " + Condicion + " " + ordenFinal);
        }
    }
}