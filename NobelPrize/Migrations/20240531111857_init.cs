using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NobelPrize.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    AwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptorName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => x.AwardId);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldOfScience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidacyNumber = table.Column<int>(type: "int", nullable: false),
                    CandidacyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "Committee",
                columns: table => new
                {
                    CommitteeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committee", x => x.CommitteeId);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Candidate_Award",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    AwardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate_Award", x => new { x.CandidateId, x.AwardId });
                    table.ForeignKey(
                        name: "FK_Candidate_Award_Award_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Award",
                        principalColumn: "AwardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidate_Award_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidate_Committee",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate_Committee", x => new { x.CandidateId, x.CommitteeId });
                    table.ForeignKey(
                        name: "FK_Candidate_Committee_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidate_Committee_Committee_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committee",
                        principalColumn: "CommitteeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expert",
                columns: table => new
                {
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommitteeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expert", x => x.ExpertId);
                    table.ForeignKey(
                        name: "FK_Expert_Committee_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committee",
                        principalColumn: "CommitteeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidate_Organization",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate_Organization", x => new { x.CandidateId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_Candidate_Organization_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidate_Organization_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Award",
                columns: new[] { "AwardId", "Category", "DescriptorName" },
                values: new object[,]
                {
                    { 1, "Physics", "Nobel Prize in Physics" },
                    { 2, "Chemistry", "Nobel Prize in Chemistry" },
                    { 3, "Physiology or Medicine", "Nobel Prize in Physiology or Medicine" },
                    { 4, "Mathematics", "Fields Medal in Mathematics" },
                    { 5, "Computer Science", "Turing Award in Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "Candidate",
                columns: new[] { "CandidateId", "CandidacyDate", "CandidacyNumber", "DateOfBirth", "FieldOfScience", "FirstName", "LastName", "Nationality" },
                values: new object[,]
                {
                    { 2, new DateTime(1950, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 78586646, new DateTime(1867, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chemistry", "Marie", "Curie", "Polish" },
                    { 3, new DateTime(1975, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 9864753, new DateTime(1950, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicine", "John", "Doe", "American" },
                    { 4, new DateTime(1988, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3548468, new DateTime(1815, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", "Ada", "Lovelace", "British" },
                    { 5, new DateTime(1954, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 235456, new DateTime(1912, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mathematics", "Alan", "Turing", "British" },
                    { 6, new DateTime(1921, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9848546, new DateTime(1867, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics", "Marie", "Skłodowska", "Polish" },
                    { 7, new DateTime(1910, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 78594546, new DateTime(1856, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineering", "Nikola", "Tesla", "Serbian" },
                    { 8, new DateTime(1903, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 65654478, new DateTime(1867, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics", "Marie", "Curie", "Polish" },
                    { 9, new DateTime(1965, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 87546, new DateTime(1918, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics", "Richard", "Feynman", "American" },
                    { 10, new DateTime(2009, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3546568, new DateTime(1939, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chemistry", "Ada", "Yonath", "Israeli" },
                    { 11, new DateTime(1922, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5654564, new DateTime(1879, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics", "Albert", "Einstein", "Swiss" },
                    { 12, new DateTime(1905, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 78485546, new DateTime(1867, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics", "Marie", "Curie", "Polish" }
                });

            migrationBuilder.InsertData(
                table: "Committee",
                columns: new[] { "CommitteeId", "CommitteeCategory" },
                values: new object[,]
                {
                    { 1, "Physics Committee" },
                    { 2, "Chemistry Committee" },
                    { 3, "Physiology and Medicine Committee" },
                    { 4, "Mathematics Committee" },
                    { 5, "Computer Science Committee" },
                    { 7, "Computer Science Committee" },
                    { 8, "Mathematics Committee" },
                    { 9, "Physiology and Medicine Committee" }
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "OrganizationId", "ContactInformation", "Location", "Name" },
                values: new object[,]
                {
                    { 2, "Info@nobellprize.se", "Sweden", "Stockholm Nobel Committee" },
                    { 3, "nobelassembly@ki.se", "Sweden", "Nobel Assembly at Karolinska Institutet" },
                    { 4, "info@kva.se", "Sweden", "Royal Swedish Academy of Sciences" },
                    { 5, "post@nobelpeacecenter.org", "Norway", "Nobel Peace Center" },
                    { 6, "info@nobelprize.org", "Sweden", "The Nobel Foundation" }
                });

            migrationBuilder.InsertData(
                table: "Candidate_Award",
                columns: new[] { "AwardId", "CandidateId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 4, 4 },
                    { 2, 5 },
                    { 3, 6 },
                    { 5, 7 },
                    { 1, 8 },
                    { 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Candidate_Committee",
                columns: new[] { "CandidateId", "CommitteeId", "EvaluationDate", "Result" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 3, 3, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 4, 4, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 5, 5, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 6, 1, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 7, 5, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 8, 1, new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 9, 5, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "Candidate_Organization",
                columns: new[] { "CandidateId", "OrganizationId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "Expert",
                columns: new[] { "ExpertId", "CommitteeId", "ExpertField", "ExpertFirstName", "ExpertLastName" },
                values: new object[,]
                {
                    { 1, 1, "Physics", "John", "Smith" },
                    { 2, 2, "Chemistry", "Emily", "Brown" },
                    { 3, 3, "Physiology and Medicine", "Michael", "Johnson" },
                    { 4, 4, "Mathematics", "David", "Williams" },
                    { 5, 5, "Computer Science", "Sophia", "Davis" },
                    { 6, 1, "Physics", "James", "Martinez" },
                    { 7, 2, "Chemistry", "Emma", "Wilson" },
                    { 8, 3, "Physiology and Medicine", "Alexander", "Anderson" },
                    { 9, 4, "Mathematics", "Olivia", "Thomas" },
                    { 10, 5, "Computer Science", "Daniel", "Taylor" },
                    { 11, 1, "Physics", "William", "Lee" },
                    { 12, 2, "Chemistry", "Lily", "Garcia" },
                    { 13, 3, "Physiology and Medicine", "Matthew", "Rodriguez" },
                    { 14, 4, "Mathematics", "Sophie", "Hernandez" },
                    { 15, 5, "Computer Science", "Ethan", "Young" },
                    { 16, 1, "Physics", "Isabella", "Moore" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Award_DescriptorName",
                table: "Award",
                column: "DescriptorName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CandidacyNumber",
                table: "Candidate",
                column: "CandidacyNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Award_AwardId",
                table: "Candidate_Award",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Committee_CommitteeId",
                table: "Candidate_Committee",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Organization_OrganizationId",
                table: "Candidate_Organization",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Expert_CommitteeId",
                table: "Expert",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ContactInformation",
                table: "Organization",
                column: "ContactInformation",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidate_Award");

            migrationBuilder.DropTable(
                name: "Candidate_Committee");

            migrationBuilder.DropTable(
                name: "Candidate_Organization");

            migrationBuilder.DropTable(
                name: "Expert");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Committee");
        }
    }
}
