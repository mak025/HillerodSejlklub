namespace HillerodSejlklub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();
            builder.Services.AddSession();
            builder.Services.AddRazorPages();
            builder.Services.AddSession();

            builder.Services.AddRazorPages();
          
            app.UseSession();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
            app.UseHttpsRedirection();
        }
    }
}
