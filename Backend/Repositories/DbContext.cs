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

    public DbSet<DT> Manager { get; set; }
    public DbSet<Equipo> Equipo { get; set; }
    public DbSet<EquipoSofifa> EquipoSofifa { get; set; }
    public DbSet<Jugador> Jugador { get; set; }
    public DbSet<Mercado> Mercado { get; set; }
    public DbSet<Oferta> Oferta { get; set; }
    public DbSet<Partido> Partido { get; set; }
    public DbSet<PrecioEvento> PrecioEvento { get; set; }
    public DbSet<Precios> Precios { get; set; }
    public DbSet<PremioEvento> PremioEvento { get; set; }
    public DbSet<Suceso> Suceso { get; set; }
    public DbSet<Torneo> Torneo { get; set; }
    public DbSet<Transferencia> Transferencia { get; set; }
    public DbSet<OfertaJugador> OfertaJugador { get; set; }
    public DbSet<TorneoEquipo> TorneoEquipo { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }
}
