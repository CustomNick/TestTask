using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TestTask.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "delivery_points",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    max_power = table.Column<int>(nullable: false),
                    metering_device_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_points", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organisations",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parent_organisation_id = table.Column<long>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisations", x => x.id);
                    table.ForeignKey(
                        name: "FK_organisations_organisations_parent_organisation_id",
                        column: x => x.parent_organisation_id,
                        principalTable: "organisations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "consumer_objects",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    organisation_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumer_objects", x => x.id);
                    table.ForeignKey(
                        name: "FK_consumer_objects_organisations_organisation_id",
                        column: x => x.organisation_id,
                        principalTable: "organisations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "measuring_points",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    consumer_object_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    counter_number = table.Column<long>(nullable: false),
                    counter_type = table.Column<short>(nullable: false),
                    counter_check_date = table.Column<DateTimeOffset>(nullable: false),
                    current_transformator_number = table.Column<long>(nullable: false),
                    current_transformator_type = table.Column<short>(nullable: false),
                    current_transformator_check_date = table.Column<DateTimeOffset>(nullable: false),
                    current_transformator_coefficient = table.Column<float>(nullable: false),
                    voltage_transformator_number = table.Column<long>(nullable: false),
                    voltage_transformator_type = table.Column<short>(nullable: false),
                    voltage_transformator_check_date = table.Column<DateTimeOffset>(nullable: false),
                    voltage_transformator_coefficient = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measuring_points", x => x.id);
                    table.ForeignKey(
                        name: "FK_measuring_points_consumer_objects_consumer_object_id",
                        column: x => x.consumer_object_id,
                        principalTable: "consumer_objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "measures",
                columns: table => new
                {
                    measuring_point_id = table.Column<long>(nullable: false),
                    delivery_point_id = table.Column<long>(nullable: false),
                    measure_date = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measures", x => new { x.measure_date, x.measuring_point_id, x.delivery_point_id });
                    table.ForeignKey(
                        name: "FK_measures_delivery_points_delivery_point_id",
                        column: x => x.delivery_point_id,
                        principalTable: "delivery_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_measures_measuring_points_measuring_point_id",
                        column: x => x.measuring_point_id,
                        principalTable: "measuring_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "delivery_points",
                columns: new[] { "id", "max_power", "metering_device_name", "name" },
                values: new object[,]
                {
                    { 1L, 1000, "Metering device 1", "Delivery point 1" },
                    { 2L, 2000, "Metering device 2", "Delivery point 2" }
                });

            migrationBuilder.InsertData(
                table: "organisations",
                columns: new[] { "id", "address", "name", "parent_organisation_id" },
                values: new object[] { 1L, "Address 1", "Organisation 1", null });

            migrationBuilder.InsertData(
                table: "organisations",
                columns: new[] { "id", "address", "name", "parent_organisation_id" },
                values: new object[] { 2L, "Address 1", "Organisation 1", 1L });

            migrationBuilder.InsertData(
                table: "consumer_objects",
                columns: new[] { "id", "address", "name", "organisation_id" },
                values: new object[] { 1L, "Consumer object 1 address", "ПС 110/10 Весна", 2L });

            migrationBuilder.InsertData(
                table: "measuring_points",
                columns: new[] { "id", "consumer_object_id", "counter_check_date", "counter_number", "counter_type", "current_transformator_coefficient", "current_transformator_number", "current_transformator_type", "current_transformator_check_date", "name", "voltage_transformator_coefficient", "voltage_transformator_number", "voltage_transformator_type", "voltage_transformator_check_date" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTimeOffset(new DateTime(2023, 8, 8, 12, 42, 49, 225, DateTimeKind.Unspecified).AddTicks(7491), new TimeSpan(0, 0, 0, 0, 0)), 1L, (short)1, 0.8f, 1L, (short)1, new DateTimeOffset(new DateTime(2023, 8, 8, 12, 42, 49, 225, DateTimeKind.Unspecified).AddTicks(8940), new TimeSpan(0, 0, 0, 0, 0)), "Measuring point 1", 0.7f, 1L, (short)1, new DateTimeOffset(new DateTime(2023, 8, 8, 12, 42, 49, 226, DateTimeKind.Unspecified).AddTicks(596), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2L, 1L, new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1L, (short)2, 0.8f, 1L, (short)2, new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Measuring point 2", 0.7f, 1L, (short)2, new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "measures",
                columns: new[] { "measure_date", "measuring_point_id", "delivery_point_id" },
                values: new object[,]
                {
                    { new DateTimeOffset(new DateTime(2023, 8, 8, 12, 42, 49, 227, DateTimeKind.Unspecified).AddTicks(9930), new TimeSpan(0, 0, 0, 0, 0)), 1L, 1L },
                    { new DateTimeOffset(new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_consumer_objects_organisation_id",
                table: "consumer_objects",
                column: "organisation_id");

            migrationBuilder.CreateIndex(
                name: "IX_measures_delivery_point_id",
                table: "measures",
                column: "delivery_point_id");

            migrationBuilder.CreateIndex(
                name: "IX_measures_measuring_point_id",
                table: "measures",
                column: "measuring_point_id");

            migrationBuilder.CreateIndex(
                name: "IX_measuring_points_consumer_object_id",
                table: "measuring_points",
                column: "consumer_object_id");

            migrationBuilder.CreateIndex(
                name: "IX_organisations_parent_organisation_id",
                table: "organisations",
                column: "parent_organisation_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "measures");

            migrationBuilder.DropTable(
                name: "delivery_points");

            migrationBuilder.DropTable(
                name: "measuring_points");

            migrationBuilder.DropTable(
                name: "consumer_objects");

            migrationBuilder.DropTable(
                name: "organisations");
        }
    }
}
