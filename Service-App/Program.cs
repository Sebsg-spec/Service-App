using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service_App.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
options.AddPolicy("UserPolicy", policy =>
    policy.RequireRole("User"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{

    options.Conventions.AuthorizePage("/Appointment/Create");
    options.Conventions.AuthorizePage("/Appointment/Index", "AdminPolicy");
    options.Conventions.AuthorizePage("/Appointment/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Appointment/Details", "AdminPolicy");
    options.Conventions.AuthorizePage("/Appointment/Delete", "AdminPolicy");

    options.Conventions.AuthorizePage("/Service/Index");
    options.Conventions.AuthorizePage("/Service/Details");
    options.Conventions.AuthorizePage("/Service/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Service/Delete", "AdminPolicy");
    options.Conventions.AuthorizePage("/Service/Create", "AdminPolicy");



    options.Conventions.AuthorizeFolder("/Members");
    options.Conventions.AuthorizeFolder("/AppointmentStats"  );
});
builder.Services.AddDbContext<Service_AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Service_AppContext") ?? throw new InvalidOperationException("Connection string 'Service_AppContext' not found.")));

builder.Services.AddDbContext<ServiceIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Service_AppContext") ?? throw new InvalidOperationException("Connectionstring 'Service_AppContextt' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ServiceIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
