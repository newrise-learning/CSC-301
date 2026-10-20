using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbion {
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class ServiceAttribute : Attribute {
		private Type _serviceType;
		public Type ServiceType {
			get {
				return _serviceType;
			}
			set {
				_serviceType = value;
			}
		}
		public ServiceAttribute() { }
		public ServiceAttribute(Type serviceType) {
			_serviceType = serviceType;
		}
	}
}
