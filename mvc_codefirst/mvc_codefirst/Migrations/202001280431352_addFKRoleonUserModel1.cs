namespace mvc_codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFKRoleonUserModel1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TB_M_Login", new[] { "role_Id" });
            CreateIndex("dbo.TB_M_Login", "Role_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TB_M_Login", new[] { "Role_Id" });
            CreateIndex("dbo.TB_M_Login", "role_Id");
        }
    }
}
