namespace NewsPaper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsArticleCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsArticleID = c.Int(nullable: false),
                        NewsCategoryID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsArticles", t => t.NewsArticleID, cascadeDelete: true)
                .ForeignKey("dbo.NewsCategories", t => t.NewsCategoryID, cascadeDelete: true)
                .Index(t => t.NewsArticleID)
                .Index(t => t.NewsCategoryID);
            
            CreateTable(
                "dbo.NewsArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Headline = c.String(maxLength: 256),
                        Extract = c.String(),
                        Encoding = c.String(maxLength: 45),
                        Text = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        ByLine = c.String(maxLength: 255),
                        Source = c.String(maxLength: 255),
                        State = c.Int(nullable: false),
                        HtmlTitle = c.String(maxLength: 255),
                        HtmlMetaDescription = c.String(maxLength: 255),
                        Tags = c.String(maxLength: 255),
                        Priority = c.Int(nullable: false),
                        PhotoHtmlAlt = c.String(),
                        PhotoURL = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsArticleCategories", "NewsCategoryID", "dbo.NewsCategories");
            DropForeignKey("dbo.NewsArticleCategories", "NewsArticleID", "dbo.NewsArticles");
            DropIndex("dbo.NewsArticleCategories", new[] { "NewsCategoryID" });
            DropIndex("dbo.NewsArticleCategories", new[] { "NewsArticleID" });
            DropTable("dbo.NewsCategories");
            DropTable("dbo.NewsArticles");
            DropTable("dbo.NewsArticleCategories");
        }
    }
}
