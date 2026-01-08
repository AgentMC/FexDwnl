using FexDwnl.Properties;
using System.Globalization;

namespace FexDwnl
{
    internal static partial class ApplicationConfiguration
    {
        public static bool TrySetCulture()
        {
            if (!string.IsNullOrWhiteSpace(Settings.Default.ForceLocale))
            {
                try
                {
                    var culture = new CultureInfo(Settings.Default.ForceLocale);
                    Thread.CurrentThread.CurrentUICulture = culture;
                    Thread.CurrentThread.CurrentCulture = culture;
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{Resources.AppName} - {Resources.ErrUnableToSetCultureToFmt.Format(Settings.Default.ForceLocale!)}] - {e}", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
    }
}
