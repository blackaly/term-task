using System;
using System.ComponentModel;
using System.Reflection;
using Models.Nums;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());

        if (field == null)
        {
            return value.ToString(); 
        }


        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}