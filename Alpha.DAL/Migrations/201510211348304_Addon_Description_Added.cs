namespace Alpha.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addon_Description_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accessories", "Description", c => c.String());
            AddColumn("dbo.Addons", "Description", c => c.String());
            AlterColumn("dbo.Addons", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addons", "ReleaseDate", c => c.DateTime());
            DropColumn("dbo.Addons", "Description");
            DropColumn("dbo.Accessories", "Description");
        }
    }
}
