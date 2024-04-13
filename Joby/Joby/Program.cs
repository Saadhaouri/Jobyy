using Infrastructure.Repositories;
using Joby.Core.Application.Interfaces.IServices;
using Joby.Domain.Models;
using Joby.Infrastructure.Data;
using Joby.Infrastructure.Repositories;
using Jobyy.Core.Application.Interfaces.IRepository;
using Jobyy.Core.Application.Interfaces.IServices;
using Jobyy.Core.Application.Services;
using JObyy.Core.Application.Interfaces.IRepository;
using JObyy.Core.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<JobyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection") ??
        throw new InvalidOperationException("Connection string is not found ")
   ));


//Identity 

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<JobyDbContext>()
    .AddDefaultTokenProviders();
// Add Identity & JWT authnetication  

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


}) 
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });





builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOpportunityRepository, OpportunityRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IReactRepository, ReactRepository>();


builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOpportunityService, OpportunityService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IReactService, ReactService>();  




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



//authentication configure 
//builder.Services.AddIdentityCore<IdentityUser>()
//    .AddEntityFrameworkStores<JobyDbContext>()
//    .AddApiEndpoints();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Add authentication to swagger UI  
builder.Services.AddSwaggerGen();




builder.Services.ConfigureApplicationCookie(options =>
{
    // cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/identity/account/login";
    options.AccessDeniedPath = "/identity/account/accessdenied";
    options.SlidingExpiration = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGroup("/identity");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowLocalhost");


app.MapControllers();


app.Run();

