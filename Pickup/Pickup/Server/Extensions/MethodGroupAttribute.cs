using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Server.Extensions
{
    /// <summary>
    /// Forces method to be displayed within specified group, regardless of controller
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MethodGroupAttribute : Attribute
    {
        /// <summary>
        /// Group name
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="groupName"></param>
        public MethodGroupAttribute(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("groupName");
            }
            GroupName = groupName;
        }
    }
}
