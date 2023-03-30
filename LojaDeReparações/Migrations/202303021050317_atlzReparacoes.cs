namespace LojaDeReparações.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atlzReparacoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reparacaos", "Comentario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reparacaos", "Comentario");
        }
    }
}
