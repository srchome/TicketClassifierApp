using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TicketClassifierApp.Data;
using TicketClassifierApp.ML.MLModels;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//to check AddDefaultIdentity was not working
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Train on startup (we can later move this to admin API)
//TicketClassifierApp.ML.MLModels.ModelBuilder.Train("training_data.csv");
//var dataPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "training_data.csv");
//TicketClassifierApp.ML.MLModels.ModelBuilder.Train(dataPath);


app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ticket}/{action=Index}/{id?}");


app.Run();


