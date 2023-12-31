using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// Add ForwardedHeaders middleware to handle headers from proxies/load balancers.
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
  options.ForwardedHeaders = ForwardedHeaders.All;
});

// Add HeaderPropagation middleware to propagate all headers to outgoing requests.
builder.Services.AddHeaderPropagation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use the HeaderPropagation middleware to propagate all headers.
app.UseHeaderPropagation();

app.UseAuthorization();

app.MapControllers();

app.Run();
