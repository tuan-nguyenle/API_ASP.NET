using ASP.Net.Configuration;
using ASP.Net.Data;
using ASP.Net.Services.AuthServices;
using ASP.Net.Services.PermissionServices;
using ASP.Net.Services.ResourceServices;
using ASP.Net.Services.RoleServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnectionStringMSSQL")
    )
);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IResouceService, ResouceService>();

builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:ISSUER"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:AUDIENCE"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:JWT_SECRET"]!)),
            ValidateIssuerSigningKey = true
        };
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
