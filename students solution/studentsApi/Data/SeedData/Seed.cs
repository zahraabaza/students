namespace students_Api.Data.SeedData
{
    public class Seed
    {
        internal static async Task SeedData(DataContext context)
        {
            await ReadData<Parent>("Parent", context);
            await ReadData<Student>("Student", context);
        }

        private static async Task ReadData<TEntity>(string fileName, DataContext context) where TEntity : BaseEntity
        {
            if (!context.Set<TEntity>().Any())
            {
                var file = await File.ReadAllTextAsync("Data/SeedData/" + fileName + ".json");

                var data = JsonSerializer.Deserialize<List<TEntity>>(file);

                await context.Set<TEntity>().AddRangeAsync(data);

                await context.SaveChangesAsync();

            }

        }
    }
}
