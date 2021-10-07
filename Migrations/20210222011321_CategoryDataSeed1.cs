using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebApp.Migrations
{
    public partial class CategoryDataSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("INSERT INTO Categories(Name,Slug) VALUES('Sports','sports')");
            //migrationBuilder.Sql("INSERT INTO Categories(Name,Slug) VALUES('Entertainment','entertainment')");
            //migrationBuilder.Sql("INSERT INTO Categories(Name,Slug) VALUES('Technology','technology')");
            //migrationBuilder.Sql("INSERT INTO Categories(Name,Slug) VALUES('Internation','international')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
