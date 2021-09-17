namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuentabac : DbMigration
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
            
            CreateTable(
                "dbo.cuentaBancaria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cliente_Id = c.Int(nullable: false),
                        Moneda = c.String(nullable: false, maxLength: 20),
                        tipo_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cliente", t => t.cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.tipoCuentaBancaria", t => t.tipo_id, cascadeDelete: true)
                .Index(t => t.cliente_Id)
                .Index(t => t.tipo_id);
            
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
            DropForeignKey("dbo.cuentaBancaria", "tipo_id", "dbo.tipoCuentaBancaria");
            DropForeignKey("dbo.cuentaBancaria", "cliente_Id", "dbo.cliente");
            DropIndex("dbo.cuentaBancaria", new[] { "tipo_id" });
            DropIndex("dbo.cuentaBancaria", new[] { "cliente_Id" });
            DropTable("dbo.tipoCuentaBancaria");
            DropTable("dbo.cuentaBancaria");
            DropTable("dbo.cliente");
        }
    }
}
