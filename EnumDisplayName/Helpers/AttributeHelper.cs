using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace EnumDisplayName.Helpers
{
    public static class AttributeHelper
    {
        public static string GetDisplayName(this Enum @enum)
        {
            Type enumType = @enum.GetType();
            MemberInfo[] infos = enumType.GetMember(@enum.ToString());

            string displayName = @enum.ToString();
            if (infos != null && infos.Length > 0)
            {
                DisplayAttribute displayAttribute = infos.First().GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                {
                    PropertyInfo resourceManagerMethodInfo = displayAttribute.ResourceType?.GetRuntimeProperties().SingleOrDefault(x => x.Name == nameof(ResourceManager));
                    // displayAttribute.ResourceType?.GetRuntimeProperty(nameof(ResourceManager)) doesn't return anything ¯\_(ツ)_/¯

                    ResourceManager resourceManager = (ResourceManager)resourceManagerMethodInfo?.GetValue(null);
                    if (resourceManager != null)
                    {
                        displayName = resourceManager.GetString(displayAttribute.Name);
                    }
                    else
                    {
                        displayName = displayAttribute.GetName();
                    }
                }
            }
            return displayName;
        }
    }
}
