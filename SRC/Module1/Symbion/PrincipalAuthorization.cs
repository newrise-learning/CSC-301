using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Symbion {
	public class PrincipalAuthorization : BaseService, IAuthorization {

		private IPrincipal _principal;

		public PrincipalAuthorization() {
			_principal = Thread.CurrentPrincipal;
		}

		public string UserName {
			get {
				return _principal.Identity.Name;
			}
		}

		public bool IsInAllRoles(IEnumerable<string> roleNames) {
			foreach (string roleName in roleNames)
				if (_principal.IsInRole(roleName)) return true;
			return false;
		}

		public bool IsInAnyRoles(IEnumerable<string> roleNames) {
			foreach (string roleName in roleNames)
				if (!_principal.IsInRole(roleName)) return false;
			return true;
		}

		public bool IsInRole(string roleName) {
			return _principal.IsInRole(roleName);
		}
	}
}
