using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.FlashcardServices;
using QuranBuddyAPI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Add services to the container.

//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuranDBContext>(
    dbContextOptions => dbContextOptions.UseLazyLoadingProxies().UseSqlite(
        builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IChapterService, ChapterService>();
builder.Services.AddScoped<ChapterService>();

builder.Services.AddScoped<IVerseService, VerseService>();
builder.Services.AddScoped<VerseService>();

builder.Services.AddScoped<IServiceFactory, ServiceFactory>();
builder.Services.AddScoped<DefaultFlashcardService>(); 
builder.Services.AddScoped<QuranFlashcardService>();

builder.Services.AddScoped<IFlashcardSetService, FlashcardSetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
