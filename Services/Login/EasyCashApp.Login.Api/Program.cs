using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Business.Service;
using EasyCashApp.SharedClasses.Database.AppContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EasyCashAppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL"));
});
builder.Services.AddScoped<IService_Login,Service_Login>();
builder.Services.AddScoped<IService_Register,Service_Register>();
builder.Services.AddScoped<IService_ResetPassword,Service_ResetPassword>();
builder.Services.AddScoped<IService_GetUserDetail,Service_GetUserDetail>();
builder.Services.AddScoped<IService_DeleteUser,Service_DeleteUser>();
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
