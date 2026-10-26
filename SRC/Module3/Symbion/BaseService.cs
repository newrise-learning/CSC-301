namespace Symbion {
	public class BaseService : IService {
		private static IShell _shell;
		public static IShell Shell {
			get {
				return _shell ?? (_shell =
				ServiceRepository.Get<IShell>());
			}
		}
	}
}
