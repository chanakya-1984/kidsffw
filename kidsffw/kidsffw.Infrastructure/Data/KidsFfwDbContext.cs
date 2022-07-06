using kidsffw.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace kidsffw.Infrastructure.Data;

public class KidsFfwDbContext : DbContext
{
    public KidsFfwDbContext(DbContextOptions<KidsFfwDbContext> options) : base(options)
    {
    }
    public DbSet<SalesPartner> SalesPartners { get; set; }
    public DbSet<ReferenceCoupon> ReferenceCoupons { get; set; }
}