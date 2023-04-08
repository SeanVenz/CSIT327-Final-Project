using CoffeeShopAPI.Context;
using CoffeeShopAPI.Repositories;
using CoffeeShopAPI.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //Add header documentation in swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Coffee Shop API",
        Description = "Your online Coffee Shop Solution",
        Contact = new OpenApiContact
        {
            Name = "Adrian Jay Barcenilla",
            Url = new Uri("https://www.facebook.com/adrianjayyyy")
        }
    });
    //Feed generated xml api docs to swagger
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});



//Configure our services
ConfigureServices(builder.Services);

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

void ConfigureServices(IServiceCollection services)
{
    //configure AutoMapper
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    //Create instance of DapperContext everytime
    services.AddTransient<DapperContext>();

    //Services
    services.AddScoped<ICustomerService, CustomerService>();
    services.AddScoped<ICustomerPreferenceService, CustomerPreferenceService>();
    services.AddScoped<IPreferenceService, PreferenceService>();
    services.AddScoped<ICommentService, CommentService>();
    services.AddScoped<IPaymentService, PaymentService>();
    services.AddScoped<IOrderService, OrderService>();
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IBaristaService, BaristaService>();

    //Repos
    services.AddScoped<ICustomerRepository, CustomerRepository>();
    services.AddScoped<ICustomerPreferenceRepository, CustomerPreferenceRepository>();
    services.AddScoped<ICommentRepository, CommentRepository>();
    services.AddScoped<IPaymentRepository, PaymentRepository>();
    services.AddScoped<IOrderRepository, OrderRepository>();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IBaristaRepository, BaristaRepository>();
}