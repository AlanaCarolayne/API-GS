using API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                      ?? "Server=localhost;Database=fiap;User=root;Password=123;Port=3306;";
builder.Services.AddSingleton<UserRepository>(sp =>
    new UserRepository(connectionString));
builder.Services.AddSingleton<ChatRepository>(sp =>
    new ChatRepository(connectionString));
builder.Services.AddSingleton<MessageRepository>(sp =>
    new MessageRepository(connectionString));
builder.Services.AddSingleton<PromptRepository>(sp =>
    new PromptRepository(connectionString));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
