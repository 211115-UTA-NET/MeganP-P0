using System;
using System.Data.SqlClient;

namespace MagicStore {
	public class Customer : Person, ISaveOrder, ILoadOrderHistory {
		private List<Item>? shoppingCart;
		private Store? store;
		

		public Customer(int ID, Store store, string firstName, string lastName, string password, double initialFunds) : base (ID, firstName, lastName, password, initialFunds) {
			this.store = store;
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
				this.SaveOrder(order);
				return true;
			} else {
				return false;
			}
		}

		public void SaveOrder(Order order) {
			string connectionString = File.ReadAllText("StringConnection.txt");
			using SqlConnection connection = new(connectionString);
			
			connection.Open();
			string insertOrder = $"INSERT INTO Orders(StoreID, PersonID, Total) VALUES ({this.store.Id}, {this.ID}, {order.Total});";
			using SqlCommand command = new(insertOrder, connection);
			using SqlDataReader reader = command.ExecuteReader();
			connection.Close();

			connection.Open();
			string getOrderID = "SELECT MAX(OrderID) FROM Orders;";
			using SqlCommand getOrderCommand = new SqlCommand(getOrderID, connection);
			using SqlDataReader getOrderReader = getOrderCommand.ExecuteReader();
			getOrderReader.Read();
			int OrderID = getOrderReader.GetInt32(0);
			connection.Close();

			for (int i = 0; i < shoppingCart.Count; i++) {

				connection.Open();
				string insertItems = $"INSERT INTO PurchasedItems(OrderID, ProductID, Quantity, Price) VALUES ({OrderID}, {shoppingCart[i].ProductID}, {shoppingCart[i].Quantity}, {shoppingCart[i].SalePrice});";
				using SqlCommand sqlCommand = new SqlCommand(insertItems, connection);	
				using SqlDataReader sqlReader = sqlCommand.ExecuteReader();
				connection.Close();
			}
        }

		public void LoadOrderHistory() {											  

        }
	}
}
