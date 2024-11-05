using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProductOrder.Repos.Interfaces;
using ProductOrder.Repos.Repos;
using ProductOrder.Services.Interfaces;
using ProductOrder.Services.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Khai báo Interface service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductOrderService, ProductOrderService>();
builder.Services.AddScoped<IProductOrderDetailService, ProductOrderDetailService>();
builder.Services.AddScoped<IProductStorageService, ProductStorageService>();
builder.Services.AddScoped<IStorageOrderService, StorageOrderService>();
builder.Services.AddScoped<IStorageOrderDetailService, StorageOrderDetailService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddTransient<IAuthService, AuthService>();

// Khai báo Interface repo
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductOrderRepo, ProductOrderRepo>();
builder.Services.AddScoped<IProductOrderDetailRepo, ProductOrderDetailRepo>();
builder.Services.AddScoped<IProductStorageRepo, ProductStorageRepo>();
builder.Services.AddScoped<IStorageOrderRepo, StorageOrderRepo>();
builder.Services.AddScoped<IStorageOrderDetailRepo, StorageOrderDetailRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IStoreRepo, StoreRepo>();

// Không viết thường các thuộc tính của class:
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("PrivateKey"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});


app.UseAuthorization();

app.MapControllers();

app.Run();
