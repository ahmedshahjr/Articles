using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Dapper_Crud_App.Options
{
    public class DatabaseConfigurationOptions
    {
        public const string DatabaseConfiguration = "DatabaseConfiguration";
        [Required]
        public string ConnectionString { get; set; }
    }
}
