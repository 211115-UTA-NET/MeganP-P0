using System;

namespace MagicStore {
	public class Product {
		private string name;
		private int quantity;
		private double salePrice; //Customer price
		private double purchasePrice; //Owner Price

		public Product(string name, int quantity, double salePrice, double purchasePrice) {
			this.name = name;
			this.quantity = quantity;
			this.salePrice = salePrice;
			this.purchasePrice = purchasePrice;
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
			get {return this.purchasePrice;}
		}

		public void RefillProduct (int numUnits) {
			this.quantity += numUnits;
		}
		
		public void BuyProduct(int numUnits) {
			this.quantity -= numUnits;
		}
	}
}
