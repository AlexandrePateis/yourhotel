using Microsoft.EntityFrameworkCore;
using YourHotel.Data;
using YourHotel.Repository;
using YourHotel.Services;
//imports feitos para a parte de autenticacao
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region [Cors]
builder.Services.AddCors();
#endregion

builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<PaymentMethodService>();
builder.Services.AddScoped<PaymentMethodRepository>();
builder.Services.AddScoped<RoomTypeService>();
builder.Services.AddScoped<RoomTypeRepository>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddDbContext<ContextBD>(
  options =>
  //Dizendo que vamos usar o MySQL
  options.UseMySql(
      //Pegando as configurações de acesso ao BD
      builder.Configuration.GetConnectionString("ConexaoBanco"),
      //Detectando o Servidor de BD
      ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
  )
);

//Configurações para usar Autenticação com JWT
var JWTKey = Encoding.ASCII.GetBytes(builder.Configuration["JWTKey"]);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(JWTKey),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region 
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
#endregion
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
