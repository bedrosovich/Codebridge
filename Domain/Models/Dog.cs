using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Codebridge.Domain.Models
{
    [Table("dogs")]
    public class Dog
    {
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(30)]
        public string Name { get; set; }


        [Column("color")]
        [MaxLength(100)]
        public string Color { get; set; }


        [Column("tail_length", TypeName = "smallint")]
        
        public int Tail_Length { get; set; }


        [Column("weight", TypeName = "smallint")]
        public int Weight { get; set; }

    }
}
