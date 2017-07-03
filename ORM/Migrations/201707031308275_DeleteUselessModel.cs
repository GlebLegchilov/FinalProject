namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUselessModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lots", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Lots", "ImageId", "dbo.Images");
            DropIndex("dbo.Lots", new[] { "ImageId" });
            DropIndex("dbo.Lots", new[] { "CategoryId" });
            AddColumn("dbo.Lots", "Image", c => c.Binary());
            DropColumn("dbo.Lots", "ImageId");
            DropColumn("dbo.Lots", "CategoryId");
            DropTable("dbo.Categories");
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
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
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lots", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Lots", "ImageId", c => c.Int(nullable: false));
            DropColumn("dbo.Lots", "Image");
            CreateIndex("dbo.Lots", "CategoryId");
            CreateIndex("dbo.Lots", "ImageId");
            AddForeignKey("dbo.Lots", "ImageId", "dbo.Images", "Id");
            AddForeignKey("dbo.Lots", "CategoryId", "dbo.Categories", "Id");
        }
    }
}
