namespace Alpha.DAL.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class inheritance_addons_and_accessories : DbMigration {
        public override void Up() {
            DropPrimaryKey("dbo.Accessories");
            DropPrimaryKey("dbo.Addons");
            DropColumn("dbo.Accessories", "AccessoryId");
            DropColumn("dbo.Addons", "AddonId");
            DropColumn("dbo.Addons", "Title");
            AddColumn("dbo.Accessories", "ExtraId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Addons", "ExtraId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Addons", "Name", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Accessories", "ExtraId");
            AddPrimaryKey("dbo.Addons", "ExtraId");
        }

        public override void Down() {
            DropPrimaryKey("dbo.Addons");
            DropPrimaryKey("dbo.Accessories");
            DropColumn("dbo.Addons", "Name");
            DropColumn("dbo.Addons", "ExtraId");
            DropColumn("dbo.Accessories", "ExtraId");
            AddColumn("dbo.Addons", "Title", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Addons", "AddonId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Accessories", "AccessoryId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Addons", "AddonId");
            AddPrimaryKey("dbo.Accessories", "AccessoryId");
        }
    }
}
