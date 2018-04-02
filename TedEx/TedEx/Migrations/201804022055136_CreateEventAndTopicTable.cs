namespace TedEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEventAndTopicTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Speaker_Id = c.String(maxLength: 128),
                        Topic_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Speaker_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Speaker_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Events", "Speaker_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "Topic_Id" });
            DropIndex("dbo.Events", new[] { "Speaker_Id" });
            DropTable("dbo.Topics");
            DropTable("dbo.Events");
        }
    }
}
