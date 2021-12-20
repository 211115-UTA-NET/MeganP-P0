using Xunit;
using System.Collections.Generic;
using MagicStore;

namespace MagicStore.Tests {

    public class UnitTest {

        //BankAccount Class Tests
        [Fact]
        public void BankAccount_MakeTransaction_PositiveNumber_True() {
            //Arrange
            Product product = new Product("Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store("Astoria", listProducts);
            Customer customer = new Customer(store, "Megan", "Postlewait", "meganpostlewait", "testPassword", 100000);
            Item item = new Item(product, 1);
            List<Item> listItems = new List<Item>();
            listItems.Add(item);
            Order order = new Order(store, customer, listItems);
            BankAccount bankAccount = new BankAccount(customer, 100000);

            //Act
            bool result = bankAccount.MakeTransaction(order);

            //Assert
            Assert.True(result, "True");

        }
        
        [Fact]
        public void BankAccount_MakeTransaction_Zero_True() {
            //Arrange
            Product product = new Product("Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store("Astoria", listProducts);
            Customer customer = new Customer(store, "Megan", "Postlewait", "meganpostlewait", "testPassword", 100000);
            Item item = new Item(product, 1);
            List<Item> listItems = new List<Item>();
            listItems.Add(item);
            Order order = new Order(store, customer, listItems);
            BankAccount bankAccount = new BankAccount(customer, 1100);

            //Act
            bool result = bankAccount.MakeTransaction(order);

            //Assert
            Assert.True(result, "True");

        }  

        [Fact]
        public void BankAccount_MakeTransaction_NegativeNumber_False() {
            //Arrange
            Product product = new Product("Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store("Astoria", listProducts);
            Customer customer = new Customer(store, "Megan", "Postlewait", "meganpostlewait", "testPassword", 100000);
            Item item = new Item(product, 1);
            List<Item> listItems = new List<Item>();
            listItems.Add(item);
            Order order = new Order(store, customer, listItems);
            BankAccount bankAccount = new BankAccount(customer, 100);

            //Act
            bool result = bankAccount.MakeTransaction(order);

            //Assert
            Assert.False(result, "False");

        } 

        //Customer Class Tests
        [Fact]
        public void Customer_MakePurchase_PositiveFunds_True() {
            //Arrange
            Product product = new Product("Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store("Astoria", listProducts);
            Customer customer = new Customer(store, "Megan", "Postlewait", "meganpostlewait", "testPassword", 100000);
            Item item = new Item(product, 1);

            customer.AddToCart(product, 3);

            //Act
            bool result = customer.MakePurchase();

            //Assert
            Assert.True(result, "True");
        }

        [Fact]
        public void Customer_MakePurchase_NegativeFunds_False() {
            //Arrange
            Product product = new Product("Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store("Astoria", listProducts);
            Customer customer = new Customer(store, "Megan", "Postlewait", "meganpostlewait", "testPassword", 1100);
            Item item = new Item(product, 1);

            customer.AddToCart(product, 3);

            //Act
            bool result = customer.MakePurchase();

            //Assert
            Assert.False(result, "False");
        }
    }
}
