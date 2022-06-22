namespace Plenum_API_Rest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.unidad_aprendizaje", "foto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.unidad_aprendizaje", "foto");
        }
    }
}
