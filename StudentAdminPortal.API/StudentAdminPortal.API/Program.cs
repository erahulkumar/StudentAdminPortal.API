using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Congufiguration of Db Connection
builder.Services.AddDbContext<StudentAdminDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString
        ("StudentAdminPortalStrings"));
});
//Configuration to all interface and implementations
builder.Services.AddScoped<IStudentRepository, SqlStudentRepository>();
// permission to used server hits only angular
builder.Services.AddCors((options) =>
{
    options.AddPolicy("angularApplication", (Permitserver) =>
    {
        Permitserver.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

//angular

app.UseCors("angularApplication");

app.UseAuthorization();

app.MapControllers();

app.Run();
