namespace Alpha.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readd_ids : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accessories", "Game_GameId", "dbo.Games");
            DropForeignKey("dbo.Addons", "Game_GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "Publisher_PublisherId", "dbo.Publishers");
            DropIndex("dbo.Accessories", new[] { "Game_GameId" });
            DropIndex("dbo.Games", new[] { "Publisher_PublisherId" });
            DropIndex("dbo.Addons", new[] { "Game_GameId" });
            RenameColumn(table: "dbo.Accessories", name: "Game_GameId", newName: "GameId");
            RenameColumn(table: "dbo.Addons", name: "Game_GameId", newName: "GameId");
            RenameColumn(table: "dbo.Games", name: "Publisher_PublisherId", newName: "PublisherId");
            AlterColumn("dbo.Accessories", "GameId", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "PublisherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addons", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accessories", "GameId");
            CreateIndex("dbo.Games", "PublisherId");
            CreateIndex("dbo.Addons", "GameId");
            AddForeignKey("dbo.Accessories", "GameId", "dbo.Games", "GameId", cascadeDelete: true);
            AddForeignKey("dbo.Addons", "GameId", "dbo.Games", "GameId", cascadeDelete: true);
            AddForeignKey("dbo.Games", "PublisherId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Addons", "GameId", "dbo.Games");
            DropForeignKey("dbo.Accessories", "GameId", "dbo.Games");
            DropIndex("dbo.Addons", new[] { "GameId" });
            DropIndex("dbo.Games", new[] { "PublisherId" });
            DropIndex("dbo.Accessories", new[] { "GameId" });
            AlterColumn("dbo.Addons", "GameId", c => c.Int());
            AlterColumn("dbo.Games", "PublisherId", c => c.Int());
            AlterColumn("dbo.Accessories", "GameId", c => c.Int());
            RenameColumn(table: "dbo.Games", name: "PublisherId", newName: "Publisher_PublisherId");
            RenameColumn(table: "dbo.Addons", name: "GameId", newName: "Game_GameId");
            RenameColumn(table: "dbo.Accessories", name: "GameId", newName: "Game_GameId");
            CreateIndex("dbo.Addons", "Game_GameId");
            CreateIndex("dbo.Games", "Publisher_PublisherId");
            CreateIndex("dbo.Accessories", "Game_GameId");
            AddForeignKey("dbo.Games", "Publisher_PublisherId", "dbo.Publishers", "PublisherId");
            AddForeignKey("dbo.Addons", "Game_GameId", "dbo.Games", "GameId");
            AddForeignKey("dbo.Accessories", "Game_GameId", "dbo.Games", "GameId");
        }
    }
}
