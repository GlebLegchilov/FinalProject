namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotheryMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lots", "User_Id", c => c.Int());
            CreateIndex("dbo.Lots", "User_Id");
            AddForeignKey("dbo.Lots", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lots", "User_Id", "dbo.Users");
            DropIndex("dbo.Lots", new[] { "User_Id" });
            DropColumn("dbo.Lots", "User_Id");
        }
    }
}
