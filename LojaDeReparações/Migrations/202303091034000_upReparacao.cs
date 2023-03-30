namespace LojaDeReparações.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upReparacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reparacaos", "preco", c => c.Double(nullable: false));
            DropColumn("dbo.Reparacaos", "Comentario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reparacaos", "Comentario", c => c.String());
            DropColumn("dbo.Reparacaos", "preco");
        }
    }
}
