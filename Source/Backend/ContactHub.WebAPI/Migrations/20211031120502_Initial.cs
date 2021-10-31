using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactHub.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEventTypeColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(nullable: true),
                    ColorHex = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEventTypeColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserId = table.Column<string>(nullable: true),
                    ProfilePhoto = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PrimaryContactNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    HomeNumber = table.Column<string>(nullable: true),
                    WorkNumber = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUser_AspNetUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEventType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTypeName = table.Column<string>(nullable: true),
                    EventTypeColorId = table.Column<int>(nullable: false),
                    CalendarEventTypeColorId = table.Column<int>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CalendarEventsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEventType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEventType_CalendarEventTypeColor_CalendarEventTypeColorId",
                        column: x => x.CalendarEventTypeColorId,
                        principalTable: "CalendarEventTypeColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarEventTypeId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    AllDayEvent = table.Column<bool>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    RepeatEvent = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_CalendarEventType_CalendarEventTypeId",
                        column: x => x.CalendarEventTypeId,
                        principalTable: "CalendarEventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PrimaryContactNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    WorkNumber = table.Column<string>(nullable: true),
                    HomeNumber = table.Column<string>(nullable: true),
                    emailAddress = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Birthdy = table.Column<DateTime>(nullable: true),
                    BirthdayCalendarEventId = table.Column<int>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    LastViewed = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ContactBirthdayEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_CalendarEvents_ContactBirthdayEventId",
                        column: x => x.ContactBirthdayEventId,
                        principalTable: "CalendarEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_CalendarEventTypeId",
                table: "CalendarEvents",
                column: "CalendarEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEventType_CalendarEventTypeColorId",
                table: "CalendarEventType",
                column: "CalendarEventTypeColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEventType_CalendarEventsId",
                table: "CalendarEventType",
                column: "CalendarEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactBirthdayEventId",
                table: "Contact",
                column: "ContactBirthdayEventId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_AspNetUserId",
                table: "SystemUser",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEventType_CalendarEvents_CalendarEventsId",
                table: "CalendarEventType",
                column: "CalendarEventsId",
                principalTable: "CalendarEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvents_CalendarEventType_CalendarEventTypeId",
                table: "CalendarEvents");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "AspNetUser");

            migrationBuilder.DropTable(
                name: "CalendarEventType");

            migrationBuilder.DropTable(
                name: "CalendarEventTypeColor");

            migrationBuilder.DropTable(
                name: "CalendarEvents");
        }
    }
}
