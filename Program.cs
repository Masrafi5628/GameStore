using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


List<GameDto> games=[
    new (1,"NFS","Race",500M,new DateOnly(2000,2,10)),
    new (2,"NeoGeo","Arcade",400M,new DateOnly(1997,3,2)),
    new (2,"GTA","Open-World",600M,new DateOnly(2003,12,25))
];


app.MapGet("/", () => "Hello World!");
app.MapGet("games",() => games);
app.Run();


// use f5 for debug