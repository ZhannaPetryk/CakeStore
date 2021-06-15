using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace StoreTestWPF.ViewModel.Enums
{
    public enum WindowTitles
    {
        [Display(Name = "Edit cake")] Edit,
        [Display(Name = "Add cake")] Add
    }

    public static class WindowTitleHelper
    {
        public static DisplayAttribute GetDisplayAttributesFrom(this Enum enumValue, Type enumType)
        {
            return enumType.GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>();
        }
    }
}
