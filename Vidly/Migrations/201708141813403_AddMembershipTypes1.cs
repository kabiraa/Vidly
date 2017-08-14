namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypes1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "MembershipTypesId", newName: "MembershipTypeId");
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipTypesId", newName: "IX_MembershipTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipTypeId", newName: "IX_MembershipTypesId");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipTypesId");
        }
    }
}
