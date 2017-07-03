namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewStuctMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lots", "OwnerId");
            RenameColumn(table: "dbo.Lots", name: "UserId", newName: "OwnerId");
            RenameIndex(table: "dbo.Lots", name: "IX_UserId", newName: "IX_OwnerId");
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Boolean(nullable: false),
                        MinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatorId = c.Int(nullable: false),
                        EndingDate = c.DateTime(nullable: false),
                        AvailabilityStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.Int(nullable: false),
                        TargetId = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: true)
                //.ForeignKey("dbo.Users", t => t.TargetId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.CreatorId)
                .Index(t => t.TargetId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AuctionId = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                //.ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AuctionId);
            
            AddColumn("dbo.Lots", "ImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Lots", "AuctionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Lots", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Lots", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Lots", "ImageId");
            CreateIndex("dbo.Lots", "CategoryId");
            CreateIndex("dbo.Lots", "AuctionId");
            //AddForeignKey("dbo.Lots", "CategoryId", "dbo.Categories", "Id");
            //AddForeignKey("dbo.Lots", "ImageId", "dbo.Images", "Id");
            //AddForeignKey("dbo.Lots", "AuctionId", "dbo.Auctions", "Id");
            DropColumn("dbo.Lots", "Price");
            DropColumn("dbo.Lots", "Img");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lots", "Img", c => c.Binary());
            AddColumn("dbo.Lots", "Price", c => c.String());
            DropForeignKey("dbo.Lots", "AuctionId", "dbo.Auctions");
            DropForeignKey("dbo.Rates", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rates", "AuctionId", "dbo.Auctions");
            DropForeignKey("dbo.Lots", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Lots", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Feedbacks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "TargetId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Auctions", "CreatorId", "dbo.Users");
            DropIndex("dbo.Rates", new[] { "AuctionId" });
            DropIndex("dbo.Rates", new[] { "UserId" });
            DropIndex("dbo.Lots", new[] { "AuctionId" });
            DropIndex("dbo.Lots", new[] { "CategoryId" });
            DropIndex("dbo.Lots", new[] { "ImageId" });
            DropIndex("dbo.Feedbacks", new[] { "User_Id" });
            DropIndex("dbo.Feedbacks", new[] { "TargetId" });
            DropIndex("dbo.Feedbacks", new[] { "CreatorId" });
            DropIndex("dbo.Auctions", new[] { "CreatorId" });
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Lots", "Description", c => c.String());
            AlterColumn("dbo.Lots", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Lots", "AuctionId");
            DropColumn("dbo.Lots", "ImageId");
            DropTable("dbo.Rates");
            DropTable("dbo.Images");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Auctions");
            RenameIndex(table: "dbo.Lots", name: "IX_OwnerId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Lots", name: "OwnerId", newName: "UserId");
            AddColumn("dbo.Lots", "OwnerId", c => c.Int(nullable: false));
        }
    }
}
