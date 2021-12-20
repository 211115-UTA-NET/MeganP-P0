using System;

namespace MagicStore {
	public class Order {
		private Store store;
		private Person customer;
		private DateTime timeStamp;
		private List<Item>? items;
		private double total;

		public Order(Store store, Customer customer, List<Item> items) {
			this.store = store;
			this.customer = customer;
			this.timeStamp = DateTime.Now;
			this.items = items;
			this.total = this.CTotal();
		}

		public Order(Store store, Owner owner, Item item) {
			this.store = store;
			this.customer = owner;
			this.items.Add(item);
			this.total = this.OTotal();
        }

		public List<Item> Items {
			get {return this.items;}
		}	 

		public double Total {
			get { return this.total; }
		}

		public double CTotal() {
			double total = 0;
			for (int i = 0; i < items.Count; i++) {
				total += (items[i].Quantity * items[i].SalePrice);	
			}
			return total;
		}

		public double OTotal() {
			double total = 0;
			for (int i = 0; i < items.Count; i++) {
				total += (items[i].Quantity * items[i].PurchasePrice);
			}
			return total;
		}

		public string ToString() {
			//string order = "Store Location: " + this.store.Name + "\nTotal: " + Convert.ToString(total) + "\nDateTime: " + timeStamp.ToString("g", "en-US\n");
			for (int i = 0; i < this.items.Count; i++) {

			}
			return "good for now";
		}
	}
}
