using Microsoft.EntityFrameworkCore;
using YourHotel.Data;
using YourHotel.Repository;
using YourHotel.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region [Cors]
builder.Services.AddCors();
#endregion
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ClientRepository>();
//Adicionando a minha classe de contexto na API
//Tem que acrescentar using Microsoft.EntityFrameworkCore;
//using using IFBeaty.Data;
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
app.UseCors(c=>{
  c.AllowAnyHeader();
  c.AllowAnyMethod();
  c.AllowAnyOrigin();
});
#endregion
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
