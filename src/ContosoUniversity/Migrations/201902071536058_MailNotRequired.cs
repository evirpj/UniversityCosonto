namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MailNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "MailAdresse", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "MailAdresse", c => c.String(nullable: false));
        }
    }
}
