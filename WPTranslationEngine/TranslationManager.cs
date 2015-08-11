using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace WPTranslationEngine
{
    public class TranslationManager
    {
        #region Private Attributes
        private static ResourceLoader loader = null;
        #endregion

        #region Private Properties
        private static ResourceLoader Loader
        {
            get
            {
                if (loader == null)
                    loader = new ResourceLoader();

                return loader;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Translate all controls in the informed view where the tag attribute is filled with the translation constant.
        /// </summary>
        /// <param name="view">The Page or View to be translated.</param>
        public static void Translate(DependencyObject view)
        {
            var controls = GetAllControlsWithTag(view);

            TranslateControls(controls);
        }
        #endregion

        #region Private Methods
        private static void TranslateControls(List<object> controls)
        {
            foreach (var item in controls)
            {
                if ((item as ItemsControl) != null && (item as ItemsControl).Items != null)
                {
                    var control = item as ItemsControl;

                    foreach (ContentControl itemContents in control.Items)
                    {
                        if (itemContents != null && itemContents.Tag != null)
                        {
                            var translation = Loader.GetString(itemContents.Tag.ToString());
                            if (!string.IsNullOrEmpty(translation))
                                itemContents.Content = translation;
                        }
                    }
                    continue;
                }

                if ((item as ContentControl) != null && (item as ContentControl).Tag != null)
                {
                    var translation = Loader.GetString((item as ContentControl).Tag.ToString());

                    if (!string.IsNullOrEmpty(translation))
                        (item as ContentControl).Content = translation;
                    continue;
                }

                if ((item as TextBlock) != null && (item as TextBlock).Tag != null)
                {
                    var translation = Loader.GetString((item as TextBlock).Tag.ToString());

                    if (!string.IsNullOrEmpty(translation))
                        (item as TextBlock).Text = translation;
                    continue;
                }
            }
        }

        private static List<object> GetAllControlsWithTag(DependencyObject view)
        {
            var result = new List<object>();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(view); i++)
            {
                var control = VisualTreeHelper.GetChild(view, i);

                if ((control as Grid) == null && (control as StackPanel) == null)
                    result.Add(VisualTreeHelper.GetChild(view, i));

                result.AddRange(GetAllControlsWithTag(VisualTreeHelper.GetChild(view, i)));
            }
            return result;
        }
        #endregion
    }
}
