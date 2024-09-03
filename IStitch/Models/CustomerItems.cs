using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IStitch.Models
{
    public class CustomerItems
    {
        [Required]
        [Key]
        public int ItemId { get; set; }

        [Required]
        [ForeignKey("ServiceName")]
        public string SerName { get; set; }

        [Required]
        [ForeignKey("Category")]
        public string Category { get; set; }

        [Required]
        public Service Service { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickUpDate { get; set; }

        [Required]
        [ForeignKey("Id")]
        public string CustomerId { get; set; }

        public string? ItemDescription { get; set; }

        public bool Completed { get; set; }

        public CustomerItems()
        {
            Completed = false;
        }
    }
}
