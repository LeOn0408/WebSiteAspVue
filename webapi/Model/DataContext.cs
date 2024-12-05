using Microsoft.EntityFrameworkCore;
using webapi.Model;
using webapi.Model.Blog;
using webapi.Model.Entities;

public class DataContext: DbContext
{
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Section> ArticleType => Set<Section>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<RefreshTokenEntity> RefreshToken => Set<RefreshTokenEntity>();

    private readonly IConfiguration _configuration;
    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Article>()
            .HasMany(a => a.Tags)
            .WithMany(t => t.Articles)
            .UsingEntity<ArticleTags>(
               j => j
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ArticleTags)
                .HasForeignKey(pt => pt.TagId),
            j => j
                .HasOne(pt => pt.Article)
                .WithMany(p => p.ArticleTags)
                .HasForeignKey(pt => pt.ArticleId),
            j =>
            {
                j.HasKey(t => new { t.ArticleId, t.TagId });
                j.ToTable("ap_article_tag_relation");
            });
        base.OnModelCreating(modelBuilder);
    }

}