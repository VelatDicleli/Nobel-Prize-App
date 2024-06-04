using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Ef_Core.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:msSqlconnection", b => b.MigrationsAssembly("NobelPrizeAPI"));

}
);

builder.Services.AddScoped<IAwardRepo, AwardRepo>();
builder.Services.AddScoped<ICandidateRepo, CandidateRepo>();
builder.Services.AddScoped<IExpertRepo, ExpertRepo>();
builder.Services.AddScoped<ICommitteeRepo, CommitteeRepo>();
builder.Services.AddScoped<IOrganizationRepo, OrganizationRepo>();

builder.Services.AddScoped<IAwardService, AwardService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IExpertService, ExpertService>();
builder.Services.AddScoped<ICommitteeService, CommitteeService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();



builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepoManager, RepoManager>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:5174") // Ýzin verilecek origin
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
