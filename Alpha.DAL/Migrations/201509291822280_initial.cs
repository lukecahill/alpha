namespace Alpha.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Location = c.String(maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publishers");
        }
    }
}
