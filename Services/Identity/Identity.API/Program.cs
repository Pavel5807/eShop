using eShop.Services.Identity.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Build();
// builder.AddServiceDefaults();

// builder.Services.AddControllersWithViews();

// builder.Services.AddDbContext<TDBContext>();

// builder.Services.AddIdentityServer()
//     .AddInMemoryIdentityResources(Config.GetResources())
//     .AddInMemoryApiScopes(Config.GetApiScopes())
//     .AddInMemoryApiResources(Config.GetApis())
//     .AddInMemoryClients(Config.GetClients(builder.Configuration))
//     .AddAspNetIdentity<TUser>();

// builder.Services.AddHealthChecks();

// builder.Services.AddTransient<IProfileService, ProfileService>();
// builder.Services.AddTransient<ILoginService<TUser>, EFLoginService>();
// builder.Services.AddTransient<IRedirectService, RedirectService>();





// var app = builder.Build();

// app.UseServiceDefaults();

// app.UseStaticFiles();

// app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax});
// app.UseIdentityServer();
// app.UseAuthorization();
// app.MapDefaultControllerRoute();

// app.Run();






// if (app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
// }
// else
// {
//     app.UseExceptionHandler("/Home/Error");
// }

// app.UseStaticFiles();
// app.MapDefaultControllerRoute();
// app.Run();
