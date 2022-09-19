namespace theFoodCampus.Models
{
    /// <summary>
    /// recipe class consisting of id, name, tags , ingredients
    /// </summary>
    public class Recipe
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public List<int> Tags { get; set; }
        public List<Ingredient> Ingredients{ get; set; }
        public List<string> Instructions{ get; set; }
        public string Image { get; set; }
    }
}
