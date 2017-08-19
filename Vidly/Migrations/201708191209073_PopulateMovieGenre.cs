namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MovieGenres(Name) Values ('Comedy')");
            Sql("Insert into MovieGenres(Name) Values ('Action')");
            Sql("Insert into MovieGenres(Name) Values ('Romance')");
            Sql("Insert into MovieGenres(Name) Values ('Family')");
        }
        
        public override void Down()
        {
        }
    }
}
