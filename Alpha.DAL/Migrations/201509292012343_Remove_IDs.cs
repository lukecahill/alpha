namespace Alpha.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_IDs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accessories", "GameId", "dbo.Games");
            DropForeignKey("dbo.Addons", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Accessories", new[] { "GameId" });
            DropIndex("dbo.Games", new[] { "PublisherId" });
            DropIndex("dbo.Addons", new[] { "GameId" });
            RenameColumn(table: "dbo.Accessories", name: "GameId", newName: "Game_GameId");
            RenameColumn(table: "dbo.Addons", name: "GameId", newName: "Game_GameId");
            RenameColumn(table: "dbo.Games", name: "PublisherId", newName: "Publisher_PublisherId");
            AlterColumn("dbo.Accessories", "Game_GameId", c => c.Int());
            AlterColumn("dbo.Games", "Publisher_PublisherId", c => c.Int());
            AlterColumn("dbo.Addons", "Game_GameId", c => c.Int());
            CreateIndex("dbo.Accessories", "Game_GameId");
            CreateIndex("dbo.Games", "Publisher_PublisherId");
            CreateIndex("dbo.Addons", "Game_GameId");
            AddForeignKey("dbo.Accessories", "Game_GameId", "dbo.Games", "GameId");
            AddForeignKey("dbo.Addons", "Game_GameId", "dbo.Games", "GameId");
            AddForeignKey("dbo.Games", "Publisher_PublisherId", "dbo.Publishers", "PublisherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Publisher_PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Addons", "Game_GameId", "dbo.Games");
            DropForeignKey("dbo.Accessories", "Game_GameId", "dbo.Games");
            DropIndex("dbo.Addons", new[] { "Game_GameId" });
            DropIndex("dbo.Games", new[] { "Publisher_PublisherId" });
            DropIndex("dbo.Accessories", new[] { "Game_GameId" });
            AlterColumn("dbo.Addons", "Game_GameId", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "Publisher_PublisherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Accessories", "Game_GameId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Games", name: "Publisher_PublisherId", newName: "PublisherId");
            RenameColumn(table: "dbo.Addons", name: "Game_GameId", newName: "GameId");
            RenameColumn(table: "dbo.Accessories", name: "Game_GameId", newName: "GameId");
            CreateIndex("dbo.Addons", "GameId");
            CreateIndex("dbo.Games", "PublisherId");
            CreateIndex("dbo.Accessories", "GameId");
            AddForeignKey("dbo.Games", "PublisherId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
            AddForeignKey("dbo.Addons", "GameId", "dbo.Games", "GameId", cascadeDelete: true);
            AddForeignKey("dbo.Accessories", "GameId", "dbo.Games", "GameId", cascadeDelete: true);
        }
    }
}
