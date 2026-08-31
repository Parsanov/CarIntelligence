using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    DisplacementL = table.Column<decimal>(type: "numeric", nullable: false),
                    FuelType = table.Column<string>(type: "text", nullable: false),
                    PowerHp = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearBoxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Kind = table.Column<string>(type: "text", nullable: false),
                    Gears = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suspensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Kind = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngineIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Descriptions = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<short>(type: "smallint", nullable: false),
                    TypicalMileageKm = table.Column<int>(type: "integer", nullable: false),
                    AppliesYearFrom = table.Column<short>(type: "smallint", nullable: false),
                    AppliesYearTo = table.Column<short>(type: "smallint", nullable: false),
                    HowToCheck = table.Column<string>(type: "text", nullable: false),
                    EnginesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngineIssues_Engines_EnginesId",
                        column: x => x.EnginesId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GearboxIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Descriptions = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<short>(type: "smallint", nullable: false),
                    TypicalMileageKm = table.Column<int>(type: "integer", nullable: false),
                    AppliesYearFrom = table.Column<short>(type: "smallint", nullable: false),
                    AppliesYearTo = table.Column<short>(type: "smallint", nullable: false),
                    GearBoxId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearboxIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearboxIssues_GearBoxes_GearBoxId",
                        column: x => x.GearBoxId,
                        principalTable: "GearBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MakeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuspensionsIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<short>(type: "smallint", nullable: false),
                    TypicalMileageKm = table.Column<int>(type: "integer", nullable: false),
                    HowToCheck = table.Column<string>(type: "text", nullable: false),
                    SuspensionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspensionsIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuspensionsIssues_Suspensions_SuspensionsId",
                        column: x => x.SuspensionsId,
                        principalTable: "Suspensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    YearFrom = table.Column<short>(type: "smallint", nullable: false),
                    YearTo = table.Column<short>(type: "smallint", nullable: false),
                    ModelsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generations_Models_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Descriptions = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<short>(type: "smallint", nullable: false),
                    Zone = table.Column<string>(type: "text", nullable: false),
                    GenerationsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyIssues_Generations_GenerationsId",
                        column: x => x.GenerationsId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Powertrains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenerationsId = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineId = table.Column<Guid>(type: "uuid", nullable: false),
                    SuspensionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    GearBoxId = table.Column<Guid>(type: "uuid", nullable: false),
                    Drive = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powertrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Powertrains_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Powertrains_GearBoxes_GearBoxId",
                        column: x => x.GearBoxId,
                        principalTable: "GearBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Powertrains_Generations_GenerationsId",
                        column: x => x.GenerationsId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Powertrains_Suspensions_SuspensionsId",
                        column: x => x.SuspensionsId,
                        principalTable: "Suspensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Explanations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PriceBand = table.Column<string>(type: "text", nullable: false),
                    ScoreBand = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    ModelVersion = table.Column<string>(type: "text", nullable: false),
                    GeneratedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PowertrainsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explanations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Explanations_Powertrains_PowertrainsId",
                        column: x => x.PowertrainsId,
                        principalTable: "Powertrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AutoriaId = table.Column<long>(type: "bigint", nullable: false),
                    PowertrainId = table.Column<Guid>(type: "uuid", nullable: true),
                    PowertrainsId = table.Column<Guid>(type: "uuid", nullable: false),
                    Vin = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    PriceUSD = table.Column<decimal>(type: "numeric", nullable: false),
                    MileageKm = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    RawPayload = table.Column<JsonDocument>(type: "jsonb", nullable: false),
                    FetchedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_Powertrains_PowertrainsId",
                        column: x => x.PowertrainsId,
                        principalTable: "Powertrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<byte>(type: "smallint", nullable: false),
                    Components = table.Column<string>(type: "text", nullable: false),
                    MarketMedianUsd = table.Column<decimal>(type: "numeric", nullable: false),
                    MatchSource = table.Column<string>(type: "text", nullable: false),
                    FormulaVersion = table.Column<int>(type: "integer", nullable: false),
                    ComputeAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ListingsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analyses_Listings_ListingsId",
                        column: x => x.ListingsId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_ListingsId",
                table: "Analyses",
                column: "ListingsId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyIssues_GenerationsId",
                table: "BodyIssues",
                column: "GenerationsId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineIssues_EnginesId",
                table: "EngineIssues",
                column: "EnginesId");

            migrationBuilder.CreateIndex(
                name: "IX_Explanations_PowertrainsId",
                table: "Explanations",
                column: "PowertrainsId");

            migrationBuilder.CreateIndex(
                name: "IX_GearboxIssues_GearBoxId",
                table: "GearboxIssues",
                column: "GearBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Generations_ModelsId",
                table: "Generations",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_PowertrainsId",
                table: "Listings",
                column: "PowertrainsId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Powertrains_EngineId",
                table: "Powertrains",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Powertrains_GearBoxId",
                table: "Powertrains",
                column: "GearBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Powertrains_GenerationsId",
                table: "Powertrains",
                column: "GenerationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Powertrains_SuspensionsId",
                table: "Powertrains",
                column: "SuspensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SuspensionsIssues_SuspensionsId",
                table: "SuspensionsIssues",
                column: "SuspensionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analyses");

            migrationBuilder.DropTable(
                name: "BodyIssues");

            migrationBuilder.DropTable(
                name: "EngineIssues");

            migrationBuilder.DropTable(
                name: "Explanations");

            migrationBuilder.DropTable(
                name: "GearboxIssues");

            migrationBuilder.DropTable(
                name: "SuspensionsIssues");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Powertrains");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "GearBoxes");

            migrationBuilder.DropTable(
                name: "Generations");

            migrationBuilder.DropTable(
                name: "Suspensions");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
