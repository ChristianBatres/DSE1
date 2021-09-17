namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionTablaCuentaBancaria2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tipoCuentaBancaria", "cuentaBancaria_id", "dbo.cuentaBancaria");
            DropIndex("dbo.tipoCuentaBancaria", new[] { "cuentaBancaria_id" });
            AddColumn("dbo.cuentaBancaria", "cliente_id", c => c.Int());
            AddColumn("dbo.cuentaBancaria", "tipo_id", c => c.Int());
            AddColumn("dbo.cuentaBancaria", "tipos_id", c => c.Int());
            CreateIndex("dbo.cuentaBancaria", "tipos_id");
            AddForeignKey("dbo.cuentaBancaria", "tipos_id", "dbo.tipoCuentaBancaria", "id");
            DropColumn("dbo.cuentaBancaria", "id_cliente");
            DropColumn("dbo.tipoCuentaBancaria", "cuentaBancaria_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tipoCuentaBancaria", "cuentaBancaria_id", c => c.Int());
            AddColumn("dbo.cuentaBancaria", "id_cliente", c => c.Int());
            DropForeignKey("dbo.cuentaBancaria", "tipos_id", "dbo.tipoCuentaBancaria");
            DropIndex("dbo.cuentaBancaria", new[] { "tipos_id" });
            DropColumn("dbo.cuentaBancaria", "tipos_id");
            DropColumn("dbo.cuentaBancaria", "tipo_id");
            DropColumn("dbo.cuentaBancaria", "cliente_id");
            CreateIndex("dbo.tipoCuentaBancaria", "cuentaBancaria_id");
            AddForeignKey("dbo.tipoCuentaBancaria", "cuentaBancaria_id", "dbo.cuentaBancaria", "id");
        }
    }
}
