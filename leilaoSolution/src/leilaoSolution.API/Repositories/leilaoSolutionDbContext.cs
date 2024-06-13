using leilaoSolution.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace leilaoSolution.API.Repositories;

public class leilaoSolutionDbContext: DbContext
{
    public leilaoSolutionDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
