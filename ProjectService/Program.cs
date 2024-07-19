using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectService.Data;
using ProjectService.Helpers;
using ProjectService.Interfaces;


var builder = WebApplication.CreateBuilder(args);

/*builder.Configuration.AddEnvironmentVariables(prefix: "OVASITE_");

var conn = new SqlConnectionStringBuilder(
                builder.Configuration.GetConnectionString("AzureDB"));
conn.Password = builder.Configuration.GetSection("DBPassword").Value;

var connString = conn.ConnectionString;*/

// Add services to the container.

/*builder.Services.AddDbContext<DataContext>(options =>
              options.UseSqlServer(connString));*/
builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(
                    builder.Configuration.GetConnectionString("DevelopmentDB"), 
                    p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
/*builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,      // Maximum number of retries
            maxRetryDelay: TimeSpan.FromSeconds(30), // Delay between retries
            errorNumbersToAdd: null);
    });
});*/

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHsts();
app.UseHttpsRedirection();

app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
