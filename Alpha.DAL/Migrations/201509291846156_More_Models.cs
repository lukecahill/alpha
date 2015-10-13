namespace Alpha.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class More_Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Type = c.String(maxLength: 255),
                        GameId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.AccessoryId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ReleaseDate = c.DateTime(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Addons",
                c => new
                    {
                        AddonId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ReleaseDate = c.DateTime(),
                        GameId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.AddonId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Addons", "GameId", "dbo.Games");
            DropForeignKey("dbo.Accessories", "GameId", "dbo.Games");
            DropIndex("dbo.Addons", new[] { "GameId" });
            DropIndex("dbo.Games", new[] { "PublisherId" });
            DropIndex("dbo.Accessories", new[] { "GameId" });
            DropTable("dbo.Addons");
            DropTable("dbo.Games");
            DropTable("dbo.Accessories");
        }
    }
}
