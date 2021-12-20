using System;

namespace MagicStore {
	public class Customer : Person {
		private List<Item>? shoppingCart;
		private Store? store;
		private List<Order>? orderHistory;

		public Customer(Store store, string firstName, string lastName, string password, double initialFunds) : base (firstName, lastName, password, initialFunds) {
			this.store = store;
			orderHistory = new List<Order>();
			shoppingCart = new List<Item>();
		}

		public int AddToCart(Product product, int numItems) {
			if (numItems > 50) {
				Console.WriteLine("Cannot Add more than 50 of any given item.");
				return 0;
			} else {
				if (product.Quantity - numItems >= 0) {
					Item item = new Item(product, numItems);
					this.shoppingCart.Add(item);
					return numItems;
				} else {
					Console.WriteLine("Only " + Convert.ToString(product.Quantity) + " " + product.Name + "s" + " left.\nThe rest have been added to your cart.");
					Item item = new Item(product, product.Quantity);
					this.shoppingCart.Add(item);
					return product.Quantity;
				}
			}
		}

		public void PrintCart() {
			for (int i = 0; i < shoppingCart.Count; i++) {
				Console.WriteLine(i + ". " + shoppingCart[i].Quantity + "x " + shoppingCart[i].Name);
            }
        }

		public bool MakePurchase() {
			Order order = new Order(this.store, this, this.shoppingCart);
			bool success = this.bankAccount.MakeTransaction(order);
			if (success == true) {
				this.store.MakePurchase(order);
				this.shoppingCart.Clear();
				this.orderHistory.Add(order);
				return true;
			} else {
				return false;
			}
		}
	}
}
