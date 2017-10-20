namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataForCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES(NAME) VALUES('WEB DESIGNER')");
            Sql("INSERT INTO CATEGORIES(NAME) VALUES('DATA SCIENCE')");
            Sql("INSERT INTO CATEGORIES(NAME) VALUES('ONLINE MARKETING')");
        }
        
        public override void Down()
        {
        }
    }
}
