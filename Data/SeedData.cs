using efCoreApi.Entities;
using Newtonsoft.Json;

namespace efCoreApi.Data
{
    public class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Produits.Any())
            {
                var json = File.ReadAllText("Data/produits.json");
                var data = JsonConvert.DeserializeObject<List<Produit>>(json);

                if (data != null)
                {
                    context.Produits.AddRange(data);
                    context.SaveChanges();
                }
                else
                {
                    // Handle the case where data is null, e.g., log an error or take appropriate action.
                }
            }
        }
    }
}
