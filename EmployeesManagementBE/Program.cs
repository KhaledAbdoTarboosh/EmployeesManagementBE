
using EmployeesManagementBE.Configurations;
using EmployeesManagementBE.Models.Identity;
using EmployeesManagementBE.Repositories.Base;
using EmployeesManagementBE.Repositories.JWT;
using EmployeesManagementBE.Repositories.JWTTokens;
using EmployeesManagementBE.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;


var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();


var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
.CreateLogger();
//.WriteTo.Console()
//.MinimumLevel.Information()
//.CreateLogger();


builder.Logging.ClearProviders();
Log.Logger = logger;
builder.Logging.AddSerilog(logger);
builder.Host.UseSerilog();

builder.Services.AddDbContext<EmployeesManagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesManagementConnectionString"),
b => b.MigrationsAssembly(typeof(EmployeesManagementContext).Assembly.FullName)));



builder.Services.AddDbContext<AuthContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesManagementAuthConnectionString"),
b => b.MigrationsAssembly(typeof(AuthContext).Assembly.FullName)));


builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("")
    .AddEntityFrameworkStores<AuthContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
});

builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee Management APIs",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policybuilder => policybuilder
        .WithOrigins( builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
    .AllowAnyMethod()
    .AllowAnyHeader());
});


builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IBaseRepositoy<Employee>, BaseRepositoy<Employee>>();
builder.Services.AddTransient<UserManager<IdentityUser>>();
builder.Services.AddTransient<SignInManager<IdentityUser>>();




builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["jwt:key"])),
        ValidIssuer = builder.Configuration["jwt:Issuer"],
        ValidAudience = builder.Configuration["jwt:Audience"],

    };
});

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("MyCorsPolicy");
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
