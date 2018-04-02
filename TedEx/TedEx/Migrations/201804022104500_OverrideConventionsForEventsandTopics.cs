namespace TedEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForEventsandTopics : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Speaker_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.Events", new[] { "Speaker_Id" });
            DropIndex("dbo.Events", new[] { "Topic_Id" });
            AlterColumn("dbo.Events", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Events", "Speaker_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "Topic_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Events", "Speaker_Id");
            CreateIndex("dbo.Events", "Topic_Id");
            AddForeignKey("dbo.Events", "Speaker_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "Topic_Id", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Events", "Speaker_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "Topic_Id" });
            DropIndex("dbo.Events", new[] { "Speaker_Id" });
            AlterColumn("dbo.Topics", "Name", c => c.String());
            AlterColumn("dbo.Events", "Topic_Id", c => c.Byte());
            AlterColumn("dbo.Events", "Speaker_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "Venue", c => c.String());
            CreateIndex("dbo.Events", "Topic_Id");
            CreateIndex("dbo.Events", "Speaker_Id");
            AddForeignKey("dbo.Events", "Topic_Id", "dbo.Topics", "Id");
            AddForeignKey("dbo.Events", "Speaker_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
