using System.ComponentModel.DataAnnotations;

namespace Options_Pattern
{
    public class CompanyOptions
    {
        public const string CoOperate = "CoOperate";
        public const string Individual = "Individual";

        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
  
}
