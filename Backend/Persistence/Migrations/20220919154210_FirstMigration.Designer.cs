﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220919154210_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.4.22229.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("FirstLogin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FirstLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastPasswordChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<double>("Dinero")
                        .HasColumnType("float");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEquipo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("Slots")
                        .HasColumnType("int");

                    b.Property<int>("TorneosDisponibles")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipo")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EquipoSoFifaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.HasIndex("EquipoSoFifaId")
                        .IsUnique();

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("EquipoSofifa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdSoFifa")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("EquiposSofifa");
                });

            modelBuilder.Entity("Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("IdEquipo")
                        .HasColumnType("int");

                    b.Property<int>("IdWeb")
                        .HasColumnType("int");

                    b.Property<int>("Lesion")
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("NacionalidadCorta")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Posiciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Potencial")
                        .HasColumnType("int");

                    b.Property<double>("PrecioVenta")
                        .HasColumnType("float");

                    b.Property<int>("VecesImpagas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipo");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("Mercado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Mercados");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdDtOfertante")
                        .HasColumnType("int");

                    b.Property<int>("IdDtReceptor")
                        .HasColumnType("int");

                    b.Property<int>("IdMercado")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdDtOfertante");

                    b.HasIndex("IdDtReceptor");

                    b.HasIndex("IdMercado");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("OfertaJugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdJugador")
                        .HasColumnType("int");

                    b.Property<int>("IdOferta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdJugador");

                    b.HasIndex("IdOferta");

                    b.ToTable("OfertasJugador");
                });

            modelBuilder.Entity("Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<int>("IdEquipoLocal")
                        .HasColumnType("int");

                    b.Property<int>("IdEquipoVisitante")
                        .HasColumnType("int");

                    b.Property<int>("IdTorneo")
                        .HasColumnType("int");

                    b.Property<int>("NroFecha")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipoLocal");

                    b.HasIndex("IdEquipoVisitante");

                    b.HasIndex("IdTorneo");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("PrecioEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NombreEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("PreciosEvento");
                });

            modelBuilder.Entity("Precios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Precios");
                });

            modelBuilder.Entity("PremioEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<string>("NombreEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("PremiosEvento");
                });

            modelBuilder.Entity("Suceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadAmarillas")
                        .HasColumnType("int");

                    b.Property<int>("CantidadGoles")
                        .HasColumnType("int");

                    b.Property<int>("CantidadRojas")
                        .HasColumnType("int");

                    b.Property<int>("IdJugador")
                        .HasColumnType("int");

                    b.Property<int>("IdPartido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdJugador");

                    b.HasIndex("IdPartido");

                    b.ToTable("Sucesos");
                });

            modelBuilder.Entity("Torneo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<int>("LimiteAmarillas")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Torneos");
                });

            modelBuilder.Entity("TorneoEquipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdEquipo")
                        .HasColumnType("int");

                    b.Property<int>("IdTorneo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipo");

                    b.HasIndex("IdTorneo");

                    b.ToTable("TorneosEquipos");
                });

            modelBuilder.Entity("Transferencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdDTComprador")
                        .HasColumnType("int");

                    b.Property<int>("IdDTVendedor")
                        .HasColumnType("int");

                    b.Property<int>("IdJugador")
                        .HasColumnType("int");

                    b.Property<int>("IdMercado")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdDTComprador");

                    b.HasIndex("IdDTVendedor");

                    b.HasIndex("IdJugador");

                    b.HasIndex("IdMercado");

                    b.ToTable("Transferencias");
                });

            modelBuilder.Entity("UsuarioRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosRoles");
                });

            modelBuilder.Entity("DT", b =>
                {
                    b.HasOne("Equipo", "Equipo")
                        .WithOne("DT")
                        .HasForeignKey("DT", "IdEquipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUser", "User")
                        .WithOne("Usuario")
                        .HasForeignKey("DT", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Equipo", b =>
                {
                    b.HasOne("EquipoSofifa", "EquipoSofifa")
                        .WithOne("Equipo")
                        .HasForeignKey("Equipo", "EquipoSoFifaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipoSofifa");
                });

            modelBuilder.Entity("Jugador", b =>
                {
                    b.HasOne("Equipo", "Equipo")
                        .WithMany("Jugadores")
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Oferta", b =>
                {
                    b.HasOne("DT", "DtOfertante")
                        .WithMany("OfertasRealizadas")
                        .HasForeignKey("IdDtOfertante")
                        .IsRequired();

                    b.HasOne("DT", "DtReceptor")
                        .WithMany("OfertasRecibidas")
                        .HasForeignKey("IdDtReceptor")
                        .IsRequired();

                    b.HasOne("Mercado", "Mercado")
                        .WithMany("listaOfertas")
                        .HasForeignKey("IdMercado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DtOfertante");

                    b.Navigation("DtReceptor");

                    b.Navigation("Mercado");
                });

            modelBuilder.Entity("OfertaJugador", b =>
                {
                    b.HasOne("Jugador", "Jugador")
                        .WithMany("OfertasJugador")
                        .HasForeignKey("IdJugador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oferta", "Oferta")
                        .WithMany("OfertasJugador")
                        .HasForeignKey("IdOferta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jugador");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("Partido", b =>
                {
                    b.HasOne("Equipo", "EquipoLocal")
                        .WithMany("PartidosJugadosLocal")
                        .HasForeignKey("IdEquipoLocal")
                        .IsRequired();

                    b.HasOne("Equipo", "EquipoVisitante")
                        .WithMany("PartidosJugadosVisitante")
                        .HasForeignKey("IdEquipoVisitante")
                        .IsRequired();

                    b.HasOne("Torneo", "Torneo")
                        .WithMany("Partidos")
                        .HasForeignKey("IdTorneo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipoLocal");

                    b.Navigation("EquipoVisitante");

                    b.Navigation("Torneo");
                });

            modelBuilder.Entity("Suceso", b =>
                {
                    b.HasOne("Jugador", "Jugador")
                        .WithMany("Sucesos")
                        .HasForeignKey("IdJugador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Partido", "Partido")
                        .WithMany("Sucesos")
                        .HasForeignKey("IdPartido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jugador");

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("TorneoEquipo", b =>
                {
                    b.HasOne("Equipo", "Equipo")
                        .WithMany("TorneosEquipos")
                        .HasForeignKey("IdEquipo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Torneo", "Torneo")
                        .WithMany("TorneosEquipos")
                        .HasForeignKey("IdTorneo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Equipo");

                    b.Navigation("Torneo");
                });

            modelBuilder.Entity("Transferencia", b =>
                {
                    b.HasOne("DT", "DtComprador")
                        .WithMany("Compras")
                        .HasForeignKey("IdDTComprador")
                        .IsRequired();

                    b.HasOne("DT", "DtVendedor")
                        .WithMany("Ventas")
                        .HasForeignKey("IdDTVendedor")
                        .IsRequired();

                    b.HasOne("Jugador", "Jugador")
                        .WithMany("Transferencias")
                        .HasForeignKey("IdJugador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mercado", "Mercado")
                        .WithMany("listaTransferencias")
                        .HasForeignKey("IdMercado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DtComprador");

                    b.Navigation("DtVendedor");

                    b.Navigation("Jugador");

                    b.Navigation("Mercado");
                });

            modelBuilder.Entity("UsuarioRol", b =>
                {
                    b.HasOne("ApplicationRole", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DT", "Usuario")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("DT", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("OfertasRealizadas");

                    b.Navigation("OfertasRecibidas");

                    b.Navigation("UsuariosRoles");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Equipo", b =>
                {
                    b.Navigation("DT");

                    b.Navigation("Jugadores");

                    b.Navigation("PartidosJugadosLocal");

                    b.Navigation("PartidosJugadosVisitante");

                    b.Navigation("TorneosEquipos");
                });

            modelBuilder.Entity("EquipoSofifa", b =>
                {
                    b.Navigation("Equipo")
                        .IsRequired();
                });

            modelBuilder.Entity("Jugador", b =>
                {
                    b.Navigation("OfertasJugador");

                    b.Navigation("Sucesos");

                    b.Navigation("Transferencias");
                });

            modelBuilder.Entity("Mercado", b =>
                {
                    b.Navigation("listaOfertas");

                    b.Navigation("listaTransferencias");
                });

            modelBuilder.Entity("Oferta", b =>
                {
                    b.Navigation("OfertasJugador");
                });

            modelBuilder.Entity("Partido", b =>
                {
                    b.Navigation("Sucesos");
                });

            modelBuilder.Entity("Torneo", b =>
                {
                    b.Navigation("Partidos");

                    b.Navigation("TorneosEquipos");
                });
#pragma warning restore 612, 618
        }
    }
}
