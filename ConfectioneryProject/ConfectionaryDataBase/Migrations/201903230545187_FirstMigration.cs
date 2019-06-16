using System.Data.Entity.Migrations;

namespace ConfectionaryDataBase.Migrations {
    public partial class FirstMigration : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.Customers",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    CustomerFIO = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Orders",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    CustomerID = c.Int(nullable: false),
                    DetailID = c.Int(nullable: false),
                    OutputID = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                    Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Status = c.Int(nullable: false),
                    DateCreate = c.DateTime(nullable: false),
                    DateImplement = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Outputs", t => t.OutputID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.OutputID);

            CreateTable(
                "dbo.Outputs",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    OutputName = c.String(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.ConnectionBetweenDetailAndOutputs",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    OutputID = c.Int(nullable: false),
                    DetailID = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Details", t => t.DetailID, cascadeDelete: true)
                .ForeignKey("dbo.Outputs", t => t.OutputID, cascadeDelete: true)
                .Index(t => t.OutputID)
                .Index(t => t.DetailID);

            CreateTable(
                "dbo.Details",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    DetailName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.StorageDetails",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    StorageID = c.Int(nullable: false),
                    DetailID = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Details", t => t.DetailID, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageID, cascadeDelete: true)
                .Index(t => t.StorageID)
                .Index(t => t.DetailID);

            CreateTable(
                "dbo.Storages",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    StorageName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);
        }

        public override void Down() {
            DropForeignKey("dbo.StorageDetails", "StorageID", "dbo.Storages");
            DropForeignKey("dbo.Orders", "OutputID", "dbo.Outputs");
            DropForeignKey("dbo.ConnectionBetweenDetailAndOutputs", "OutputID", "dbo.Outputs");
            DropForeignKey("dbo.StorageDetails", "DetailID", "dbo.Details");
            DropForeignKey("dbo.ConnectionBetweenDetailAndOutputs", "DetailID", "dbo.Details");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.StorageDetails", new[] {"DetailID"});
            DropIndex("dbo.StorageDetails", new[] {"StorageID"});
            DropIndex("dbo.ConnectionBetweenDetailAndOutputs", new[] {"DetailID"});
            DropIndex("dbo.ConnectionBetweenDetailAndOutputs", new[] {"OutputID"});
            DropIndex("dbo.Orders", new[] {"OutputID"});
            DropIndex("dbo.Orders", new[] {"CustomerID"});
            DropTable("dbo.Storages");
            DropTable("dbo.StorageDetails");
            DropTable("dbo.Details");
            DropTable("dbo.ConnectionBetweenDetailAndOutputs");
            DropTable("dbo.Outputs");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}