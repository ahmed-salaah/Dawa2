using Logic.Models.Data;
using Xamarin.Forms;

namespace UI.TemplateSelectors
{
    public class HistoryMedicineTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MissedTemplate { get; set; }
        public DataTemplate NotMissedTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Medicine)item).IsMissed ? MissedTemplate : NotMissedTemplate;
        }
    }
}
