﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Client.Extensions
{

    public static class EnumExtensions
    {
        public static string ToDescriptionString(this Enum val)
        {
            var attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? attributes[0].Description
                : val.ToString();
        }
    }

}
