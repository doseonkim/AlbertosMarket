namespace AlbertosMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        MarketID = c.Int(nullable: false),
                        Author = c.String(),
                        Content = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Market", t => t.MarketID, cascadeDelete: true)
                .Index(t => t.MarketID);
            
            CreateTable(
                "dbo.Market",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Option = c.Int(),
                        Price = c.Int(nullable: false),
                        Title = c.String(),
                        Post = c.String(),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "MarketID", "dbo.Market");
            DropIndex("dbo.Comment", new[] { "MarketID" });
            DropTable("dbo.Market");
            DropTable("dbo.Comment");
        }
    }
}
