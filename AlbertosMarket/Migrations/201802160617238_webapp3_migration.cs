namespace AlbertosMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webapp3_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        JoinDate = c.DateTime(nullable: false),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        AuthorID = c.String(maxLength: 128),
                        MarketID = c.Int(nullable: false),
                        Content = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Author", t => t.AuthorID)
                .ForeignKey("dbo.Market", t => t.MarketID)
                .Index(t => t.AuthorID)
                .Index(t => t.MarketID);
            
            CreateTable(
                "dbo.Market",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuthorID = c.String(maxLength: 128),
                        PostDate = c.DateTime(nullable: false),
                        Option = c.Int(),
                        Price = c.Int(nullable: false),
                        Title = c.String(),
                        Post = c.String(),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Author", t => t.AuthorID)
                .Index(t => t.AuthorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "MarketID", "dbo.Market");
            DropForeignKey("dbo.Market", "AuthorID", "dbo.Author");
            DropForeignKey("dbo.Comment", "AuthorID", "dbo.Author");
            DropIndex("dbo.Market", new[] { "AuthorID" });
            DropIndex("dbo.Comment", new[] { "MarketID" });
            DropIndex("dbo.Comment", new[] { "AuthorID" });
            DropTable("dbo.Market");
            DropTable("dbo.Comment");
            DropTable("dbo.Author");
        }
    }
}
