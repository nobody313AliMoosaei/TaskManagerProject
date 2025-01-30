using Microsoft.EntityFrameworkCore;
using TaskManagerRoom308.Data.Database;
using TaskManagerRoom308.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Application_dbContext>(option =>
{
    option.UseSqlServer("server=62.204.61.143; Initial Catalog=docraja1_A.akhlaghi; User ID = docraja1_akhlaghi; Password = lGN$eH01n#9e2X;TrustServerCertificate=True; MultiSubnetFailover=True;");
});
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<TaskService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
