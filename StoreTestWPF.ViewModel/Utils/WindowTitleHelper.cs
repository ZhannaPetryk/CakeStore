using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace StoreTestWPF.ViewModel.Utils
{
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
