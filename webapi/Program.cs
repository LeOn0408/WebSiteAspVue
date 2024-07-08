using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webapi.Data;
using webapi.Data.Blog;
using webapi.Data.Dto.News;
using webapi.Data.User;
using webapi.Filter;

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
        // ���������, ����� �� �������������� �������� ��� ��������� ������
        ValidateIssuer = true,
        // ������, �������������� ��������
        ValidIssuer = authOption.Issuer,
        // ����� �� �������������� ����������� ������
        ValidateAudience = true,
        // ��������� ����������� ������
        ValidAudience = authOption.Audience,
        // ����� �� �������������� ����� �������������
        ValidateLifetime = true,
        // ��������� ����� ������������
        IssuerSigningKey = authOption.GetSymmetricSecurityKey(),
        // ��������� ����� ������������
        ValidateIssuerSigningKey = true,
    };
});
builder.Services.AddAuthorization();

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
