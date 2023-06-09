using System.Collections.Immutable;
using TourOfHeroesCore.Configuration;
using TourOfHeroesCore.Event;
using TourOfHeroesCore.Event.HeroEvent;
using TourOfHeroesCore.Event.PaperEvent;
using TourOfHeroesCore.Impl;
using TourOfHeroesCore.Impl.Helpers;
using TourOfHeroesCore.Interfaces;
using TourOfHeroesCore.Interfaces.Helpers;
using TourOfHeroesCore.Interfaces.Repository;
using TourOfHeroesRepository.Repository.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions<DatabaseInfoOptions>().BindConfiguration("DatabaseInfo");
builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddSingleton<IHeroRepository, HeroRepository>();
builder.Services.AddSingleton<IPaperRepository, PaperRepository>();
builder.Services.AddSingleton<IHeroService, HeroService>();
builder.Services.AddSingleton<IPaperService, PaperService>();
builder.Services.AddSingleton<IReaderNotifier<HeroEventArgs>, ReaderNotifierHero>();
builder.Services.AddSingleton<IReaderNotifier<PaperEventArgs>, ReaderPaperNotifier>();
builder.Services.AddSingleton<IEventHandler, HeroEventHandlers>();
builder.Services.AddSingleton<IEventHandler, PaperEventHandlers>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors((policy) =>
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.WithOrigins("http://localhost:3000");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



var bus = app.Services.GetService<IEventBus>();
var handlers = app.Services.GetServices<IEventHandler>();

handlers.ToList().ForEach(handler => bus.Subscribe(handler));


app.Run();
