namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotheryMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lots", "CreationDate");
            DropColumn("dbo.Lots", "PurchaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lots", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lots", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
