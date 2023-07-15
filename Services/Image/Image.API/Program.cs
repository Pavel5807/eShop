using eShop.Services.Image.API.Repositories;
using eShop.Services.Image.API.Settings;
using GrpcImage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("ImageStoreDatabase"));
builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapGrpcService<ImageService>();
app.MapControllers();

app.Run();
