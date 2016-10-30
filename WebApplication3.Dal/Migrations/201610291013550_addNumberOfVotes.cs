namespace RadaCode.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberOfVotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "HaveVotes", c => c.Int(nullable: false));
            AddColumn("dbo.UserIdeas", "NumberOfVotes", c => c.Int(nullable: false));
            AlterColumn("dbo.UserIdeas", "Idea", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserIdeas", "Idea", c => c.String());
            DropColumn("dbo.UserIdeas", "NumberOfVotes");
            DropColumn("dbo.Users", "HaveVotes");
        }
    }
}
