using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;

namespace Symbion {
	public class PrincipalAuthorization : BaseService, IAuthorization {
		private IPrincipal _principal;
		public string UserName {
			get { return _principal.Identity.Name; }
		}
		public PrincipalAuthorization() { 
			_principal = Thread.CurrentPrincipal;
		}
		public bool IsInRole(string roleName) {
			return _principal.IsInRole(roleName); }
		public bool IsInAnyRoles(IEnumerable<string> roleNames) {
			foreach (string roleName in roleNames)
				if (_principal.IsInRole(roleName)) return true;
			return false;
		}
		public bool IsInAllRoles(IEnumerable<string> roleNames) {
			foreach (string roleName in roleNames)
				if (!_principal.IsInRole(roleName)) return false;
			return true;
		}
	}
}
