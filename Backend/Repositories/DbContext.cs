using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    private string _connection;
    public IConfiguration Configuration { get; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
        _connection = Configuration.GetConnectionString("dBConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new DTConfiguration());
        modelBuilder.ApplyConfiguration(new EquipoConfiguration());
        modelBuilder.ApplyConfiguration(new EquipoSofifaConfiguration());
        modelBuilder.ApplyConfiguration(new JugadorConfiguration());
        modelBuilder.ApplyConfiguration(new MercadoConfiguration());
        modelBuilder.ApplyConfiguration(new OfertaConfiguration());
        modelBuilder.ApplyConfiguration(new PartidoConfiguration());
        modelBuilder.ApplyConfiguration(new PrecioConfiguration());
        modelBuilder.ApplyConfiguration(new PrecioEventoConfiguration());
        modelBuilder.ApplyConfiguration(new PremioEventoConfiguration());
        modelBuilder.ApplyConfiguration(new SucesoConfiguration());
        modelBuilder.ApplyConfiguration(new TorneoConfiguration());
        modelBuilder.ApplyConfiguration(new TransferenciaConfiguration());
        modelBuilder.ApplyConfiguration(new OfertaJugadorConfiguration());
        modelBuilder.ApplyConfiguration(new TorneoEquipoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);

    }

    public DbSet<DT> Managers { get; set; }
    public DbSet<Equipo> Equipos { get; set; }
    public DbSet<EquipoSofifa> EquiposSofifa { get; set; }
    public DbSet<Jugador> Jugadores { get; set; }
    public DbSet<Mercado> Mercados { get; set; }
    public DbSet<Oferta> Ofertas { get; set; }
    public DbSet<Partido> Partidos { get; set; }
    public DbSet<PrecioEvento> PreciosEvento { get; set; }
    public DbSet<Precios> Precios { get; set; }
    public DbSet<PremioEvento> PremiosEvento { get; set; }
    public DbSet<Suceso> Sucesos { get; set; }
    public DbSet<Torneo> Torneos { get; set; }
    public DbSet<Transferencia> Transferencias { get; set; }
    public DbSet<OfertaJugador> OfertasJugador { get; set; }
    public DbSet<TorneoEquipo> TorneosEquipos { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<UsuarioRol> UsuariosRoles { get; set; }
    // public DbSet<MasterLog> MasterLogs { get; set; }
}
