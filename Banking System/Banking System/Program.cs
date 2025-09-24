using BankingSystem.Application;
using BankingSystem.Application.DTO_Validators;
using BankingSystem.Application.Interfaces.Accounts;
using BankingSystem.Application.Interfaces.Users;
using BankingSystem.Application.Services;
using BankingSystem.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BankingSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"),
        
        providerOptions=> providerOptions.EnableRetryOnFailure());
});


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();



builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAccountDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DepositeDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<WithdrawDtoValidator>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("My API");
        options.WithTheme(ScalarTheme.BluePlanet);
        options.WithSidebar(true);
    });

    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
