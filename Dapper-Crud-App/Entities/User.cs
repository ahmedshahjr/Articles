using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Dapper_Crud_App.Entities
{
    public class User : UserInsert
    {
        [Key]
        public Guid Id { get; set; } =Guid.NewGuid();
    }
    public class UserInsert
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

//    Create table Users
//(
//Id UNIQUEIDENTIFIER PRIMARY KEY,
//Name nvarchar(max),
//Description nvarchar(max)

//)
}
