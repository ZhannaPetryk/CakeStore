using System.ComponentModel.DataAnnotations;

namespace StoreTestWPF.ViewModel.Enums
{
    public enum WindowTitles
    {
        [Display(Name = "Edit cake")] 
        Edit,
        [Display(Name = "Add cake")] 
        Add
    }
}
