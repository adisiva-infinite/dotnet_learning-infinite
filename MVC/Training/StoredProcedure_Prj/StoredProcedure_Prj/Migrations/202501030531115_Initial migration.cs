namespace StoredProcedure_Prj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Did = c.Int(nullable: false, identity: true),
                        Dname = c.String(),
                    })
                .PrimaryKey(t => t.Did);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ename = c.String(),
                        Esalary = c.Double(nullable: false),
                        Department_Did = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Did)
                .Index(t => t.Department_Did);
            
            CreateStoredProcedure(
                "dbo.InsertEmployee",
                p => new
                    {
                        Ename = p.String(),
                        Esalary = p.Double(),
                        Department_Did = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Employees]([Ename], [Esalary], [Department_Did])
                      VALUES (@Ename, @Esalary, @Department_Did)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Employees]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Employees] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.UpdateEmployee",
                p => new
                    {
                        Id = p.Int(),
                        Ename = p.String(),
                        Esalary = p.Double(),
                        Department_Did = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Employees]
                      SET [Ename] = @Ename, [Esalary] = @Esalary, [Department_Did] = @Department_Did
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteEmployee",
                p => new
                    {
                        Id = p.Int(),
                        Department_Did = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Employees]
                      WHERE (([Id] = @Id) AND (([Department_Did] = @Department_Did) OR ([Department_Did] IS NULL AND @Department_Did IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteEmployee");
            DropStoredProcedure("dbo.UpdateEmployee");
            DropStoredProcedure("dbo.InsertEmployee");
            DropForeignKey("dbo.Employees", "Department_Did", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_Did" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
