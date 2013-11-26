using System;
using System.Linq;

namespace HalApp
{
	public static class ReflectionHelpers
	{
		public static bool IsAssignableTo(this Type subject, Type type)
		{
			if (type.IsAssignableFrom(subject))
				return true;

			if (subject.IsGenericType && subject.GetGenericTypeDefinition() == type)
				return true;

			var interfaceTypes = subject.GetInterfaces();

			if (interfaceTypes.Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == type))
				return true;

			var baseType = subject.BaseType;

			return baseType != null && baseType.IsAssignableTo(type);
		}
	}
}