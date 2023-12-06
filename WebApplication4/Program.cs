using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Repositories.Abstract;
using WebApplication4.Repositories.Concrete;
using WebApplication4.Services.Abstract;
using WebApplication4.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IOrderService,OrderService>();


var conn = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<ProductTaskDbcontext>(opt =>
{
    opt.UseSqlServer(conn);
});


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
