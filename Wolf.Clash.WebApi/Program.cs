var builder = WebApplication.CreateBuilder(args);
WebApplication? app = null;
Startup startup = new(builder.Host, () => { app = builder.Build(); return app.Services; });
app.ThrowIfIsNull();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
