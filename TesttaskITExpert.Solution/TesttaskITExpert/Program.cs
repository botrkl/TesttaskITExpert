using TesttaskITExpert.DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InjectDALServices(builder.Configuration);

var app = builder.Build();

app.Run();