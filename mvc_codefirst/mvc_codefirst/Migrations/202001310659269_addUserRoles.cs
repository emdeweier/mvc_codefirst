namespace mvc_codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Username = c.String(nullable: false, maxLength: 128),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Username, t.Role_Id })
                .ForeignKey("dbo.TB_M_Users", t => t.User_Username, cascadeDelete: true)
                .ForeignKey("dbo.TB_M_Role", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Username)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.TB_M_Role");
            DropForeignKey("dbo.UserRoles", "User_Username", "dbo.TB_M_Users");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Username" });
            DropTable("dbo.UserRoles");
        }
    }
}
