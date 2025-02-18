using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyasBilgiIslemTicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTicketModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedRole",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedRole",
                table: "Tickets");
        }
    }
}
