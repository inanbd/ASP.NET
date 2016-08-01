namespace BDHelp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnliketoUserQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserQuestions", "Unlike", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserQuestions", "Unlike");
        }
    }
}
