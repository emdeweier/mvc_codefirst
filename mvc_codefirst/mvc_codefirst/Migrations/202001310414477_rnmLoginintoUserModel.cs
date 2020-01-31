namespace mvc_codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rnmLoginintoUserModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TB_M_Login", newName: "TB_M_Users");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TB_M_Users", newName: "TB_M_Login");
        }
    }
}
