using AngleSharp;
using AngleSharp.Html.Parser;
using IKDTematika.Helpers;
using IKDTematika.Services;
using IKDTematika.Services.Analyser;
using IKDTematika.Services.Parsers;
using IKDTematika.Services.Parsers.ISTUParser;
using IKDTematika.Services.Parsers.PDFParsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using parser_template.Parser.Loader;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


builder.Services.AddScoped<IAttachmentDownloader,AttachmentDownloader>();
builder.Services.AddScoped<ITextAnalyser, TextAnalyser>();
builder.Services.AddScoped<IParserAccumulator, ParserAccumulator>();
builder.Services.AddScoped<IPDFParser, AnotationParser>();
builder.Services.AddScoped<IPDFParser, RPDParser>();
builder.Services.AddScoped<IHtmlLoader, HtmlLoader>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run(HandleRequst);
app.Run();
async Task HandleRequst(HttpContext context)
{

    var loader = new HtmlLoader();
    var istuHtml = loader.LoadPageByLink(@"https://istu.ru/sveden/curriculums/3931");
    HtmlParser htmlParser = new();
    var res = await htmlParser.ParseDocumentAsync(istuHtml.Result);
    
    var parser = new ISTUParser();

    var list = parser.Parse(res);


    var sb = new StringBuilder();
    foreach(var e in list)
    {
        sb.AppendLine(e.ToString());
        Console.WriteLine(e.ToString());
    }    

    await context.Response.WriteAsync(sb.ToString());
}