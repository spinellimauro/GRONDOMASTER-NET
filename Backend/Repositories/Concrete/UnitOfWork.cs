using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext db;

    public UnitOfWork(ApplicationDbContext db)
    {
        this.db = db;
    }

    public Task<int> CompleteAsync()
    {
        return db.SaveChangesAsync();
    }

}