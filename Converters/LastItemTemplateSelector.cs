using System.Collections;

namespace MAUI.Converters
{
    public class LastItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? DefaultTemplate { get; set; }
        public DataTemplate? LastItemTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var itemsView = (CollectionView)container;
            var items = itemsView.ItemsSource as IList;

            if (items != null && item != null)
            {
                int index = items.IndexOf(item);

                // Check if the item is the last one in the collection
                if (index == items.Count - 1)
                {
                    return LastItemTemplate;
                }
            }

            return DefaultTemplate;
        }
    }

}
