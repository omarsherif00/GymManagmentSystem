using GymManagmentDAL.Data.Contexts;
using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.SeedData
{
    public static class GymDbContextSeeding
    {
        public static bool SeedData(GymDbContext dbContext)
        {
            try
            {
                var hasPlans = dbContext.Plans.Any();
                var hasCategory = dbContext.Categories.Any();

                if (hasPlans && hasCategory)
                    return false;

                if (!hasPlans)
                {
                    var plans = LoadDataFromJson<Plan>("plans.json");
                    if (plans.Any())
                        dbContext.AddRange(plans);
                }

                if (!hasCategory)
                {
                    var categories = LoadDataFromJson<Category>("Categories.json");
                    if (categories.Any()) dbContext.AddRange(categories);
                }
                return dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private static List<T> LoadDataFromJson<T>(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files",fileName);

            if (!File.Exists(filePath))
                return [];
            var jsonData = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<List<T>>(jsonData)??new List<T>();
        }
    }
}
