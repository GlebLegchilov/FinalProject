namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangeAuctionMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "Name");
        }
    }
}
