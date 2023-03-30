namespace LojaDeReparações.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dispositivos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dispositivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUtilizador = c.Int(nullable: false),
                        Marca = c.String(nullable: false),
                        Problema = c.String(nullable: false),
                        Tipo = c.String(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.IdUtilizador, cascadeDelete: true)
                .Index(t => t.IdUtilizador);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dispositivoes", "IdUtilizador", "dbo.Utilizadors");
            DropIndex("dbo.Dispositivoes", new[] { "IdUtilizador" });
            DropTable("dbo.Dispositivoes");
        }
    }
}
