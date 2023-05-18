using ExperimentTask.Context;
using ExperimentTask.Service.Implements;
using ExperimentTask.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers().AddJsonOptions(options=>options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExperimentService, ExperimentService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddDbContext<ExperimentContext>(s => s.UseSqlServer(builder.Configuration["ConnectionStrings:Connection"]));

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();



app.Run();
