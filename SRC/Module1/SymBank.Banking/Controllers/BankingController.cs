using SymBank.Banking.Services;
using Symbion;

namespace SymBank.Banking.Controllers {
//	[Service(typeof(IAccountController)]
//	[Service(typeof(ITransactionController))]
	[Service(ServiceType = typeof(IAccountController))]
	[Service(ServiceType = typeof(ITransactionController))]
	public class BankingController : IAccountController, ITransactionController {
	}
}
