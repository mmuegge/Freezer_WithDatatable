using Microsoft.EntityFrameworkCore.Migrations;

namespace Freezer_MVC.Migrations
{
    public partial class foodGroupInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO FOODGROUPS (NAME) VALUES ('Fleisch');");
            migrationBuilder.Sql("INSERT INTO FOODGROUPS (NAME) VALUES ('Fisch');");
            migrationBuilder.Sql("INSERT INTO FOODGROUPS (NAME) VALUES ('Gemüse');");
            migrationBuilder.Sql("INSERT INTO FOODGROUPS (NAME) VALUES ('Obst');");
            migrationBuilder.Sql("INSERT INTO FOODGROUPS (NAME) VALUES ('Eis');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM FOODGROUPS WHERE NAME = 'Fleisch';");
            migrationBuilder.Sql("DELETE FROM FOODGROUPS WHERE NAME = 'Fisch';");
            migrationBuilder.Sql("DELETE FROM FOODGROUPS WHERE NAME = 'Gemüse';");
            migrationBuilder.Sql("DELETE FROM FOODGROUPS WHERE NAME = 'Obst';");
            migrationBuilder.Sql("DELETE FROM FOODGROUPS WHERE NAME = 'Eis';");
        }
    }
}
