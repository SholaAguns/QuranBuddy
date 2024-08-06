using Microsoft.EntityFrameworkCore;
using QuranBuddyAPI.Contexts;
using QuranBuddyAPI.FlashcardServices;
using QuranBuddyAPI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuranDBContext>(
    dbContextOptions => dbContextOptions.UseLazyLoadingProxies().UseSqlite(
        builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<IChapterService, ChapterService>();
builder.Services.AddScoped<ChapterService>();

builder.Services.AddScoped<IVerseService, VerseService>();
builder.Services.AddScoped<VerseService>();

builder.Services.AddScoped<IServiceFactory, ServiceFactory>();
builder.Services.AddScoped<DefaultFlashcardService>();
builder.Services.AddScoped<QuranFlashcardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
