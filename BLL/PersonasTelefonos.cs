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

     //probando algo
        public PersonasTelefonos()
        {
            this.TipoTelefono = TiposTelefonos.Casa;
            this.TipoTelefono = TiposTelefonos.Celular;
            this.TipoTelefono = TiposTelefonos.Trabajo;
            this.Telefono = "";
        }

        public PersonasTelefonos(TiposTelefonos tipo, string telefono)
        {
            this.TipoTelefono = tipo;
            this.Telefono = telefono;
        }
    }
}