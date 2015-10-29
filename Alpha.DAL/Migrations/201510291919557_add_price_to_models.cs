namespace Alpha.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_price_to_models : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accessories", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Games", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Addons", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addons", "Price");
            DropColumn("dbo.Games", "Price");
            DropColumn("dbo.Accessories", "Price");
        }
    }
}
