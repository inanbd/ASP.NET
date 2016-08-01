namespace BDHelp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(nullable: false),
                        AnswerRating = c.Int(nullable: false),
                        AnswerDate = c.DateTime(nullable: false),
                        QuestionId_QuestionId = c.Int(),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.UserQuestions", t => t.QuestionId_QuestionId)
                .ForeignKey("dbo.UserModels", t => t.UserId_UserId)
                .Index(t => t.QuestionId_QuestionId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.UserQuestions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionHeader = c.String(nullable: false),
                        QuestionText = c.String(),
                        QuestionRating = c.Int(nullable: false),
                        IsSatisfied = c.Int(nullable: false),
                        QuestionDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        UserPhone = c.String(),
                        UserCity = c.String(nullable: false),
                        UserAddress = c.String(nullable: false),
                        UserRating = c.Int(nullable: false),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserModelUserQuestions",
                c => new
                    {
                        UserModel_UserId = c.Int(nullable: false),
                        UserQuestion_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserModel_UserId, t.UserQuestion_QuestionId })
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserQuestions", t => t.UserQuestion_QuestionId, cascadeDelete: true)
                .Index(t => t.UserModel_UserId)
                .Index(t => t.UserQuestion_QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModelUserQuestions", "UserQuestion_QuestionId", "dbo.UserQuestions");
            DropForeignKey("dbo.UserModelUserQuestions", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.Answers", "UserId_UserId", "dbo.UserModels");
            DropForeignKey("dbo.UserQuestions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Answers", "QuestionId_QuestionId", "dbo.UserQuestions");
            DropIndex("dbo.UserModelUserQuestions", new[] { "UserQuestion_QuestionId" });
            DropIndex("dbo.UserModelUserQuestions", new[] { "UserModel_UserId" });
            DropIndex("dbo.UserQuestions", new[] { "CategoryId" });
            DropIndex("dbo.Answers", new[] { "UserId_UserId" });
            DropIndex("dbo.Answers", new[] { "QuestionId_QuestionId" });
            DropTable("dbo.UserModelUserQuestions");
            DropTable("dbo.UserModels");
            DropTable("dbo.Categories");
            DropTable("dbo.UserQuestions");
            DropTable("dbo.Answers");
        }
    }
}
