namespace theFoodCampus.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public Kashrut RKashrut { get; set; }
        public Difficulty  Rdifficulty{ get; set; }
        public  PrepTime RPrepTime { get; set; }
        public  Holiday RHoliday { get; set; }
        public Event REvent  { get; set; }
        public Weather RWeather{ get; set; }
        public Type RType{ get; set; }
        public Diet RDiet { get; set; }
        public Budget RBudget { get; set; }

    }
}
