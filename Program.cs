var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
//分散式SQLServer快取
// builder.Services.AddDistributedSqlServerCache(options =>
// {
//     options.ConnectionString = builder.Configuration.GetConnectionString(
//         "DistCache_ConnectionString");
//     options.SchemaName = "dbo";
//     options.TableName = "TestCache";
// });
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
    name: "MyBlogs",
    pattern: "{area:exists}/{controller=Test}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "MyBook",
    pattern: "{area:exists}/{controller=Book}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "UserInfo",
    pattern: "UserInfo",
    defaults:new {controller = "Person",action = "UserInformation"});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
