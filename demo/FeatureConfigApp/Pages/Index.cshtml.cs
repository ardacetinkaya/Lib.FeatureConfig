using Lib.FeatureConfig;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FeatureConfigApp.Pages
{
    public class IndexModel : PageModel
    {
        IFeatureService _features;

        public string Planet { get; set; } = "World";
        public IndexModel(IFeatureService features)
        {
            _features = features;
        }
        public void OnGet()
        {
            var test = _features.IsEnabled("Mars");
            if (test)
            {
                Planet = "Mars";
            }
        }
    }
}
