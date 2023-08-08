using TasksAPI.Application.Extensions;
using TasksAPI.Data.Extensions;
using TasksAPI.Messages.Extensions;
using TasksAPI.Services.Extensions;
using TasksAPI.Services.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddCorsPolicy();
builder.Services.AddServices();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddRabbitMQ(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddJwtBearer(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwaggerDoc();
app.UseCorsPolicy();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
