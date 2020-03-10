using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreadName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PricePerUnit = table.Column<double>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MinCount = table.Column<int>(nullable: false),
                    MaxCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliverTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromHour = table.Column<int>(nullable: false),
                    ToHour = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TelegramUserName = table.Column<string>(type: "varchar(100)", nullable: true),
                    TelegramName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TelegramChatId = table.Column<long>(nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true),
                    RoleEnum = table.Column<int>(nullable: false),
                    SecurityCode = table.Column<string>(type: "varchar(6)", nullable: true),
                    SecurityCodeExpiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreadId = table.Column<int>(nullable: false),
                    BreadCount = table.Column<int>(nullable: false),
                    UserAddressId = table.Column<long>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    IsDelivered = table.Column<bool>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    TrackingCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    DeliverTimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factors_Breads_BreadId",
                        column: x => x.BreadId,
                        principalTable: "Breads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factors_DeliverTimes_DeliverTimeId",
                        column: x => x.DeliverTimeId,
                        principalTable: "DeliverTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factors_UserAddresses_UserAddressId",
                        column: x => x.UserAddressId,
                        principalTable: "UserAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factors_BreadId",
                table: "Factors",
                column: "BreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_DeliverTimeId",
                table: "Factors",
                column: "DeliverTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_UserAddressId",
                table: "Factors",
                column: "UserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropTable(
                name: "Breads");

            migrationBuilder.DropTable(
                name: "DeliverTimes");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
