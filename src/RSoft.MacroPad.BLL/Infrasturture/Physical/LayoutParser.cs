using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace RSoft.MacroPad.BLL.Infrasturture.Physical
{
    public class LayoutParser
    {
        public KeyboardLayout[] Parse(string path)
        {
            var lines = File.ReadAllLines(path).Select(l => l.Trim()).ToArray();

            KeyboardLayout layout = null;
            var result = new List<KeyboardLayout>();
            var lineNo = 0;
            for (var i = 0;i < lines.Length; i++)
            {
                lineNo++;
                var  line = lines[i];
                if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                    continue;
                try
                {
                    if (line.StartsWith("Layout:"))
                    {
                        layout = new KeyboardLayout();
                        layout.Name = line.Substring(7);

                        var ids = lines[++i].Trim().Split(',');
                        var products = new List<(ushort, ushort)>();
                        foreach (var id in ids.Select(i => i.Split(':'))) 
                        {
                            products.Add((ushort.Parse(id[0].Trim()), ushort.Parse(id[1].Trim())));
                        }
                        layout.Products = products;

                        var c = lines[++i].Split(':').Select(b => b.Trim()).ToArray();
                        layout.LayerCount = byte.Parse(c[0]);
                        layout.MaxCharacters = byte.Parse(c[1]);
                        layout.SupportsDelay = byte.Parse(c[2]) > 0;
                        layout.SupportsColor = byte.Parse(c[3]) > 0;
                        layout.LedModeCount = byte.Parse(c[4]);

                        layout.Controls = new List<PhysicalControl>();
                        result.Add(layout);
                        continue;
                    }
                    if (line.StartsWith("B"))
                    {
                        var data = line.Split(',');
                        var idx = int.Parse(data[0].Substring(1));
                        var button = new PhysicalButton(idx);
                        button.Position = new Vector(int.Parse(data[1]), int.Parse(data[2]));
                        if (data.Length >= 5)
                        {
                            button.Size = new Vector(int.Parse(data[3]), int.Parse(data[4]));
                        }
                        button.Name = idx.ToString();
                        ((List<PhysicalControl>)layout.Controls).Add(button);
                        continue;
                    }
                    if (line.StartsWith("K"))
                    {
                        var data = line.Split(',');
                        var idx = int.Parse(data[0].Substring(1));
                        var knob = new PhysicalKnob(idx);
                        knob.Position = new Vector(int.Parse(data[1]), int.Parse(data[2]));
                        if (data.Length >= 5)
                        {
                            knob.Size = new Vector(int.Parse(data[3]), int.Parse(data[4]));
                        }
                        knob.Name = idx.ToString();
                        ((List<PhysicalControl>)layout.Controls).Add(knob);
                        continue;
                    }
                }
                catch
                {

                }
                throw new InvalidDataException($"Invalid line format in {path}({lineNo}): {line}");
            }
            return result.OrderBy(l => l.Name).ToArray();
        }
    }
}
