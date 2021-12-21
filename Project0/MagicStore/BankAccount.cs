using System;

namespace MagicStore {
	public class BankAccount {
		private double balance;
		private Person accountOwner;

		public BankAccount(Person accountOwner, double initialFunds) {
			this.accountOwner = accountOwner;
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

		public bool MakeTransaction (Order order) {
			if (balance - order.Total < 0) {
				Console.WriteLine("Card Denied: Insufficent Funds");
				return false;
			} else {
				balance -= order.Total;
				return true;
			}
		}
	}
}
