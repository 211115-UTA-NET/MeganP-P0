using System;

namespace MagicStore {
	public class Product {
		private int ID;
		private string name;
		private int quantity;
		private double salePrice; //Customer price
		private double purchasePrice; //Owner Price

		public Product(int ID, string name, int quantity, double salePrice, double purchasePrice) {
			this.ID = ID;
			this.name = name;
			this.quantity = quantity;
			this.salePrice = salePrice;
			this.purchasePrice = purchasePrice;
		}

		public int Id {
			get { return ID; }
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
