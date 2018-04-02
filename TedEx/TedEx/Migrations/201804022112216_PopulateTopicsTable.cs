namespace TedEx.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTopicsTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Topics (Id, Name) values(1,'ASP.NET WEB API')");
            Sql("Insert into Topics (Id, Name) values(2,'ENTITY FRAMEWORK')");
            Sql("Insert into Topics (Id, Name) values(3,'BOOTSTRAP')");
            Sql("Insert into Topics (Id, Name) values(4,'VISUAL STUDIO TEAM SERVICES')");
        }

        public override void Down()
        {
            Sql("Delete from Topics Where Id IN 1, 2, 3, 4");
        }
    }
}
