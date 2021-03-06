namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 200),
                        primerApellido = c.String(nullable: false, maxLength: 200),
                        segundoApellido = c.String(maxLength: 200),
                        telefono = c.String(nullable: false, maxLength: 20),
                        email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cliente");
        }
    }
}
