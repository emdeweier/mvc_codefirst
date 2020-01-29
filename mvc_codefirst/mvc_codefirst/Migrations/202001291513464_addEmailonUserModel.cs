namespace mvc_codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmailonUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_M_Login", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_M_Login", "Email");
        }
    }
}
