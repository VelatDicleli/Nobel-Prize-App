

using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Ef_Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:msSqlconnection", b => b.MigrationsAssembly("NobelPrize"));

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



builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IRepoManager, RepoManager>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
