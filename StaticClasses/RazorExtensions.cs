using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace project.pole.StaticClasses
{
    public static class RazorExtensions
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        } 
    }
}