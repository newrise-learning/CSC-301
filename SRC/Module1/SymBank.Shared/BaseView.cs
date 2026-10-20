using Symbion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SymBank.Shared {
	public class BaseView : UserControl, IView {
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
		public virtual void Show() {
			IRegionAdapter region = _shell.Regions[Region];
		}
		public virtual void Close() { }

	}
}
