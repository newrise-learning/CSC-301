using System;

namespace Symbion {
	public class BaseModule : IModule {
		public virtual void Init() { }
		public virtual void Exit() { }
	}
}
