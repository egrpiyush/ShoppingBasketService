using Autofac;
using ShoppingBasket.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Application
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMatchingTypeAsImplementedInterfaces(typeof(AutofacModule).Assembly,
                new[] { ".+Command$", ".+Query$", ".+Service$" });
        }
    }
}
