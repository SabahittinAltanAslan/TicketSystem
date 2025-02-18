using IyasBilgiIslem.Data.Context;
using IyasBilgiIslem.Data.Repositories;
using IyasBilgiIslem.Business.Services;
using IyasBilgiIslem.Business.Validations;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;
using IyasBilgiIslem.Business.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 📌 FluentValidation Servislerini Doğru Şekilde Ekleyelim
builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<TicketValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<UserValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<DeviceValidator>();
    });

// 📌 Swagger Yapılandırması
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Iyas Bilgi İşlem API",
        Version = "v1",
        Description = "İyaş Bilgi İşlem için Ticket ve Cihaz Yönetim Sistemi"
    });

    // 📌 JWT Desteği İçin Swagger Yapılandırması
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Token'ınızı aşağıdaki kutuya girin. (Örnek: Bearer {token})"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// 📌 JWT Authentication Middleware 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

// 📌 FluentValidation Validatorlarını Tanımla
builder.Services.AddScoped<IValidator<Ticket>, TicketValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Device>, DeviceValidator>();
builder.Services.AddScoped<IAuthService, AuthService>();

// 📌 Veritabanı Bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 📌 Generic Repository Servisini Tanımla
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

// 📌 Repository Servislerini Ekle
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IStatusLogRepository, StatusLogRepository>();
builder.Services.AddScoped<IRepository<Branch>, GenericRepository<Branch>>(); // 📌 Branch repository ekleme
builder.Services.AddScoped<UnitOfWork>();

// 📌 Business Layer Servislerini Ekle
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IBranchService, BranchService>(); // 📌 Branch servisini ekleme


// 📌 CORS Ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// 📌 Swagger'ı sadece development ortamında değil, her zaman çalıştır
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
