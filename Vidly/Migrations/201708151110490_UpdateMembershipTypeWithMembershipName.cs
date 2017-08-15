namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeWithMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set MembershipName = 'Pay as you go' where Id = 1");
            Sql("Update MembershipTypes set MembershipName = 'Monthly' where Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
