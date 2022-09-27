using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoLibrary.DataAccess;
using ToDoAPI.StartupConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddHealthCheckServices();
builder.AddAuthServices();
builder.AddStandardServices();
builder.AddCustomServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/health").AllowAnonymous();
app.MapControllers();


app.Run();
