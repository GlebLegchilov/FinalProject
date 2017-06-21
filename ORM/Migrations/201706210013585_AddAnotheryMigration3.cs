namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotheryMigration3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Lots", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Lots", name: "IX_User_Id", newName: "IX_UserId");
            DropColumn("dbo.Lots", "CreatorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lots", "CreatorId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Lots", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Lots", name: "UserId", newName: "User_Id");
        }
    }
}
