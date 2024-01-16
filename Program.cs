using Microsoft.EntityFrameworkCore;
using PrescriptionManagementAPI.Data;
using PrescriptionManagementAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PrescriptionManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PrescriptionManagementDB")));
builder.Services.AddScoped<MedicineService>();
// JWT Authentication Setup
var keyString = "SuperSuperSuperSuperGizliGizliGizliGizliUzunUzunUzunUzuuuunKey";
var keyByteArray = Encoding.ASCII.GetBytes(keyString);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyByteArray),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSingleton(new TokenService(keyString));

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

app.MapControllers();

app.Run();
