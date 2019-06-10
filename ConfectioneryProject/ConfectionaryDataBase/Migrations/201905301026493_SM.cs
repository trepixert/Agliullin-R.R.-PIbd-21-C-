using System.Data.Entity.Migrations;

namespace ConfectionaryDataBase.Migrations {
    public partial class SM : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.Implementers",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    ImplementerFIO = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Orders", "ImplementerID", c => c.Int());
            CreateIndex("dbo.Orders", "ImplementerID");
            AddForeignKey("dbo.Orders", "ImplementerID", "dbo.Implementers", "Id");
        }

        public override void Down() {
            DropForeignKey("dbo.Orders", "ImplementerID", "dbo.Implementers");
            DropIndex("dbo.Orders", new[] {"ImplementerID"});
            DropColumn("dbo.Orders", "ImplementerID");
            DropTable("dbo.Implementers");
        }
    }
}