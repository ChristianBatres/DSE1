namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionTablaCuentaBancaria : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.cuentaBancaria", "id_tipoCuenta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.cuentaBancaria", "id_tipoCuenta", c => c.Int());
        }
    }
}
