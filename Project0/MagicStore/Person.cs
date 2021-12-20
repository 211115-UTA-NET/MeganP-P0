using System;

namespace MagicStore {
	public class Person {
		private string? firstName;
		private string? lastName;
		private string? password;
		private readonly string? username;
		protected BankAccount? bankAccount;

		public Person() {
			bankAccount = new BankAccount(this, 0);
		}

		public Person (string firstName, string lastName,  string password, double initialFunds) {
			this.firstName = firstName;
			this.lastName = lastName;
			this.username = firstName + lastName;
			this.password = password;
			bankAccount = new BankAccount(this, initialFunds);
		}

		public string FirstName {
			get {return this.firstName;}
		}

		public string LastName {
			get {return this.lastName;}
		}

		public void ForgotPassword() {
			Console.WriteLine("Please Enter Your New Password:");
			string password = Console.ReadLine();
			this.password = password;
		}
	}
}
