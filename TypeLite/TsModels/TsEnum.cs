using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TypeLite.Extensions;

namespace TypeLite.TsModels {
	/// <summary>
	/// Represents an enum in the code model.
	/// </summary>
	public class TsEnum : TsModuleMember {
		/// <summary>
		/// Gets or sets bool value indicating whether this enum will be ignored by TsGenerator.
		/// </summary>
		public bool IsIgnored { get; set; }

        /// <summary>
        /// Gets or sets bool value indicating whether enum should be generated with Values as the String.
        /// </summary>
        public bool IsValueAsStringOfName { get; set; }

        /// <summary>
        /// Gets or sets whether to output an enumerator called _ValueList with a list of values pipe separated. Example: _ValueList = 'HCollars|DCollars|CCollars'
        /// </summary>
        public bool IsOutputValuesList { get; set; }

        /// <summary>
        /// Gets or sets whether to output an enumerator called _DescriptionList with a list of descriptions pipe separated. Example: _DescriptionList = 'Horse Collars|Dog Collars|Cat Collars'
        /// Values come from attribute on members
        /// </summary>
        public bool IsOutputDescriptionsList { get; set; }

        /// <summary>
        /// Gets collection of properties of the class.
        /// </summary>
        public ICollection<TsEnumValue> Values { get; private set; }

		/// <summary>
		/// Initializes a new instance of the TsEnum class with the specific CLR enum.
		/// </summary>
		/// <param name="type">The CLR enum represented by this instance of the TsEnum.</param>
		public TsEnum(Type type)
			: base(type) {
			if (!this.Type.IsEnum) {
				throw new ArgumentException("ClrType isn't enum.");
			}

			this.Values = new List<TsEnumValue>(this.GetEnumValues(type));

			var attribute = this.Type.GetCustomAttribute<TsEnumAttribute>(false);
			if (attribute != null) {
				if (!string.IsNullOrEmpty(attribute.Name)) {
					this.Name = attribute.Name;
				}

				if (!string.IsNullOrEmpty(attribute.Module)) {
					this.Module.Name = attribute.Module;
				}

                this.IsValueAsStringOfName = attribute.ValueAsStringOfName;
                this.IsOutputValuesList = attribute.OutputValuesList;
                this.IsOutputDescriptionsList = attribute.OutputDescriptionsList;
            }
        }

		/// <summary>
		/// Retrieves a collection of possible value of the enum.
		/// </summary>
		/// <param name="enumType">The type of the enum.</param>
		/// <returns>collection of all enum values.</returns>
		protected IEnumerable<TsEnumValue> GetEnumValues(Type enumType) {
			return enumType.GetFields()
				.Where(fieldInfo => fieldInfo.IsLiteral && !string.IsNullOrEmpty(fieldInfo.Name))
				.Select(fieldInfo => new TsEnumValue(fieldInfo));
		}
	}
}