using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;
// Dbcontext is an object that stores the session with the database as an intermediary
public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games=>Set<Game>();
    public DbSet<Genre> Genres=>Set<Genre>();

}
