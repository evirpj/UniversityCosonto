namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormulaireCreationCompte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "MailAdresse", c => c.String());
            AddColumn("dbo.Person", "Login", c => c.String());
            AddColumn("dbo.Person", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Password");
            DropColumn("dbo.Person", "Login");
            DropColumn("dbo.Person", "MailAdresse");
        }
    }
}
