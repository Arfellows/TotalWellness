namespace TotalWellness.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comment", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Post", "PostDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Post", "PostDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comment", "Date", c => c.DateTime(nullable: false));
        }
    }
}
