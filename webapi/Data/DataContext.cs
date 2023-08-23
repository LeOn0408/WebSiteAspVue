﻿using Microsoft.EntityFrameworkCore;
using webapi.Data.Dto;
using webapi.Data.Dto.News;
using webapi.Data.Dto.User;

public class DataContext: DbContext
{
    public DbSet<NewsDto> News => Set<NewsDto>();
    public DbSet<NewsSectionDto> NewsType => Set<NewsSectionDto>();
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
        base.OnModelCreating(modelBuilder);
    }

}