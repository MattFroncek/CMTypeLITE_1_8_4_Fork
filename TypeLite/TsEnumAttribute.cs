using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeLite {
	/// <summary>
	/// Configures an enum to be included in the script model.
	/// </summary>
	[AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
	public sealed class TsEnumAttribute : Attribute {
		/// <summary>
		/// Gets or sets the name of the enum in the script model. If it isn't set, the name of the CLR enum is used.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets name of the module for the enum. If it isn't set, the namespace is used.
		/// </summary>
		public string Module { get; set; }

        /// <summary>
        /// Gets or sets whether to set the value equal to a string of the enum name.
        /// </summary>
        public bool ValueAsStringOfName { get; set; }

        /// <summary>
        /// Gets or sets whether to output an enumerator called _ValuesList with a list of values pipe separated. Example: _ValuesList = 'HCollars|DCollars|CCollars'
        /// </summary>
        public bool OutputValuesList { get; set; }

        /// <summary>
        /// Gets or sets whether to output an enumerator called _DescriptionsList with a list of descriptions pipe separated. Example: _DescriptionsList = 'Horse Collars|Dog Collars|Cat Collars'
        /// Values come from attribute on enumerators like: 
        /// [TsEnumMemberAttribute(Description="Horse Collars")]
        /// HCollars = 1,
        /// </summary>
        public bool OutputDescriptionsList { get; set; }
    }
}
