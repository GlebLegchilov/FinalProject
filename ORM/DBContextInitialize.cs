
using System; 
using System.Data.Entity;
using System.Web.Security;
using System.IO;
using ORM.Models;

namespace ORM
{
    public class DBContextInitialize : DropCreateDatabaseIfModelChanges<EntityModel>
                                       //DropCreateDatabaseAlways<EntityModel> 
                                       //CreateDatabaseIfNotExists<EntityModel> 
    {
        protected override void Seed(EntityModel context)
        {
            InitializeRoles(context);
         
            base.Seed(context);
        }

        private void InitializeRoles(EntityModel context)
        {
            context.Roles.Add(new Role { Id = 1, Name = "Admin" });
            context.Roles.Add(new Role { Id = 2, Name = "User" });
        }


    



    }
}