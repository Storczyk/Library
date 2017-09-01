using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

namespace Library.Web.Extensions
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            string[] locations = new string[] {
                                "Areas/Default/Views/{1}/{0}.cshtml",
                                "Areas/Default/Views/Shared/{0}.cshtml",
                "Areas/{2}/Views/{1}/{0}.cshtml",

            };
            return locations.Union(viewLocations);          //Add mvc default locations after ours
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(ViewLocationExpander);
        }
    }
}