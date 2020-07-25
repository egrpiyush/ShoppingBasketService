using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShoppingBasket.Application;
using ShoppingBasket.Functions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]
namespace ShoppingBasket.Functions
{
    public class Startup : FunctionsStartup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup()
        {

        }
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Add MediatR and AutoMapper
            //builder.Services.AddValidatorsFromAssemblies(new[] { typeof(Application.AutofacModule).Assembly });

            // Add framework services.
            //builder.Services.AddHttpClient<IDiscountService, DiscountService>();
            //builder.Services.AddHttpClient<ICoverService, CoverService>();
            //builder.Services.AddHttpClient<IPersonService, PersonService>();
            //builder.Services.AddTransient<IReceiptService, ReceiptService>();
            //builder.Services.AddTransient<IVariancePeriod, VariancePeriod>();
            //builder.Services.AddTransient<IRollingPremiumNormalization, RollingPremiumNormalization>();
            //builder.Services.AddTransient<IRateEffectiveNormalization, RateEffectiveNormalization>();
            //builder.Services.AddTransient<INormalization, Normalization>();
            //builder.Services.AddTransient<IBestFitPremium, Application.BusinessLogic.Calculation.BestFit.Premium>();
            //builder.Services.AddTransient<IFrequencyLoopPremium, Premium>();
            //builder.Services.AddTransient<IBestFitProductFee, Application.BusinessLogic.Calculation.BestFit.ProductFee>();
            //builder.Services.AddTransient<IBestFitCalculation, Application.BusinessLogic.Calculation.BestFit.Calculation>();
            //builder.Services.AddTransient<IFrequencyLoopCalculation, Calculation>();
            //builder.Services.AddTransient<IRefundCalculation, Refund>();
            //builder.Services.AddTransient<IFullRefund, FullRefund>();
            //builder.Services.AddTransient<IPartialRefund, PartialRefund>();
            //builder.Services.AddTransient<IAdjustmentRefund, AdjustmentRefund>();
            //builder.Services.AddTransient<IReversalRefund, ReversalRefund>();
            //builder.Services.AddTransient<IReversalLine, ReversalLine>();
            //builder.Services.AddTransient<IReversalDetailLine, ReversalDetailLine>();
            //builder.Services.AddTransient<IPremiumByType, PremiumByType>();
            //builder.Services.AddTransient<IChangeOfJoinDate, ChangeOfJoinDate>();
            //builder.Services.AddTransient<IChangeOfCover, ChangeOfCover>();
            //builder.Services.AddTransient<IExtension, Extension>();
            //builder.Services.AddTransient<IReduction, Reduction>();
            //builder.Services.AddTransient<INoChange, NoChange>();
            //builder.Services.AddTransient<ICalculationInput, CalculationInput>();

            var applicationAssembly = typeof(AutofacModule).GetTypeInfo().Assembly;
            builder.Services
                //.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggerBehaviour<,>))
                //.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                .AddMediatR(applicationAssembly);
                //.AddAutoMapper(applicationAssembly);

            var containerBuilder = new ContainerBuilder();

            // Once you've registered everything in the ServiceCollection, call
            // Populate to bring those registrations into Autofac. This is
            // just like a foreach over the list of things in the collection
            // to add them to Autofac.
            //containerBuilder.Populate(builder.Services);

            // Make your Autofac registrations. Order is important!
            // If you make them BEFORE you call Populate, then the
            // registrations in the ServiceCollection will override Autofac
            // registrations; if you make them AFTER Populate, the Autofac
            // registrations will override. You can make registrations
            // before or after Populate, however you choose.
            containerBuilder.RegisterModule<AutofacModule>();

            // Creating a new AutofacServiceProvider makes the container
            // available to your app using the Microsoft IServiceProvider
            // interface so you can use those abstractions rather than
            // binding directly to Autofac.
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

        }

    }
}
