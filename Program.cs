using IKDTematika;
using IKDTematika.Filler;
using IKDTematika.ThemeSelector;

var builder = WebApplication.CreateBuilder(args);

var ld = new LinkedDisciplines("Data/linkedDisciplines.json");
var ai = new AIThemeSelector();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(ld);
builder.Services.AddSingleton(ai);
builder.Services.AddScoped<ISelector, SubjThemeSelector>();
builder.Services.AddScoped<IFiller, ThemeFiller>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
