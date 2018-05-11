using Autofac;
using Autofac.Integration.WebApi;
using InterviewCode.RecordsApi.Controllers;
using InterviewCode.Repository;
using InterviewCode.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace InterviewCode.RecordsApi.App_Start
{
    public class AutofacBootStrapper
    {
        public static void Bootstrap(ContainerBuilder builder)
        {
            builder.RegisterType<RecordRepository>().As<IRecordRepository>().InstancePerRequest();
            builder.RegisterType<RecordService>().As<IRecordService>()
                .UsingConstructor(typeof(IRecordRepository))
                .InstancePerRequest();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}