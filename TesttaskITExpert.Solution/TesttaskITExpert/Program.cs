using TesttaskITExpert.DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.InjectDALServices(builder.Configuration);

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();