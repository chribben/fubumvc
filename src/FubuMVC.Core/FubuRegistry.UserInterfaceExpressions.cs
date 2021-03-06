using System;
using System.Linq;
using FubuCore.Formatting;
using FubuMVC.Core.UI;

namespace FubuMVC.Core
{
    public partial class FubuRegistry : IFubuRegistry
    {
        public void HtmlConvention<T>() where T : HtmlConventionRegistry, new()
        {
            HtmlConvention(new T());
        }

        public void HtmlConvention(HtmlConventionRegistry conventions)
        {
            Services(x => x.AddService(conventions));
        }

        public void HtmlConvention(Action<HtmlConventionRegistry> configure)
        {
            var conventions = new HtmlConventionRegistry();
            configure(conventions);

            HtmlConvention(conventions);
        }

        public void StringConversions<T>() where T : DisplayConversionRegistry, new()
        {
            var conversions = new T();

            addStringConversions(conversions);
        }

        private void addStringConversions(DisplayConversionRegistry conversions)
        {
            Services(x =>
            {
                x.SetServiceIfNone(new Stringifier());
                
                throw new NotImplementedException();
                //var stringifier = x.FindAllValues<Stringifier>().First();

                //conversions.Configure(stringifier);
            });
        }

        public void StringConversions(Action<DisplayConversionRegistry> configure)
        {
            var conversions = new DisplayConversionRegistry();
            configure(conversions);

            addStringConversions(conversions);
        }
    }
}