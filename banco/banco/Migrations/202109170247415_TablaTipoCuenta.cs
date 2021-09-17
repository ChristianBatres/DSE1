namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaTipoCuenta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tipoCuentaBancaria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tipo = c.String(nullable: false, maxLength: 200),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tipoCuentaBancaria");
        }
    }
}
