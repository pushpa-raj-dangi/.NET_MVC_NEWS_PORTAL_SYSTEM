using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebApp.Migrations
{
    public partial class SeedTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tags(Name,Slug) VALUES('Sports','sports')");
            migrationBuilder.Sql("INSERT INTO Tags(Name,Slug) VALUES('Entertainment','entertainment')");
            migrationBuilder.Sql("INSERT INTO Tags(Name,Slug) VALUES('Technology','technology')");
            migrationBuilder.Sql("INSERT INTO Tags(Name,Slug) VALUES('Internation','international')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
