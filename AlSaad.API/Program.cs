using AlSaad.API.Extentions;
using AlSaad.Application.Common.Configuration;
using AlSaad.Application.Interfaces.IServices;
using AlSaad.Domain.Entities;
using AlSaad.Infrastructure.ExternalServices.Daftra.DaftraServices;
using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.Services;
using AlSaad.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AlSaadConnection")));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddCors(options =>options.AddPolicy("AllowAngular", policy =>policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();
//services scoped
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();
builder.Services.Configure<DaftraSettings>(builder.Configuration.GetSection("Daftra"));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IRequisitionService, RequisitionService>();
builder.Services.AddScoped<IStockTransactionService, StockTransactionService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IUnitTemplateService, UnitTemplateService>();

///////////////////////////////////////////////
builder.Services.AddDaftraHttpClient<IDaftraProductClient, DaftraProductApiClient>(); 
builder.Services.AddDaftraHttpClient<IDaftraRequisitionClient, DaftraRequisitionClient>(); 
builder.Services.AddDaftraHttpClient<IDaftraProductCategoryClient, DaftraProductCategoryClient>(); 
builder.Services.AddDaftraHttpClient<IDaftraStoreClient,DaftraStoreClient>();
builder.Services.AddDaftraHttpClient<IDaftraStockTransactionClient,DaftraStockTransactionClient>();
builder.Services.AddDaftraHttpClient<IDaftraBrandClient,DaftraBrandClient>();
builder.Services.AddHttpClient<IDaftraUnitTemplateClient, DaftraUnitTemplateClient>((sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<DaftraSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrlV2Entity);   // ⚠️ مختلف عن باقي الموديولات
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("apikey", settings.ApiKey);
});

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
