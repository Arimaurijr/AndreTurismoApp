using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreTurismoAppPackageService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Cadastro_Cidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    Data_Cadastro_Endereco = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressModel_CityModel_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "CityModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ClientModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Data_Cadastro_Cliente = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientModel_AddressModel_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "AddressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HotelModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Data_Cadastro_Hotel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_Hotel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelModel_AddressModel_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "AddressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TicketModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigemId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_Passagem = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketModel_AddressModel_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "AddressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TicketModel_AddressModel_OrigemId",
                        column: x => x.OrigemId,
                        principalTable: "AddressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TicketModel_ClientModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClientModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PackageModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_PacoteId = table.Column<int>(type: "int", nullable: false),
                    Passagem_PacoteId = table.Column<int>(type: "int", nullable: false),
                    Data_Cadastro_Pacote = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_Pacote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cliente_PacoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageModel_ClientModel_Cliente_PacoteId",
                        column: x => x.Cliente_PacoteId,
                        principalTable: "ClientModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PackageModel_HotelModel_Hotel_PacoteId",
                        column: x => x.Hotel_PacoteId,
                        principalTable: "HotelModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PackageModel_TicketModel_Passagem_PacoteId",
                        column: x => x.Passagem_PacoteId,
                        principalTable: "TicketModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressModel_CidadeId",
                table: "AddressModel",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientModel_EnderecoId",
                table: "ClientModel",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelModel_EnderecoId",
                table: "HotelModel",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageModel_Cliente_PacoteId",
                table: "PackageModel",
                column: "Cliente_PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageModel_Hotel_PacoteId",
                table: "PackageModel",
                column: "Hotel_PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageModel_Passagem_PacoteId",
                table: "PackageModel",
                column: "Passagem_PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketModel_ClienteId",
                table: "TicketModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketModel_DestinoId",
                table: "TicketModel",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketModel_OrigemId",
                table: "TicketModel",
                column: "OrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageModel");

            migrationBuilder.DropTable(
                name: "HotelModel");

            migrationBuilder.DropTable(
                name: "TicketModel");

            migrationBuilder.DropTable(
                name: "ClientModel");

            migrationBuilder.DropTable(
                name: "AddressModel");

            migrationBuilder.DropTable(
                name: "CityModel");
        }
    }
}
