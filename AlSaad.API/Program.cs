using AlSaad.Application.Common.Configuration;
using AlSaad.Application.Interfaces.IServices;
using AlSaad.Domain.Entities;
using AlSaad.Infrastructure.Services;
using AlSaad.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AlSaadConnection")));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddCors(options =>options.AddPolicy("AllowAngular", policy =>policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
//repo scoped
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();
//services scoped
builder.Services.AddScoped<IAuthenticationService,AuthenticationService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
