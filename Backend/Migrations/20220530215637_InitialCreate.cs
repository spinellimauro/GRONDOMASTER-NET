﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    FirstLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPasswordChangedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipoSofifa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    IdSoFifa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoSofifa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrecioEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioEvento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Precios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PremioEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremioEvento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    LimiteAmarillas = table.Column<int>(type: "int", nullable: false),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    NacionalidadCorta = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Posiciones = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Potencial = table.Column<int>(type: "int", nullable: false),
                    IdWeb = table.Column<int>(type: "int", nullable: false),
                    Lesion = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    PrecioVenta = table.Column<double>(type: "float", nullable: false),
                    VecesImpagas = table.Column<int>(type: "int", nullable: false),
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jugador_Equipo_IdEquipo",
                        column: x => x.IdEquipo,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Dinero = table.Column<double>(type: "float", nullable: false),
                    TorneosDisponibles = table.Column<int>(type: "int", nullable: false),
                    Slots = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manager_Equipo_IdEquipo",
                        column: x => x.IdEquipo,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroFecha = table.Column<int>(type: "int", nullable: false),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    IdEquipoLocal = table.Column<int>(type: "int", nullable: false),
                    IdEquipoVisitante = table.Column<int>(type: "int", nullable: false),
                    IdTorneo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partido_Equipo_IdEquipoLocal",
                        column: x => x.IdEquipoLocal,
                        principalTable: "Equipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partido_Equipo_IdEquipoVisitante",
                        column: x => x.IdEquipoVisitante,
                        principalTable: "Equipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partido_Torneo_IdTorneo",
                        column: x => x.IdTorneo,
                        principalTable: "Torneo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TorneoEquipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTorneo = table.Column<int>(type: "int", nullable: false),
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorneoEquipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TorneoEquipo_Equipo_IdEquipo",
                        column: x => x.IdEquipo,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TorneoEquipo_Torneo_IdTorneo",
                        column: x => x.IdTorneo,
                        principalTable: "Torneo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    IdDtOfertante = table.Column<int>(type: "int", nullable: false),
                    IdDtReceptor = table.Column<int>(type: "int", nullable: false),
                    IdMercado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oferta_Manager_IdDtOfertante",
                        column: x => x.IdDtOfertante,
                        principalTable: "Manager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Oferta_Manager_IdDtReceptor",
                        column: x => x.IdDtReceptor,
                        principalTable: "Manager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Oferta_Mercado_IdMercado",
                        column: x => x.IdMercado,
                        principalTable: "Mercado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    IdDTComprador = table.Column<int>(type: "int", nullable: false),
                    IdDTVendedor = table.Column<int>(type: "int", nullable: false),
                    IdJugador = table.Column<int>(type: "int", nullable: false),
                    IdMercado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Jugador_IdJugador",
                        column: x => x.IdJugador,
                        principalTable: "Jugador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transferencia_Manager_IdDTComprador",
                        column: x => x.IdDTComprador,
                        principalTable: "Manager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transferencia_Manager_IdDTVendedor",
                        column: x => x.IdDTVendedor,
                        principalTable: "Manager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transferencia_Mercado_IdMercado",
                        column: x => x.IdMercado,
                        principalTable: "Mercado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suceso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadGoles = table.Column<int>(type: "int", nullable: false),
                    CantidadAmarillas = table.Column<int>(type: "int", nullable: false),
                    CantidadRojas = table.Column<int>(type: "int", nullable: false),
                    IdJugador = table.Column<int>(type: "int", nullable: false),
                    IdPartido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suceso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suceso_Jugador_IdJugador",
                        column: x => x.IdJugador,
                        principalTable: "Jugador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suceso_Partido_IdPartido",
                        column: x => x.IdPartido,
                        principalTable: "Partido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaJugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOferta = table.Column<int>(type: "int", nullable: false),
                    IdJugador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaJugador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfertaJugador_Jugador_IdJugador",
                        column: x => x.IdJugador,
                        principalTable: "Jugador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaJugador_Oferta_IdOferta",
                        column: x => x.IdOferta,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_IdEquipo",
                table: "Jugador",
                column: "IdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_IdEquipo",
                table: "Manager",
                column: "IdEquipo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manager_UserId",
                table: "Manager",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdDtOfertante",
                table: "Oferta",
                column: "IdDtOfertante");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdDtReceptor",
                table: "Oferta",
                column: "IdDtReceptor");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdMercado",
                table: "Oferta",
                column: "IdMercado");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaJugador_IdJugador",
                table: "OfertaJugador",
                column: "IdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaJugador_IdOferta",
                table: "OfertaJugador",
                column: "IdOferta");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_IdEquipoLocal",
                table: "Partido",
                column: "IdEquipoLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_IdEquipoVisitante",
                table: "Partido",
                column: "IdEquipoVisitante");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_IdTorneo",
                table: "Partido",
                column: "IdTorneo");

            migrationBuilder.CreateIndex(
                name: "IX_Suceso_IdJugador",
                table: "Suceso",
                column: "IdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_Suceso_IdPartido",
                table: "Suceso",
                column: "IdPartido");

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipo_IdEquipo",
                table: "TorneoEquipo",
                column: "IdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipo_IdTorneo",
                table: "TorneoEquipo",
                column: "IdTorneo");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdDTComprador",
                table: "Transferencia",
                column: "IdDTComprador");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdDTVendedor",
                table: "Transferencia",
                column: "IdDTVendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdJugador",
                table: "Transferencia",
                column: "IdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdMercado",
                table: "Transferencia",
                column: "IdMercado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EquipoSofifa");

            migrationBuilder.DropTable(
                name: "OfertaJugador");

            migrationBuilder.DropTable(
                name: "PrecioEvento");

            migrationBuilder.DropTable(
                name: "Precios");

            migrationBuilder.DropTable(
                name: "PremioEvento");

            migrationBuilder.DropTable(
                name: "Suceso");

            migrationBuilder.DropTable(
                name: "TorneoEquipo");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Mercado");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Equipo");
        }
    }
}
