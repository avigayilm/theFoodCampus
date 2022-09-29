using MessagePack;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace theFoodCampus.Models
{
    /// <summary>
    /// recipe class consisting of id, name, tags , ingredients
    /// </summary>
    [Table("Recipes")]
    public class Recipe
    {

        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Descrption")]
        public string Description { get; set; }
        public Tags RTags { get; set; }

        [ForeignKey("Id")]
        public List<Ingredient> Ingredients { get; set; }

        [ForeignKey("Id")]
        public List<Instruction> Instructions { get; set; }
        public string Image { get; set; }
    }
}
