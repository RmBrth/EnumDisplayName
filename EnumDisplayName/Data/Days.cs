using System.ComponentModel.DataAnnotations;

namespace EnumDisplayName.Data
{
    public enum Days
    {
        [Display(Name = "Monday", ResourceType = typeof(Properties.Resources))]
        Monday,
        [Display(Name = nameof(Properties.Resources.Tuesday), ResourceType = typeof(Properties.Resources))]
        Tuesday,
        [Display(Name = "Mercredi")]
        Wednesday,
        Thurstday,
        Friday,
        Saturday,
        Sunday
    }
}
