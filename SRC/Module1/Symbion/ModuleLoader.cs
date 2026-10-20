using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Symbion {
	public static class ModuleLoader {
		private static List<IModule> _modules = new List<IModule>();
		public static void Init() {
			foreach (IModule module in _modules) {
				module.Init();
				module.AddServices();
			}
		}
		public static void Exit() {
			foreach (IModule module in _modules)
				module.Exit();
		}
		public static void Load (string path) {
			IAuthorization auth = ServiceRepository.Get<IAuthorization>();
			ILogger logger = ServiceRepository.Get<ILogger>();
			ModuleList list = ModuleList.Load(path);
			foreach (ModuleItem item in list.Items) {
				if (item.Roles.Count > 0 && !auth.IsInAnyRoles(item.Roles)) {
					Debug.WriteLine(string.Format(
						"User not authorized for module {0}", item.Path));
					continue;
				}
				if (!File.Exists(item.Path))
					logger.Error(string.Format(
						"Cannot locate module {0}.", item.Path));
				Assembly assembly = null;
				try {
					assembly = Assembly.LoadFrom(item.Path);
				}
				catch (Exception ex) {
					logger.Error(string.Format(
						"Error {0} occcurred loading module {1}.",
						ex.Message, item.Path));
					continue;
				}
				Type moduleType = assembly.GetType(item.Name);
				if (moduleType == null) {
					logger.Error(string.Format(
						"Cannot find class {0} in module {1}.",
						item.Name, item.Path));
					continue;
				}
				try {
					_modules.Add((IModule)Activator.CreateInstance(moduleType));
					Debug.WriteLine(string.Format("Module {0} loaded succesfully.",item.Path));
				}
				catch (Exception ex) {
					logger.Error(string.Format(
						"Error '{0}' instancing {1} in module {2}.",
						ex.Message, item.Name, item.Path));
				}
			}
		}
	}
}
