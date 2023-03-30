using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LojaDeReparações.Data
{
    public class LojaDeReparacoesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LojaDeReparacoesContext() : base("name=LojaDeReparacoesContext")
        {
        }

        public System.Data.Entity.DbSet<LojaDeReparações.Models.Utilizador> Utilizadors { get; set; }

        public System.Data.Entity.DbSet<LojaDeReparações.Models.Dispositivo> Dispositivoes { get; set; }

        public System.Data.Entity.DbSet<LojaDeReparações.Models.Reparacao> Reparacaos { get; set; }
    }
}
