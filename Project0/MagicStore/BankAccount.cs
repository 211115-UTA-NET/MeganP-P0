using System;

namespace MagicStore {
	public class BankAccount {
		private double balance;
		private List<Order>? transactionHistory;
		private Person accountOwner;

		public BankAccount(Person accountOwner, double initialFunds) {
			this.accountOwner = accountOwner;
			transactionHistory = new List<Order>();
			if (initialFunds > 0) {
				this.balance = initialFunds;
			} else {
				while (true) {
					Console.WriteLine("Must have positive funds.\nPlease Enter You Positive Non-Zero initial balance");
					double.TryParse(Console.ReadLine(), out initialFunds);
					if (initialFunds > 0) {
						this.balance = initialFunds;
						break;
					}
				}
			}
		}
		
		public List<Order> TransactionHistory {
			get {return this.TransactionHistory;}
		}

		public bool MakeTransaction (Order order) {
			if (balance - order.Total < 0) {
				Console.WriteLine("Card Denied: Insufficent Funds");
				return false;
			} else {
				this.transactionHistory.Add(order);
				balance -= order.Total;
				return true;
			}
		}

		public string OrdersToString() {
			string? orders = "";

			for (int i = 0; i < this.transactionHistory.Count; i++) {
				orders += this.transactionHistory[i].ToString() + "\n";
			}
			return orders;
		}
	}
}
