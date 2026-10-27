using System;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace Symbion {
	public class MenuBarBuilder {
		private Menu _menuBar;

		public MenuBarBuilder(Menu menuBar ) {
			_menuBar = menuBar;
		}

		public MenuItem Create(
			string name,
			string text,
			ICommand command = null,
			object commandParameter = null,
			string icon = null) {
			MenuItem item = new MenuItem();
			item.Name = name;
			item.Header = text;
			item.Command = command;
			item.CommandParameter = commandParameter;
			if (icon != null) {
				Image image = new Image();
				image.Stretch = Stretch.None;
				image.Source = new BitmapImage(
					new Uri(icon, UriKind.Relative));
				item.Icon = image;
			}

			if (item == null)
				throw new Exception("Item is null");
			return item;
		}
		public void AddMenu(MenuItem item) {
			_menuBar.Items.Add(item);
		}
		public void AddItem(MenuItem menu, MenuItem item) {
			menu.Items.Add(item);
		}
		public void AddSeparator(MenuItem menu) {
			menu.Items.Add(new Separator());
		}
		public MenuItem GetMenu(string name) {
			foreach (FrameworkElement item in _menuBar.Items)
				if (item.Name.Equals(name))
					return (MenuItem)item;
			return null;
		}
		public MenuItem GetItem(MenuItem menu, string name) {
			foreach (FrameworkElement item in menu.Items)
				if(item.Name.Equals(name))
					return (MenuItem)item;
			return null;
		}
	}
}
