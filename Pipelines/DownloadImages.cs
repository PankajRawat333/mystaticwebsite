using Kentico.Kontent.Statiq.Lumen.Pipelines;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using System.Linq;

namespace Generator.Pipelines
{
    public class DownloadImages : Pipeline
    {
        public DownloadImages()
        {
            Dependencies.AddRange(nameof(Posts), nameof(Home));
            PostProcessModules = new ModuleList(
                // pull documents from other pipelines
                new ReplaceDocuments(Dependencies.ToArray()),
                new KontentDownloadImages()
            );
            OutputModules = new ModuleList(
                
                new WriteFiles()
            );
        }
    }
}