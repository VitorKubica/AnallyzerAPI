using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnallyzerAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CAMPAINS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_names = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_descriptions = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_companies = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_startdate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    dt_forecastdate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    dt_status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_registrationdate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CAMPAINS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CAMPAINS");
        }
    }
}
