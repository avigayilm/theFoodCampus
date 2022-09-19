namespace theFoodCampus.Models
{
    /// <summary>
    /// ingredient class with all relevant information
    /// </summary>
    public class Ingredient
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public MeasurementType MeasurementUnit { get; set; }
    }
}