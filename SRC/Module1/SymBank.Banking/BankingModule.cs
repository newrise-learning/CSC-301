using SymBank.Banking.Controllers;
using SymBank.Banking.Services;
using Symbion;

namespace SymBank.Banking {
	public class BankingModule : BaseModule {
		public override void Init() {
			base.Init();
			var obj = new BankingController();
			obj.Add<IAccountController>();
			obj.Add<ITransactionController>();
		}
	}
}
