namespace BDHelp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionNoToAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "QuestionNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "QuestionNo");
        }
    }
}
