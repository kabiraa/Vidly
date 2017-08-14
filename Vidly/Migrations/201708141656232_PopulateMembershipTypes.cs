namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into membershiptypes(SignUpFee, DiscountRate, DurationInMonths) values (0,0,0)");
            Sql("insert into membershiptypes(SignUpFee, DiscountRate, DurationInMonths) values (30,15,3)");
            Sql("insert into membershiptypes(SignUpFee, DiscountRate, DurationInMonths) values (90,20,6)");
            Sql("insert into membershiptypes(SignUpFee, DiscountRate, DurationInMonths) values (120,25,12)");
        }
        
        public override void Down()
        {
        }
    }
}
