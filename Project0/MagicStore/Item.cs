using System;

namespace MagicStore {
	public class Item {
		private string name;
		private int quantity;
		private double salePrice;  //Customer Price
		private double purchasePrice; //Owner Price

		public Item(Product product, int quantity) {
			this.name = product.Name;
			this.quantity = quantity;
			this.salePrice = product.SalePrice;
			this.purchasePrice = product.PurchasePrice;
		}

		public string Name {
			get {return this.name;}
		}

		public int Quantity {
			get {return this.quantity;}
			set {this.quantity = value;}
		}

		public double SalePrice {
			get {return this.salePrice;}
		}

		public double PurchasePrice {
			get { return this.purchasePrice; }
		}

	}
}
