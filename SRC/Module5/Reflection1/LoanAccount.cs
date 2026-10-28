namespace Reflection1 {
	public class LoanAccount {
		int _code;
		string _name;
		decimal _balance;
		decimal _interest;
		int _term;

		public LoanAccount(int code, string name, decimal balance, decimal interest, int term) {
			_code = code;
			_name = name;
			_balance = balance;
			_interest = interest;
			_term = term;
		}

		public decimal Balance {
			get {
				return _balance;
			}
			set {
				_balance = value;
			}
		}

		public override string ToString() {
			return string.Format(
				"{0},{1},{2},{3},{4}",
				_code, _name, _balance, _interest, _term);
		}
	}
}
