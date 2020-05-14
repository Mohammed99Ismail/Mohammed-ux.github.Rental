namespace VenMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applichanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "MyPropertyId", newName: "MembershipTypeId");
            RenameIndex(table: "dbo.Customers", name: "IX_MyPropertyId", newName: "IX_MembershipTypeId");
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipTypeId", newName: "IX_MyPropertyId");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MyPropertyId");
        }
    }
}
