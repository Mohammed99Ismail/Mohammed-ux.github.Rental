namespace VenMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsomefeaturesInCustomerAndMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
