using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeLite {
	/// <summary>
	/// Gets Description attribute of Enum Member
	/// </summary>
	public sealed class TsEnumMemberAttribute : Attribute {
		/// <summary>
		/// Gets or sets the name of the enum in the script model. If it isn't set, the name of the CLR enum is used.
		/// </summary>
		public string Description { get; set; }
    }
}
