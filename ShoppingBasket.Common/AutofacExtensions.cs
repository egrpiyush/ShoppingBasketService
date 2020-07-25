using Autofac;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ShoppingBasket.Common
{
    public static class AutofacExtensions
    {
        public static void RegisterMatchingTypeAsImplementedInterfaces(this ContainerBuilder builder, Assembly containingAssembly, params string[] classNameMatchers)
        {
            builder
                .RegisterAssemblyTypes(containingAssembly)
                .Where(p => classNameMatchers.Any(m => Regex.IsMatch(p.Name, m)))
                .AsImplementedInterfaces();
        }
    }
}
