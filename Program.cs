using ProductOrder.Repos.Interfaces;
using ProductOrder.Repos.Repos;
using ProductOrder.Services.Interfaces;
using ProductOrder.Services.Services;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
