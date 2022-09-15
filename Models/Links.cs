using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLinks.Models
{
    [Table("Links")]
    public class Links
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Link")]
        [Display(Name = "Link")]
        public string Link { get; set; }

    }
}
