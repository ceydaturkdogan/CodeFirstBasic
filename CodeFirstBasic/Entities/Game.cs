using System.ComponentModel.DataAnnotations;

namespace CodeFirstBasic.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Platform { get; set; }

        [Range(minimum: 0, maximum: 10)]
        public decimal Rating { get; set; }
    }
}
