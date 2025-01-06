using Students.Model;
using Students.Model.Implementations;
using Students.Model.Implementations.StudentManagers;
using Students.Model.Implementations.Validations;
using Students.Model.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Regisztrálja az osztályt az interface-hez
// IoC container - Inversion of Control
// Kívülrõl megadtuk hogy Jsonbe kezelje a program a studenteket

builder.Services.AddDbContext<StudentDbContext>();

builder.Services.AddScoped<IStudentManager, DatabaseStudentManager>();
builder.Services.AddScoped<ITeacherManager, DatabaseTeacherManager>();
builder.Services.AddSingleton<IStudentValidator, NameLengthValidator>();
builder.Services.AddSingleton<IStudentValidator, EmailDomainValidator>();
builder.Services.AddSingleton<IStudentValidator, RecentRegistryValidator>();
builder.Services.AddSingleton<IEverythingValidator, EverythingValidator>();

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
