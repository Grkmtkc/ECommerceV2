using ECommerce.API.Mapping;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using ECommerce.Data.Context;
using ECommerce.Data.Repository;
using ECommerce.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Ecommerce.Service.Services;
using static ECommerce.Core.Services.IService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ECommerceDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), sqlOptions =>
//    {
//        sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(ECommerceDbContext)).GetName().Name);
//    });
//});

builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);


// Register other services
builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();
builder.Services.AddScoped<ICommunicationsRepository, CommunicationsRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();

builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICommunicationService, CommunicationService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();