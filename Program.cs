
using API_Kokak.Interface;
using API_Kokak.Repository;
using API_Kokak.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.SetIsOriginAllowed(_ => true)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Map the SignalR hub to its endpoint path.
    endpoints.MapHub<ChatHub>("/chathub");
});

app.Run();
