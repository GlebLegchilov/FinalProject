namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangeAuction2Migration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Lots", new[] { "AuctionId" });
            AddColumn("dbo.Auctions", "LotId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lots", "AuctionId", c => c.Int());
            CreateIndex("dbo.Lots", "AuctionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Lots", new[] { "AuctionId" });
            AlterColumn("dbo.Lots", "AuctionId", c => c.Int(nullable: false));
            DropColumn("dbo.Auctions", "LotId");
            CreateIndex("dbo.Lots", "AuctionId");
        }
    }
}
