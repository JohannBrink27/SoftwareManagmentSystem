namespace JJDev.SoftHost.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoftwareViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoftwareViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LicenseKey = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        DownloadPath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SoftwareViewModels");
        }
    }
}
