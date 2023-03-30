namespace LojaDeReparações.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reparacoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reparacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDispositivo = c.Int(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        IdFuncionario = c.Int(nullable: false),
                        data_inicio = c.DateTime(nullable: false),
                        data_fim = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dispositivoes", t => t.IdDispositivo, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadors", t => t.IdFuncionario, cascadeDelete: false)
                .ForeignKey("dbo.Utilizadors", t => t.IdCliente, cascadeDelete: false)
                .Index(t => t.IdDispositivo)
                .Index(t => t.IdCliente)
                .Index(t => t.IdFuncionario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reparacaos", "IdCliente", "dbo.Utilizadors");
            DropForeignKey("dbo.Reparacaos", "IdFuncionario", "dbo.Utilizadors");
            DropForeignKey("dbo.Reparacaos", "IdDispositivo", "dbo.Dispositivoes");
            DropIndex("dbo.Reparacaos", new[] { "IdFuncionario" });
            DropIndex("dbo.Reparacaos", new[] { "IdCliente" });
            DropIndex("dbo.Reparacaos", new[] { "IdDispositivo" });
            DropTable("dbo.Reparacaos");
        }
    }
}
