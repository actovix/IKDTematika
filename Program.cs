using IKDTematika.Helpers;
using IKDTematika.Services;
using IKDTematika.Services.Analyser;
using IKDTematika.Services.Parsers;
using IKDTematika.Services.Parsers.PDFParsers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


builder.Services.AddScoped<IAttachmentDownloader,AttachmentDownloader>();
builder.Services.AddScoped<ITextAnalyser, TextAnalyser>();
builder.Services.AddScoped<IParserAccumulator, ParserAccumulator>();
builder.Services.AddScoped<IPDFParser, AnotationParser>();
builder.Services.AddScoped<IPDFParser, RPDParser>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
