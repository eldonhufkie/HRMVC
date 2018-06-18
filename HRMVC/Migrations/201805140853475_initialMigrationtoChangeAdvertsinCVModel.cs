namespace HRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigrationtoChangeAdvertsinCVModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CVs", name: "Advert_Id", newName: "Adverts_Id");
            RenameIndex(table: "dbo.CVs", name: "IX_Advert_Id", newName: "IX_Adverts_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CVs", name: "IX_Adverts_Id", newName: "IX_Advert_Id");
            RenameColumn(table: "dbo.CVs", name: "Adverts_Id", newName: "Advert_Id");
        }
    }
}
