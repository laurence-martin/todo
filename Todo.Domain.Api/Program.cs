using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IO.Compression;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
var connectionString = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = "https://securetoken.google.com/todoapi-851dc";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "https://securetoken.google.com/todoapi-851dc",
                ValidAudience = "todoapi-851dc",
                ValidateLifetime = true
            };
        });

// Your web app's Firebase configuration
//const firebaseConfig = {
//  apiKey: "AIzaSyCGwsVcTXIUkTGAR0K4VRMxuTYNKC9moYo",
//  authDomain: "todoapi-851dc.firebaseapp.com",
//  projectId: "todoapi-851dc",
//  storageBucket: "todoapi-851dc.appspot.com",
//  messagingSenderId: "111860655210",
//  appId: "1:111860655210:web:a56cc54cfee5213cae5613"
//};


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adiciona Cache de Mem�ria
builder.Services.AddMemoryCache();
//Adiciona compress�o de dados nas respostas da API
builder.Services.AddResponseCompression(options =>
    options.Providers.Add<GzipCompressionProvider>());

//Configura o n�vel de compress�o
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    options.Level = CompressionLevel.Optimal);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();
//app.UseEndpoints(app => app.MapControllers());
app.MapControllers();
app.Run();
