using Dataverse.Implementations;
using Dataverse.Interfaces;
using DynamicContext;
using Microsoft.Graph.ExternalConnectors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//git comment
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


builder.Services.AddScoped<IContext, Context>();
builder.Services.AddScoped<IOrganization, Organization>();
builder.Services.AddScoped<IUserSetup, UserSetup>();
builder.Services.AddScoped<IUserActivity, UserActivity>();
builder.Services.AddScoped<ILocation, Location>();
builder.Services.AddScoped<IJob, Job>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Sessions
app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseDeveloperExceptionPage();

app.Run();
