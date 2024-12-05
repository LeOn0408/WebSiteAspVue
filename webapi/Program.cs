using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webapi.Services;
using webapi.Services.Blog;
using webapi.Services.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var authOption = new AuthOptions(builder.Configuration);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // указывает, будет ли валидироваться издатель при валидации токена
        ValidateIssuer = true,
        // строка, представляющая издателя
        ValidIssuer = authOption.Issuer,
        // будет ли валидироваться потребитель токена
        ValidateAudience = true,
        // установка потребителя токена
        ValidAudience = authOption.Audience,
        // будет ли валидироваться время существования
        ValidateLifetime = true,
        // установка ключа безопасности
        IssuerSigningKey = authOption.GetSymmetricSecurityKey(),
        // валидация ключа безопасности
        ValidateIssuerSigningKey = true,
    };
});
builder.Services.AddAuthorization();

builder.Services.AddMapster();

builder.Services.AddTransient<
    IBlogService, BlogService>();
builder.Services.AddTransient<
    IUserService, UserService>(); 
builder.Services.AddTransient<
    AuthenticateService>();

builder.Services.AddCors();



string connection = builder.Configuration.GetConnectionString("DefaultConnection");

ServerVersion version = ServerVersion.AutoDetect(connection);
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connection, version,
    mySqlOptions =>
    {
        mySqlOptions.EnableRetryOnFailure(
        maxRetryCount: 1,
        maxRetryDelay: TimeSpan.FromSeconds(5),
        errorNumbersToAdd: null);
    }));


var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
        .WithOrigins("https://localhost:5173")
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader());
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
