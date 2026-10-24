using Accessibility;
using SymBank.Banking.Services;
using Symbion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymBank.Banking.Controllers {
	[Service(typeof(IAccountController))]
	[Service(typeof(ITransactionController))]
	// [Service(ServiceType = typeof(IAccountController))]
	// [Service(ServiceType = typeof(ITransactionController))]
	public class BankingController : IAccountController, ITransactionController {
	}
}
