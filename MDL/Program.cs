using MDL.DB;
using MDL.Interfaces;
using MDL.Models;
using MDL.Options;
using MDL.Repositories;
using MDL.Tools;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MDLContext>(option => option.UseSqlServer(connection));
builder.Services.AddTransient<IRepository<Mail>, MailRepository>();
builder.Services.AddTransient<IMailManager, MailManager>();

builder.Services.Configure<SmtpServerOptions>(builder.Configuration.GetSection(SmtpServerOptions.SmtpServer));

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
