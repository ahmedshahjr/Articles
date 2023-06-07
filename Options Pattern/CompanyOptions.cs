namespace Options_Pattern
{
    public class CompanyOptions
    {
        public const string CoOperate = "CoOperate";
        public const string Individual = "Individual";


        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = string.Empty;
        public int ZipCode { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
  
}
