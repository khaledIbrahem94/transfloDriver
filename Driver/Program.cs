using Domain;
using Microsoft.EntityFrameworkCore;
using DTO.MapProfile;
using AutoMapper;
using InfraStructure;
using Services.Interface;
using Services.Implementation;
using Service.Interface;
using Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson()
               .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             ).AddJsonOptions(opts =>
             {
             }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Cors

string Cors = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(Cors,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

#endregion Cors

#region Dj

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IDriverService, DriverService>();

#endregion Dj

#region DbContext

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); ;

builder.Services.AddDbContext<MainDbContext>(o => o.UseSqlite(connectionString));

using (var context = new MainDbContext())
{
    context.Database.Migrate();
}

#endregion DbContext

#region AutoMapper

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion AutoMapper

var app = builder.Build();

#region Cors

app.UseCors(Cors);

#endregion Cors

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
