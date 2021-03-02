using System;
using System.Collections.Generic;
using System.Text;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using VPBot.Clients.UI;
using VPBot.Clients.UI.Properties;

namespace VPBot.IntregationTests
{
    [TestClass]
    public class Assembly
    {
        public static IContainerProvider Container { get; private set; }

        //[AssemblyInitialize]
        public static void AssemblyInit(TestContext textContext)
        {
            var application = new MockApp();

            Container = application.Container;
        }

        //[AssemblyCleanup]
        public static void AssemblyClean()
        {

        }
    }

    public class MockApp : PrismApplication
    {
        protected override void OnInitialized()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterServices();

            containerRegistry.RegisterFactories();

            containerRegistry.RegisterCommands();

            containerRegistry.RegisterQueries();

            containerRegistry.RegisterViews();
        }
    }
}
