using Microsoft.EntityFrameworkCore;
using recruitment.Models;  // Đảm bảo đúng namespace của model TuyenCTVContext

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext trước khi build ứng dụng
builder.Services.AddDbContext<TuyenCTVContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cns"));
});

// Đăng ký các dịch vụ MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình pipeline cho các môi trường khác nhau
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS cho môi trường production
}

// Cấu hình các Middleware cần thiết
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();  // Thêm xác thực nếu cần

// Cấu hình route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Candidate}/{action=index}/{id?}");

// Chạy ứng dụng
app.Run();
