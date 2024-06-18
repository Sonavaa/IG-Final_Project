using Instagram.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Instagram.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Saved> Saveds { get; set; }
    public DbSet<Follower> Followers { get; set; }
    public DbSet<Following> Followings { get; set; }
    public DbSet<MyDirect> MyDirects { get; set; }
    public DbSet<Message> Messages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Following>()
               .HasKey(f => new { f.UserId, f.UserFollowingId });

        modelBuilder.Entity<Following>()
                .HasOne(f => f.User)
                .WithMany(u => u.Followings)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Follower>()
            .HasKey(f => new { f.UserId, f.UserFollowerId });

        modelBuilder.Entity<Follower>()
               .HasOne(f => f.User)
               .WithMany(u => u.Followers)
               .HasForeignKey(f => f.UserId)
               .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<MyDirect>()
                       .HasOne(d => d.AppUser)
                       .WithMany(u => u.Directs)
                       .HasForeignKey(d => d.AppUserId)
                       .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MyDirect>()
            .HasOne(d => d.TheOtherWriter)
            .WithMany()
            .HasForeignKey(d => d.TheOtherWriterId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MyDirect>()
            .HasMany(d => d.AllMessages)
            .WithOne(m => m.Direct)
            .HasForeignKey(m => m.DirectId)
            .OnDelete(DeleteBehavior.Cascade);

    }

}

