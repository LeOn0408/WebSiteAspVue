using Microsoft.EntityFrameworkCore;
using webapi.Data.Dto;
using webapi.Data.Dto.Article;
using webapi.Data.Dto.News;
using webapi.Data.Dto.User;

public class DataContext: DbContext
{
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Section> ArticleType => Set<Section>();
    public DbSet<ImageDto> Images => Set<ImageDto>();
    public DbSet<UserDto> Users => Set<UserDto>();
    public DbSet<UserEntity> UsersEntity => Set<UserEntity>();
    public DbSet<RefreshToken> RefreshToken => Set<RefreshToken>();

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