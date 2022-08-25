using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore6API_Sample.Models
{
    public class TblItem
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "物品名稱")]
        public string Name { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? ModifyTime { get; set; }

    }
}
