﻿using System;
using System.Linq;

namespace TypeLite.Extensions {
	/// <summary>
	/// Contains extensions for PropertyInfo class
	/// </summary>
	public static class TypeExtensions {
		/// <summary>
		/// Determined whether the specific type is nullable value type.
		/// </summary>
		/// <param name="type">The type to inspect.</param>
		/// <returns>true if the type is nullable value type otherwise false</returns>
		public static bool IsNullable(this Type type) {
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		/// <summary>
		/// Retrieves underlaying value type of the nullable value type.
		/// </summary>
		/// <param name="type">The type to inspect.</param>
		/// <returns>The underlaying value type.</returns>
		public static Type GetNullableValueType(this Type type) {
			return type.GetGenericArguments().Single();
		}
	}
}
