namespace banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoTransaccion : DbMigration
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
            
            AddColumn("dbo.transaccion", "tipoTransaccion_id", c => c.Int(nullable: false));
            CreateIndex("dbo.transaccion", "tipoTransaccion_id");
            AddForeignKey("dbo.transaccion", "tipoTransaccion_id", "dbo.tipoTransaccion", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.transaccion", "tipoTransaccion_id", "dbo.tipoTransaccion");
            DropIndex("dbo.transaccion", new[] { "tipoTransaccion_id" });
            DropColumn("dbo.transaccion", "tipoTransaccion_id");
            DropTable("dbo.tipoTransaccion");
        }
    }
}
