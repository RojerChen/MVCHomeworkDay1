﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCHomeworkDay1.My
{
    public static class EnumExtension
    {
        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetDescription(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }


        /// <summary>
        /// To the select list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue">預設值</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this System.Enum enumValue)
        {
            return
                System.Enum.GetValues(enumValue.GetType()).Cast<T>()
                      .Select(
                          x =>
                          new SelectListItem
                          {
                              Text = ((System.Enum)(object)x).GetDescription(), //description
                              //Value = (int)x.ToString(),
                              Value =  ((int)(object)x).ToString(),             //value
                              Selected = (enumValue.Equals(x))
                          });
        }

 
     

    }
}