namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotheryMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lots", "User_Id", "dbo.Users");
            DropIndex("dbo.Lots", new[] { "User_Id" });
            AlterColumn("dbo.Lots", "User_Id", c => c.Int(nullable: true));
            CreateIndex("dbo.Lots", "User_Id");
            AddForeignKey("dbo.Lots", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lots", "User_Id", "dbo.Users");
            DropIndex("dbo.Lots", new[] { "User_Id" });
            AlterColumn("dbo.Lots", "User_Id", c => c.Int());
            CreateIndex("dbo.Lots", "User_Id");
            AddForeignKey("dbo.Lots", "User_Id", "dbo.Users", "Id");
        }
    }
}
