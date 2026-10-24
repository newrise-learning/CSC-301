using System.Collections.Generic;
using System.Xml.Serialization;

namespace Symbion {
	[XmlType("Module")]
	public class ModuleItem {
		[XmlAttribute]public string Name { get; set; }
		[XmlAttribute]public string Path { get; set; }
		[XmlArrayItem("Role")]public List<string> Roles { get; set; }
		public ModuleItem() { Roles = new List<string>(); }
	}
}