using System;
using System.Windows.Controls;

namespace Symbion {
	public partial class BaseView : UserControl, IView {
		private static IShell _shell;
		public static IShell Shell {
			get {
				return _shell ?? (
					_shell = ServiceRepository.Get<IShell>());
			}
		}

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
		public void Close() {
			IRegionAdapter region = Shell.Regions[Region];
			region.Remove(this);
		}
		public void Show() {
			IRegionAdapter region = Shell.Regions["main"];
			region.Add(this);
		}
	}
}
