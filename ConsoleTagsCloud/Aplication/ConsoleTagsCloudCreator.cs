using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Infrastructure;
using TagsCloud.Tool;
using CommandLine;

namespace ConsoleTagsCloud.Aplication
{
    public class ConsoleTagsCloudCreator
    {
        private readonly ITagsCloudCreator creator;
        private readonly IImageSaver saver;
        private readonly IWordReader reader;
        private readonly IWordProcessor processor;

        public ConsoleTagsCloudCreator(ITagsCloudCreator creator, IImageSaver saver, IWordReader reader,
            IWordProcessor processor)
        {
            this.creator = creator;
            this.saver = saver;
            this.reader = reader;
            this.processor = processor;
        }

        public void Run()
        {
            Options options = null;
            while (options == null)
                options = AskOptions();
            var settings = GetSettings(options);
            reader.Path = options.InputFile;
            processor.AddExcludingRule(x => x.Length <= 3);
            var image = creator.Create(settings);
            SaveImage(image, options.OutputFile);
        }

        private Options AskOptions()
        {
            Console.WriteLine($"> Enter settings");
            var args = Console.ReadLine().Split(' ');

            var options = new Options();

            return Parser.Default.ParseArguments(args, options) ? options : null;
        }

        private IPaintingSettings GetSettings(Options options)
        {
            var settings = new PaintingSettings
            {
                Font = new Font(options.Font, 1),
                ColorProvider = options.Colors.Any()
                    ? (IColorProvider) new SimpleColorProvider(options.Colors)
                    : new RandomColorProvider(),
                ImageSize = new Size(options.Width, options.Height)
            };

            return settings;
        }

        private void SaveImage(Bitmap image, string path)
        {
            saver.SaveImage(image, ImageFormat.Png, path);
            Console.WriteLine("Image was succefuly saved");
        }
    }
}