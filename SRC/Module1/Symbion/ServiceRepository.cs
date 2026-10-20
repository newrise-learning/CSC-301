using System;
using System.Collections.Generic;

namespace Symbion {
	public static class ServiceRepository {
		private static Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

		public static bool Add<TService>(this TService serviceObject) where TService : IService {
			Type serviceType = typeof(TService);
			if (!_services.ContainsKey(serviceType)) {
				_services.Add(serviceType, serviceObject);
				return true;
			}	return false;
		}

		public static TService Get<TService>() where TService : IService {
			IService serviceObject = null;
			Type serviceType = typeof(TService);
			_services.TryGetValue(serviceType, out serviceObject);
			return (TService)serviceObject;
		}
	}
}
