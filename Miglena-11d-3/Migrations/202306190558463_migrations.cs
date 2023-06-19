namespace Miglena_11d_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Marka = c.String(),
                        Opisanie = c.String(),
                        Price = c.Double(nullable: false),
                        Nomer = c.Double(nullable: false),
                        ShoeTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ShoeTypes", t => t.ShoeTypeId, cascadeDelete: true)
                .Index(t => t.ShoeTypeId);
            
            CreateTable(
                "dbo.ShoeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marka = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoes", "ShoeTypeId", "dbo.ShoeTypes");
            DropIndex("dbo.Shoes", new[] { "ShoeTypeId" });
            DropTable("dbo.ShoeTypes");
            DropTable("dbo.Shoes");
        }
    }
}
