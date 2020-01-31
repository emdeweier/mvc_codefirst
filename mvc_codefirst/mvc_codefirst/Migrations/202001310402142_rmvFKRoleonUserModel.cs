namespace mvc_codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rmvFKRoleonUserModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_M_Login", "Role_Id", "dbo.TB_M_Role");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.TB_M_Login", "Role_Id", "dbo.TB_M_Role", "Id");
        }
    }
}
