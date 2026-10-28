using System.Windows.Controls;

namespace Symbion {
	public partial class BaseView : UserControl, IView {
		private static IShell _shell;
		private string _region;
		private object _header;
		public virtual string Region {
			get { return _region; }
			set { _region = value; }
		}
		public virtual object Header {
			get { return _header; }
			set { _header = value; }
		}
		public static IShell Shell {
			get { return _shell ?? (_shell = ServiceRepository.Get<IShell>()); }
		}
		public virtual void Show() {
			IRegionAdapter region = Shell.Regions[Region];
			region.Add(this);
		}
		public virtual void Close() {
			IRegionAdapter region = _shell.Regions[Region];
			region.Remove(this);
		}
	}
}