namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FollwerId = c.String(nullable: false, maxLength: 128),
                        Follwee_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FollwerId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollwerId)
                .ForeignKey("dbo.AspNetUsers", t => t.Follwee_Id)
                .Index(t => t.FollwerId)
                .Index(t => t.Follwee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "Follwee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollwerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "Follwee_Id" });
            DropIndex("dbo.Followings", new[] { "FollwerId" });
            DropTable("dbo.Followings");
        }
    }
}
