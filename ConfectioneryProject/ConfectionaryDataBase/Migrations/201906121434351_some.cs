namespace ConfectionaryDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class some : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageInfoes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ImplementerID", "dbo.Implementers");
            DropIndex("dbo.MessageInfoes", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "ImplementerID" });
            DropColumn("dbo.Customers", "Mail");
            DropColumn("dbo.Orders", "ImplementerID");
            DropTable("dbo.MessageInfoes");
            DropTable("dbo.Implementers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Implementers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImplementerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "ImplementerID", c => c.Int());
            AddColumn("dbo.Customers", "Mail", c => c.String());
            CreateIndex("dbo.Orders", "ImplementerID");
            CreateIndex("dbo.MessageInfoes", "CustomerId");
            AddForeignKey("dbo.Orders", "ImplementerID", "dbo.Implementers", "Id");
            AddForeignKey("dbo.MessageInfoes", "CustomerId", "dbo.Customers", "ID");
        }
    }
}
