using TesttaskITExpert.DAL.Extensions;
using TesttaskITExpert.BLL.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.InjectDALServices(builder.Configuration);
builder.Services.InjectBLLServices(builder.Configuration);

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();