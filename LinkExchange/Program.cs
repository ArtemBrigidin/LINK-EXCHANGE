var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� ������
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // ����� ����� ������
});

// ��������� ������� ��� ������������ � ���������������
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ������������ ��������� ��������� HTTP-��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// �������� ������
app.UseSession();

app.UseRouting();
app.UseAuthorization();

// ��������� ���������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "userProfile",
    pattern: "User/Profile/{id?}",
    defaults: new { controller = "User", action = "Profile" });

app.Run();
