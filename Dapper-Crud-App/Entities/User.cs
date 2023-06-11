using System;

namespace Dapper_Crud_App.Entities
{
    public class User : UserInsert
    {
        public Guid Id { get; set; }
    }
    public class UserInsert
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    //    Create table Users
    //    (
    //Id UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
    //Name nvarchar(max),
    //Description nvarchar(max)
    //)
}
