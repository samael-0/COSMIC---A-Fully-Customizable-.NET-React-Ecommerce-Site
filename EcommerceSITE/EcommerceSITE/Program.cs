using EcommerceSITEDAL.DataAccess;
using EcommerceSITEDAL.Repository;
using EcommerceSITEDAL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductsRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<AdminService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WEBAPI API",
        Version = "v1"
    });

    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    // option.AddSecurityDefinition(
    //     "Code",
    //     new OpenApiSecurityScheme
    //     {
    //         In = ParameterLocation.Header,
    //         Description = "Please enter a code",
    //         Name = "Code",
    //         Type = SecuritySchemeType.ApiKey,
    //         Scheme = "CodeSchema"
    //     }
    // );


    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Standard JWT Authorization header using the Bearer scheme (\"bearer {token}\")",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",

    });

    option.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            //{
            //new OpenApiSecurityScheme
            //    { Reference = new OpenApiReference
            //        {
            //            Type = ReferenceType.SecurityScheme,
            //            Id = "Code"
            //        }
            //}, new string[] { }
            //},

            {
            new OpenApiSecurityScheme
                { Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
            }, new string[] { }
            },
        }
    );

    //option.OrderActionsBy(apiDesc =>
    //{
    //    // Give "login" endpoints a priority prefix, otherwise keep alphabetical order
    //    return apiDesc.RelativePath.Contains("User")
    //        ? "0_" + apiDesc.RelativePath
    //        : "1_" + apiDesc.RelativePath;
    //});

});


builder.Services.AddAuthorization();

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


app.UseStaticFiles();
app.MapControllers();

app.Run();
