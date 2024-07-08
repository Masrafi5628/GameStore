var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


// use f5 for debug