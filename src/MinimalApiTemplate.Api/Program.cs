var app = CreateApplication(args);
AddEndpoints(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

static WebApplication CreateApplication(params string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddServiceInstallers(builder.Configuration, AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

    var config = new TypeAdapterConfig();
    builder.Services.AddSingleton(config);
    builder.Services.AddScoped<IMapper, ServiceMapper>();

    return builder.Build();
}

static void AddEndpoints(WebApplication app)
{
    //app.MediatePost<CreateCSRPainRequest, CreateCSRPainResponse>(ApiRoutes.Pain.CreateCSRPain);
}