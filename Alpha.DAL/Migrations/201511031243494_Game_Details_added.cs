namespace Alpha.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Game_Details_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "PictureLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "PictureLink");
        }
    }
}
