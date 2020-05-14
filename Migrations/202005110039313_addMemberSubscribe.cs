namespace VenMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMemberSubscribe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "IsSubscribedToNewLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "MyPropertyId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MyPropertyId");
            AddForeignKey("dbo.Customers", "MyPropertyId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MyPropertyId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MyPropertyId" });
            DropColumn("dbo.Customers", "MyPropertyId");
            DropColumn("dbo.Customers", "IsSubscribedToNewLetter");
            DropTable("dbo.MembershipTypes");
        }
    }
}
