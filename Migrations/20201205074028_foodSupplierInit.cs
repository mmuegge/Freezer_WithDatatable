using Microsoft.EntityFrameworkCore.Migrations;

namespace Freezer_MVC.Migrations
{
    public partial class foodSupplierInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO FOODSUPPLIERS (NAME) VALUES ('Edeka');");
            migrationBuilder.Sql("INSERT INTO FOODSUPPLIERS (NAME) VALUES ('Real Kauf');");
            migrationBuilder.Sql("INSERT INTO FOODSUPPLIERS (NAME) VALUES ('Hof Lehmkuhl');");
            migrationBuilder.Sql("INSERT INTO FOODSUPPLIERS (NAME) VALUES ('Aldi');");
            migrationBuilder.Sql("INSERT INTO FOODSUPPLIERS (NAME) VALUES ('Inkoop');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM FOODSUPPLIERS WHERE NAME = 'Edeka';");
            migrationBuilder.Sql("DELETE FROM FOODSUPPLIERS WHERE NAME = 'Real Kauf';");
            migrationBuilder.Sql("DELETE FROM FOODSUPPLIERS WHERE NAME = 'Hof Lehmkuhl';");
            migrationBuilder.Sql("DELETE FROM FOODSUPPLIERS WHERE NAME = 'Aldi';");
            migrationBuilder.Sql("DELETE FROM FOODSUPPLIERS WHERE NAME = 'Inkoop';");
        }
    }
}
