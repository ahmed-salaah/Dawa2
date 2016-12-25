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
            Medicine medicine = ((Medicine)item);
            if (medicine == null)
                return NotMissedTemplate;
            return medicine.IsMissed ? MissedTemplate : NotMissedTemplate;
        }
    }
}
