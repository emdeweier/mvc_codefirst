namespace mvc_codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFKRoleonUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_M_Login", "role_Id", c => c.Int());
            CreateIndex("dbo.TB_M_Login", "role_Id");
            AddForeignKey("dbo.TB_M_Login", "role_Id", "dbo.TB_M_Role", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_M_Login", "role_Id", "dbo.TB_M_Role");
            DropIndex("dbo.TB_M_Login", new[] { "role_Id" });
            DropColumn("dbo.TB_M_Login", "role_Id");
        }
    }
}
