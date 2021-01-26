using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Text;
using System.Windows.Forms;

namespace VideoConversor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //VideSize.qvga = 240p
        //VideSize.Ega = 350p
        //VideoSize.Wqvga = 240x400
        //VideoSize.Fwqvga = 240x432
        //VideoSize.Wuxga = 1200x1920
        //VideoSize.Wsxga = 1024x1600
        //VideoSize.Whsxga = erro
        //VideoSize.Wquxga = 2400x3840
        //VideoSize.Wqsxga = 2048x3200
        //VideoSize._4k = 2160hd

        private void Form1_Load(object sender, EventArgs e)
        {
            var inputFile = new MediaFile { Filename = "C:\\Users\\warne\\Downloads\\Inauguração da loja Oficina Reserva em São Paulo.mp4" };
            var outputFile = new MediaFile { Filename = "C:\\Users\\warne\\Downloads\\Inauguração da loja Oficina Reserva em São Paulo.mp4" };
            var conversionOptions = new ConversionOptions()
            {
                VideoSize =  VideoSize.Ega
            };
            outputFile.Filename = outputFile.Filename.Replace(".", "360p.");
            using (var engine = new Engine())
            {
                engine.Convert(inputFile, outputFile, conversionOptions);
            }
            //Convert(inputFile, outputFile, conversionOptions);
        }

        private static string Convert(MediaFile inputFile, MediaFile outputFile, ConversionOptions conversionOptions)
        {
            var commandBuilder = new StringBuilder();

            // Default conversion
            if (conversionOptions == null)
                return commandBuilder.AppendFormat(" -i \"{0}\"  \"{1}\" ", inputFile.Filename, outputFile.Filename).ToString();

            // Media seek position
            //if (conversionOptions.Seek != null)
            //    commandBuilder.AppendFormat(" -ss {0} ", conversionOptions.Seek.Value.TotalSeconds);

            //commandBuilder.AppendFormat(" -i \"{0}\" ", inputFile.Filename);

            // Physical media conversion (DVD etc)
            //if (conversionOptions.Target != Target.Default)
            //{
            //    commandBuilder.Append(" -target ");
            //    if (conversionOptions.TargetStandard != TargetStandard.Default)
            //    {
            //        commandBuilder.AppendFormat(" {0}-{1} \"{2}\" ", conversionOptions.TargetStandard.ToLower(),
            //            conversionOptions.Target.ToLower(), outputFile.Filename);

            //        return commandBuilder.ToString();
            //    }
            //    commandBuilder.AppendFormat("{0} \"{1}\" ", conversionOptions.Target.ToLower(), outputFile.Filename);

            //    return commandBuilder.ToString();
            //}

            //// Audio sample rate
            //if (conversionOptions.AudioSampleRate != AudioSampleRate.Default)
            //    commandBuilder.AppendFormat(" -ar {0} ", conversionOptions.AudioSampleRate.Remove("Hz"));

            // Maximum video duration
            //if (conversionOptions.MaxVideoDuration != null)
            //    commandBuilder.AppendFormat(" -t {0} ", conversionOptions.MaxVideoDuration);

            //// Video bit rate
            //if (conversionOptions.VideoBitRate != null)
            //    commandBuilder.AppendFormat(" -b {0}k ", conversionOptions.VideoBitRate);

            // Video size / resolution
            if (conversionOptions.VideoSize != VideoSize.Hd480)
            {
                string size = conversionOptions.VideoSize.ToString().ToLower();
                if (size.StartsWith("_")) size = size.Replace("_", "");
                if (size.Contains("_")) size = size.Replace("_", "-");

                commandBuilder.AppendFormat(" -s {0} ", size);
            }

            // Video aspect ratio
            //if (conversionOptions.VideoAspectRatio != VideoAspectRatio.Default)
            //{
            //    string ratio = conversionOptions.VideoAspectRatio.ToString();
            //    ratio = ratio.Substring(1);
            //    ratio = ratio.Replace("_", ":");

            //    commandBuilder.AppendFormat(" -aspect {0} ", ratio);
            //}

            return commandBuilder.AppendFormat(" \"{0}\" ", outputFile.Filename).ToString();
        }
 

    }
}
