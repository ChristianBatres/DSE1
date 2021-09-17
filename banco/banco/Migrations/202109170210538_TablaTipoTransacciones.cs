namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaTipoTransacciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tipoTransaccion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tipo = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tipoTransaccion");
        }
    }
}
