using Microsoft.Extensions.Options;
using Mongo_Net7_Demo.Models;
using Mongo_Net7_Demo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//appsetting den verileri alma islemi
builder.Services.Configure<SchoolDatabaseSettings>(builder.Configuration.GetSection(nameof(SchoolDatabaseSettings)));
//IOptions Pattern Kullanimi
builder.Services.AddSingleton<ISchoolDatabaseSettings>(opt =>
    opt.GetRequiredService<IOptions<SchoolDatabaseSettings>>().Value);

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();

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