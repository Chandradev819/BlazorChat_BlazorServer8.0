using BlazorChat.BlazorChat;
using BlazorChat.Components;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Step 1 Start
builder.Services.AddSignalR(opts =>
         opts.EnableDetailedErrors = true
    );
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        ["application/octet-stream"]);
});
// Step 1 End

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
//Step 2 Start
app.UseResponseCompression();
app.MapHub<ChatHub>("/chathub");
//Step 2 End

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
