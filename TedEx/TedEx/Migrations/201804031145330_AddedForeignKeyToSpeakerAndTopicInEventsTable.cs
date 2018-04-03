namespace TedEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyToSpeakerAndTopicInEventsTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Speaker_Id", newName: "SpeakerId");
            RenameColumn(table: "dbo.Events", name: "Topic_Id", newName: "TopicId");
            RenameIndex(table: "dbo.Events", name: "IX_Speaker_Id", newName: "IX_SpeakerId");
            RenameIndex(table: "dbo.Events", name: "IX_Topic_Id", newName: "IX_TopicId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_TopicId", newName: "IX_Topic_Id");
            RenameIndex(table: "dbo.Events", name: "IX_SpeakerId", newName: "IX_Speaker_Id");
            RenameColumn(table: "dbo.Events", name: "TopicId", newName: "Topic_Id");
            RenameColumn(table: "dbo.Events", name: "SpeakerId", newName: "Speaker_Id");
        }
    }
}
