using FBN.SecBank.Api.Accounts.Services;
using FBN.SecBank.Api.Accounts.Services.Iml;
using FBN.SecBank.Api.Data;
using FBN.SecBank.Api.Requests.RequestService.Impl;
using FBN.SecBank.Api.Requests.RequestService;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using FBN.SecBank.Api.Customers.Services;
using FBN.SecBank.Api.Customers.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SectBankContext>
(options => options.UseMySql(builder.Configuration.GetConnectionString("conc"), new MySqlServerVersion(new Version())));

//Acccounts
builder.Services.AddScoped<IDeleteAccount, DeleteAccountService>();
builder.Services.AddScoped<IAddAccount, AddAccountService>();
builder.Services.AddScoped<IUpdateAccount, UpdateAccountService>();
builder.Services.AddScoped<IGetAccount, GetAccountService>();
builder.Services.AddScoped<IEditAccounts, EditAccountService>();
builder.Services.AddScoped<IRequestServices, RequestServices>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

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
