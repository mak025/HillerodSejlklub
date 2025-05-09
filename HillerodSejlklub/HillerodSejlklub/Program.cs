using HillerodSejlklub.Service;
using HillerodSejlklub.Interface;
using HillerodSejlklub.Repo;

namespace HillerodSejlklub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<IBoat, BoatCollection>();
            builder.Services.AddSingleton<BoatCollection>();
            builder.Services.AddSingleton<BoatService>(); // Add services to the container.
            builder.Services.AddSingleton<IBooking, BookingCollection>();
            builder.Services.AddSingleton<BookingService>();
            builder.Services.AddSingleton<IMember, MemberCollection>();// Add services to the container.
            builder.Services.AddSingleton<MemberService>();
            builder.Services.AddRazorPages();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
