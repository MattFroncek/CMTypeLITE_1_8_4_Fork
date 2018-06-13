using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeLite.Tests.TestModels {
	[TsClass]
	public class Item {
		public int Id { get; set; }
		public ItemType Type { get; set; }
        public ItemTypeAsString TypeAsString { get; set; }
        public string Name { get; set; }

	    public const int MaxItems = 100;
	}

	public enum ItemType {
		Book = 1,
		Music = 10,
		Clothing = 51
	}

    [TsEnum(ValueAsStringOfName = true, OutputValuesList = true, OutputDescriptionsList = true)]
    public enum ItemTypeAsString
    {
        [TsEnumMember(Description = "Book Type")]
        Book = 1,
        [TsEnumMember(Description = "Music Type")]
        Music = 10,
        [TsEnumMember(Description = "Clothing Type")]
        Clothing = 51
    }
}
