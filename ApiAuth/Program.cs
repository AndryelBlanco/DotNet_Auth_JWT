using ApiAuth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Como fazer para descriptar o Token

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication( x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false; //N�o precisa do HTTPS
    x.SaveToken = true; //Salva o Token, por�m n�o t� persistindo em lugar nenhum
    x.TokenValidationParameters = new TokenValidationParameters 
    {
        ValidateIssuerSigningKey = true, //Validar a chave
        IssuerSigningKey = new SymmetricSecurityKey(key), //Chave usada para validar
        ValidateIssuer = false, //N�o estamos usando
        ValidateAudience = false //N�o estamos usando
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Sempre primeiro Autentica��o e dps Autoriza��o

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
