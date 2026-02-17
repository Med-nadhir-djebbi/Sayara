using tpFINAL.Models;
using tpFINAL.Repositories;
using tpFINAL.Services;
using tpFINAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    if (!context.MembershipTypes.Any())
    {
        context.MembershipTypes.AddRange(
            new MembershipType
            {
                Name = "Pay As You Go",
                SignUpFee = 0,
                DurationInMonth = 0,
                DiscountRate = 0
            },
            new MembershipType
            {
                Name = "Monthly",
                SignUpFee = 30,
                DurationInMonth = 1,
                DiscountRate = 10
            },
            new MembershipType
            {
                Name = "Quarterly",
                SignUpFee = 90,
                DurationInMonth = 3,
                DiscountRate = 15
            },
            new MembershipType
            {
                Name = "Annual",
                SignUpFee = 300,
                DurationInMonth = 12,
                DiscountRate = 20
            },
            new MembershipType
            {
                Name = "Premium",
                SignUpFee = 500,
                DurationInMonth = 12,
                DiscountRate = 40
            }
        );
        context.SaveChanges();
    }

    if (!context.Customers.Any())
    {
        context.Customers.AddRange(
            new Customer { Name = "John Doe", MembershipTypeId = 3 },
            new Customer { Name = "Jane Smith", MembershipTypeId = 2 }
        );
        context.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();