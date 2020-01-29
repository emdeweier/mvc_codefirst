namespace mvc_codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Login",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_M_Login");
        }
    }
}
