using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbion {
	public interface IAuthorization : IService {
		string UserName { get; }
		bool IsInRole(string roleName);
		bool IsInAnyRoles(IEnumerable<string> roleNames);
		bool IsInAllRoles(IEnumerable<string> roleNames);
	}
}
