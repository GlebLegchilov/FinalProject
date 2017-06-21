
using System; 
using System.Data.Entity;
using System.Web.Security;
using System.IO;

namespace ORM
{
    public class DBContextInitialize : DropCreateDatabaseIfModelChanges<EntityModel>
                                       //DropCreateDatabaseAlways<EntityModel> 
                                       //CreateDatabaseIfNotExists<EntityModel> 
    {
        protected override void Seed(EntityModel context)
        {
            InitializeRoles(context);
            InitializeCategories(context);
         
            base.Seed(context);
        }

        private void InitializeRoles(EntityModel context)
        {
            context.Roles.Add(new Role { Id = 1, Name = "Admin" });
            context.Roles.Add(new Role { Id = 2, Name = "Moderator" });
            context.Roles.Add(new Role { Id = 3, Name = "User" });
        }

        private void InitializeCategories(EntityModel context)
        {
            context.Categorys.Add(new Category { Id = 1, Name = "Cars" });
            context.Categorys.Add(new Category { Id = 2, Name = "Phones" });
            context.Categorys.Add(new Category { Id = 3, Name = "Coins" });
            context.Categorys.Add(new Category { Id = 4, Name = "Paintings" });
            context.Categorys.Add(new Category { Id = 5, Name = "Books" });
            context.Categorys.Add(new Category { Id = 6, Name = "Сlothes" });

        }

    



    }
}