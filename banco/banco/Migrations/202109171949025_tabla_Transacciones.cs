namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabla_Transacciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.transacciones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cuentaBancaria_id = c.Int(),
                        tipoTransaccion_id = c.Int(),
                        monto = c.Decimal(nullable: false, storeType: "money"),
                        Estado = c.String(nullable: false, maxLength: 200),
                        fechaTransaccion = c.DateTime(nullable: false),
                        fechaAplicacion = c.DateTime(nullable: false),
                        cuentas_id = c.Int(),
                        tipos_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cuentaBancaria", t => t.cuentas_id)
                .ForeignKey("dbo.tipoTransaccion", t => t.tipos_id)
                .Index(t => t.cuentas_id)
                .Index(t => t.tipos_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.transacciones", "tipos_id", "dbo.tipoTransaccion");
            DropForeignKey("dbo.transacciones", "cuentas_id", "dbo.cuentaBancaria");
            DropIndex("dbo.transacciones", new[] { "tipos_id" });
            DropIndex("dbo.transacciones", new[] { "cuentas_id" });
            DropTable("dbo.transacciones");
        }
    }
}
