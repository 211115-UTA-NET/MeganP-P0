using System;

namespace MagicStore {
	public class Store : ILoadOrderHistory {
		private string location;
		private List<Product>? inventory;
		private int ID;

		public Store (int ID, string location, List<Product> inventory) {
			this.location = location;
			this.inventory = inventory;
			this.ID = ID;
		}

		public int Id {
			get { return this.ID; } 
		}

		public string Name {
			get {return this.location;}
		}

		public List<Product> Inventory {
			get { return this.inventory; }
		}

		public bool MakePurchase(Order order) {
			for (int i = 0; i < order.Items.Count; i++) {
				for (int j = 0; j < inventory.Count; j++) {
					if (order.Items[i].Name == inventory[j].Name) {
						inventory[i].Quantity-= order.Items[i].Quantity;
						break;
					}
				}
			}
			Console.WriteLine("Purchase Successful with the Store");
			return true;
		}

		public void ResupplyStore() {
			//implement
		}

		public void AddProductToInventory(Product product) {
			this.inventory.Add(product);
		}

		public double ResupplyProduct(string product, int quantity) {
			double total = 0;
			for (int i = 0; i < inventory.Count; i++) {
				if (inventory[i].Name == product) {
					total = quantity * inventory[i].PurchasePrice;
					inventory[i].RefillProduct(quantity);
					break;
				}
			}
			return total;
		}

		public void LoadOrderHistory() {

        }
	}
}
