﻿namespace MVC_EF_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productconfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prodcts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Qty = c.Int(nullable: false),
                        Sales_SaleID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sales", t => t.Sales_SaleID)
                .Index(t => t.Sales_SaleID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        DtofSale = c.DateTime(nullable: false),
                        QtySold = c.Int(nullable: false),
                        TotAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prodcts", "Sales_SaleID", "dbo.Sales");
            DropIndex("dbo.Prodcts", new[] { "Sales_SaleID" });
            DropTable("dbo.Sales");
            DropTable("dbo.Prodcts");
        }
    }
}
