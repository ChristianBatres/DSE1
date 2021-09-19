namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.transaccion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cuentaBancaria_id = c.Int(nullable: false),
                        monto = c.Decimal(nullable: false, storeType: "money"),
                        Estado = c.String(nullable: false, maxLength: 200),
                        fechaTransaccion = c.DateTime(nullable: false),
                        fechaAplicacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cuentaBancaria", t => t.cuentaBancaria_id, cascadeDelete: true)
                .Index(t => t.cuentaBancaria_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.transaccion", "cuentaBancaria_id", "dbo.cuentaBancaria");
            DropIndex("dbo.transaccion", new[] { "cuentaBancaria_id" });
            DropTable("dbo.transaccion");
        }
    }
}
