using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
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
        modelBuilder.ApplyConfiguration(new TransferenciaConfiguration());
        modelBuilder.ApplyConfiguration(new OfertaConfiguration());

        base.OnModelCreating(modelBuilder);

    }

    // public DbSet<Contact> Contacts { get; set; }
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
}
