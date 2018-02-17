namespace AlbertosMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                {
                    CommentID = c.Int(nullable: false, identity: true),
                    MarketID = c.Int(nullable: false),
                    AuthorID = c.Int(),
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
                    AuthorID = c.Int(),
                    PostDate = c.DateTime(nullable: false),
                    Option = c.Int(),
                    Price = c.Int(nullable: false),
                    Title = c.String(),
                    Post = c.String(),
                    Secret = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Author",
                c => new
                {
                    ID = c.Int(nullable:false, identity:true),
                    Name = c.String(nullable:false),
                    JoinDate = c.DateTime(nullable:false),
                    location = c.String(),
          
                })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
        }
    }
}
