using IStitch.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IStitch.ViewModels
{
    public class CustomerItemViewModel
    {
        [Required]
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        [Required]
        [ForeignKey("ServiceName")]
        public string SerName { get; set; }
        [Required]
        public Service Service { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PickUpDate { get; set; }
        public string? ItemDescription { get; set; }

        public string PhoneNumber { get; set; }

        //For display purposes
        public IEnumerable<ServiceType>? ServicesTypeCategoryList { get; set; }
        public IEnumerable<Service>? ServiceNameList { get; set; }
    }
}
