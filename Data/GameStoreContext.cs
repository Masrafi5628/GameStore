using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;
// Dbcontext is an object that stores the session with the database as an intermediary
public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games=>Set<Game>();
    public DbSet<Genre> Genres=>Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new {ID =1, Name = "Race"},
            new {ID =2, Name = "Open-world"},
            new {ID =3, Name = "Arcade"},
            new {ID =4, Name = "Fighting"}
        );
    }

}
