namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaCuentaBancaria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cuentaBancaria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_cliente = c.Int(),
                        Moneda = c.String(nullable: false, maxLength: 20),
                        id_tipoCuenta = c.Int(),
                        clientes_id = c.Int(),
                        tipoCuentaBancarias_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cliente", t => t.clientes_id)
                .ForeignKey("dbo.tipoCuentaBancaria", t => t.tipoCuentaBancarias_id)
                .Index(t => t.clientes_id)
                .Index(t => t.tipoCuentaBancarias_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cuentaBancaria", "tipoCuentaBancarias_id", "dbo.tipoCuentaBancaria");
            DropForeignKey("dbo.cuentaBancaria", "clientes_id", "dbo.cliente");
            DropIndex("dbo.cuentaBancaria", new[] { "tipoCuentaBancarias_id" });
            DropIndex("dbo.cuentaBancaria", new[] { "clientes_id" });
            DropTable("dbo.cuentaBancaria");
        }
    }
}
