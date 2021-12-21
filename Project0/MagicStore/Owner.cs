using System; 

namespace MagicStore {
	public class Owner : Person, ISaveOrder {
		private List<Store>? stores;
		
		public Owner (int ID, string firstName, string lastName, string password, double initialFunds) : base (ID, firstName, lastName, password, initialFunds) {
			
		}

		public bool ResupplyProduct(Store store, string productName, int quantity) {

			for (int i = 0; i < store.Inventory.Count; i++) {
				if (store.Inventory[i].Name == productName) {
					Item item = new Item(store.Inventory[i], quantity);
					Order order = new Order(store, this, item);
					return this.bankAccount.MakeTransaction(order);

				}
			}
			return false;
        }

		public void SaveOrder(Order order) {

		}

	}
}
