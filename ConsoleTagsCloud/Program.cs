﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTagsCloud.Aplication;
using TagsCloud.Tool;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using TagsCloud.Infrastructure;

namespace ConsoleTagsCloud
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var program = BuildDependencies();
            program.Run();
        }

        private static ConsoleTagsCloudCreator BuildDependencies()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ConsoleTagsCloudCreator>());
            container.Register(Component.For<ITagsCloudCreator>().ImplementedBy<TagsCloudCreator>());
            container.Register(Component.For<IImageSaver>().ImplementedBy<SimpleImageSaver>());
            container.Register(Component.For<IWordReader>().ImplementedBy<SimpleWordReader>());
            container.Register(Component.For<IWordProcessor>().ImplementedBy<SimpleWordProcessor>());

            container.Register(Component.For<ITagsPainter>().ImplementedBy<SimpleTagsPainter>());
            container.Register(Component.For<ITagLayouter>().ImplementedBy<CircularCloudLayouter>());
            container.Register(Component.For<IWordProvider>().ImplementedBy<SimpleWordProvider>());

            container.Register(Component.For<ITagsCreator>().ImplementedBy<SimpleTagsCreator>());


            return container.Resolve<ConsoleTagsCloudCreator>();
        }
    }
}