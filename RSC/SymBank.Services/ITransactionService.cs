using System;
using Symbion;
using System.ServiceModel;

namespace SymBank.Services {
	[ServiceContract]
	public interface ITransactionService : IService {
		[OperationContract]int Debit(int source, decimal amount);
		[OperationContract]int Credit(int source, decimal amount);
		[OperationContract]int Transfer(int source, int target, decimal amount);
	}
}
