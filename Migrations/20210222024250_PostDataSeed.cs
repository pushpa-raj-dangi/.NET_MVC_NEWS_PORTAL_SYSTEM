using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebApp.Migrations
{
    public partial class PostDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"  INSERT INTO Posts([name],slug,content,picture,PostStatus) VALUES
    ('Post first post','slug','This is content','C:\Users\Dell\Downloads\feature.jpg',1)");

            migrationBuilder.Sql(@"  INSERT INTO Posts([name],slug,content,picture,PostStatus) VALUES
    ('Post first post','slug','This is content','C:\Users\Dell\Downloads\20210212_163826.jpg',1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
