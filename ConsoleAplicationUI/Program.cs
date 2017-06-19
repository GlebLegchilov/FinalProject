using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BLLInterface.Services;
using DependencyResolver;
using Ninject;

namespace ConsoleAplicationUI
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        static void Main(string[] args)
        {
            var service = resolver.Get<ICategoryService>();
            var list = service.GetAll().ToList();
            foreach (var user in list)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}
