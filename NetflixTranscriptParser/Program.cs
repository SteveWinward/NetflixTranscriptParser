using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NetflixTranscriptParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Two command line arguments are reqruired for this program ([inputFilename] [outputFilename]");
            }

            var inputFilename = args[0];
            var outputFilename = args[1];

            // Define the XML namespaces to query
            XNamespace ttmlNs = "http://www.w3.org/ns/ttml";
            XNamespace ttpNs = "http://www.w3.org/ns/ttml#parameter";

            if (!File.Exists(inputFilename))
            {
                throw new ArgumentException($"Could not find the input xml file with path: {inputFilename}");
            }

            // Load the XML file
            var doc = XDocument.Load(inputFilename);

            // Get the tick rate
            var tickRate = int.Parse(doc.Root.Attribute(ttpNs + "tickRate").Value);

            var body = doc.Descendants(ttmlNs + "div").ToList();

            var lines = body.Descendants(ttmlNs + "p").ToList();

            // Loop over all p tags in the file
            using (StreamWriter file = new StreamWriter(outputFilename, false, Encoding.UTF8))
            {
                foreach (var line in lines)
                {
                    var start = double.Parse(line.Attribute("begin").Value.Replace("t", ""));
                    var end = double.Parse(line.Attribute("end").Value.Replace("t", ""));

                    var startTime = TimeSpan.FromSeconds(start / tickRate);
                    var endTime = TimeSpan.FromSeconds(end / tickRate);

                    var spans = line.Descendants(ttmlNs + "span");

                    var lineText = string.Join(" ", spans.Select(s => s.Value));

                    file.WriteLine($"[{startTime:hh\\:mm\\:ss}] {lineText}");
                }
            }
        }
    }
}
