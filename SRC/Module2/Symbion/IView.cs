namespace Symbion {
	public interface IView {
		string Region { get; set; }
		object Header { get; set; }
		void Show();
		void Close();
	}
}
