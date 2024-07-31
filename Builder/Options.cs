using Builder.Build;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = Builder.Build.Object;

namespace Builder.Options;

public class Options
{
    public Options(string title, StageSize stageSize)
    {
        this.baseObjectScale = 1;
        this.fontSize = 80;
        this.filename = Guid.NewGuid().ToString() + ".hopscotch";
        this.version = 29;
        this.stageSize = stageSize;
        this.title = title;
    }

    public async Task<string> NewUUID()
    {
        string w = "0123456789abcdefghijklmnopqrstuvwxyz";
        decimal x = 0;
        long y = 0;
        string z = "";
        x = Convert.ToInt64((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 65536)) / 1000;
        async Task base36()
        {
            y = Convert.ToInt64(x % 36);
            x = Math.Floor(Convert.ToDecimal(x / 36));
            z = w[Convert.ToInt32(y % 36)] + z;
            if (x != 0)
            {
                base36();
            }
        }
        await base36();
        return z;
    }

    public int baseObjectScale { get; set; }
    public int fontSize { get; set; }
    public List<object> customObjects = new List<object> { };
    public string filename { get; set; }
    public List<object> remote_asset_urls = new List<object> { };
    public int version { get; set; }
    public List<EventParameter> eventParameters = new List<EventParameter> { };
    public StageSize stageSize { get; set; }
    public List<object> traits = new List<object> { };
    public string title { get; set; }
}