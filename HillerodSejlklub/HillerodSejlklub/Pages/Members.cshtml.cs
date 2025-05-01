using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using HillerodSejlklub.Model; 
using System.IO;
using HillerodSejlklub.Models;

namespace HillerodSejlklub.Pages
{
        public class MembersModel : PageModel
        {
            public List<Member> Members { get; set; } = new();

            private readonly string membersFilePath;

            public MembersModel(IWebHostEnvironment env)
            {
                membersFilePath = Path.Combine(env.ContentRootPath, "Data", "members.json");
            }

         
                public void OnGet()
        {
            if (System.IO.File.Exists(membersFilePath))
            {
                var json = System.IO.File.ReadAllText(membersFilePath);

                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        Members = JsonSerializer.Deserialize<List<Member>>(json) ?? new();
                    }
                    catch (Exception ex)
                    {
                        // Log evt. fejl
                        Console.WriteLine("Fejl ved indlæsning af members.json: " + ex.Message);
                        Members = new();
                    }
                }
                else
                {
                    Members = new();
                }
            }
            else
            {
                Members = new();
            }
        }

    }
}
    

