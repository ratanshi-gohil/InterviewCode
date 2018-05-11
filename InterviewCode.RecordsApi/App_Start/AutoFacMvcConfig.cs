using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InterviewCode.RecordsApi.App_Start
{
    public class AutoFacMvcConfig
    {
        public static void Register()
        {
            //Create the container builder
            var builder = new ContainerBuilder();

            //Register the Dependencies
            AutofacBootStrapper.Bootstrap(builder);

            //Build the container
            var container = builder.Build();

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}