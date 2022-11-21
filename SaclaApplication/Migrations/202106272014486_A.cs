namespace SaclaApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        PaperId = c.Int(nullable: false, identity: true),
                        PaperTitle = c.String(nullable: false),
                        PaperAbstract = c.String(nullable: false),
                        PaperAuthor = c.String(),
                        PaperDateSubmitted = c.DateTime(nullable: false),
                        TopicId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaperId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        TopicName = c.String(),
                    })
                .PrimaryKey(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Topics");
            DropTable("dbo.Papers");
        }
    }
}
