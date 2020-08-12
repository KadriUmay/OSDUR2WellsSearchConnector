using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OSDUR2WellConnector.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wells",
                columns: table => new
                {
                    UWI = table.Column<string>(nullable: false),
                    CountryID = table.Column<string>(nullable: true),
                    DataSourceOrganisationID = table.Column<string>(nullable: true),
                    DefaultVerticalMeasurementID = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    OperatingEnvironmentID = table.Column<string>(nullable: true),
                    QuadrantID = table.Column<string>(nullable: true),
                    StateProvinceID = table.Column<string>(nullable: true),
                    FacilityEvent = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Lon = table.Column<string>(nullable: true),
                    ResourceID = table.Column<string>(nullable: true),
                    ResourceSecurityClassification = table.Column<string>(nullable: true),
                    ResourceTypeID = table.Column<string>(nullable: true),
                    SpudDate = table.Column<string>(nullable: true),
                    WellName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wells", x => x.UWI);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wells");
        }
    }
}
