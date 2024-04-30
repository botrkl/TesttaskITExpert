using TesttaskITExpert.DAL.Extensions;
using TesttaskITExpert.BLL.Extensions;
using TesttaskITExpert.WebMapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.InjectDALServices(builder.Configuration);
builder.Services.InjectBLLServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(CategoryDTOMapperProfile));
builder.Services.AddAutoMapper(typeof(FilmDTOMapperProfile));

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.Run();