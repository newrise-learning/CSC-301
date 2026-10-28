using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Symbion {
	public class ToolBarBuilder {
		private ToolBar _toolBar;
		public ToolBarBuilder(ToolBar toolBar) {
			_toolBar = toolBar;
		}
		public Button CreateButton(
			string name,
			string text,
			ICommand command = null,
			object commandParameter = null,
			string icon = null) {
			Button item = new Button();
			item.Name = name;
			item.ToolTip = text;
			item.Command = command;
			item.CommandParameter = commandParameter;
			if (icon != null) {
				Image image = new Image();
				image.Stretch = Stretch.None;
				image.Source = new BitmapImage(
					new Uri(icon, UriKind.Relative));
				item.Content = image;
			}
			return item;
		}
		public void AddItem(FrameworkElement item) {
			_toolBar.Items.Add(item);
		}
		public void AddSeparator() {
			_toolBar.Items.Add(new Separator());
		}

		public FrameworkElement GetItem(string name) {
			foreach (FrameworkElement item in _toolBar.Items)
				if (item.Name.Equals(name)) return item;
			return null;
		}
	}
}
