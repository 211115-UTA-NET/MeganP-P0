using Xunit;
using System.Collections.Generic;
using MagicStore;

namespace MagicStore.Tests {

    public class UnitTest {

        //BankAccount Class Tests
        [Fact]
        public void BankAccount_MakeTransaction_PositiveNumber_True() {
            //Arrange
            Product product = new Product(1, "Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store(2, "Astoria", listProducts);
            Customer customer = new Customer(1, store, "Megan", "Postlewait", "testPassword", 100000);
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
            Product product = new Product(1, "Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store(2, "Astoria", listProducts);
            Customer customer = new Customer(1, store, "Megan", "Postlewait", "testPassword", 100000);
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
            Product product = new Product(1, "Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store(2, "Astoria", listProducts);
            Customer customer = new Customer(1, store, "Megan", "Postlewait", "testPassword", 100000);
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
            Product product = new Product(1, "Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store(2, "Astoria", listProducts);
            Customer customer = new Customer(1, store, "Megan", "Postlewait", "testPassword", 100000);
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
            Product product = new Product(1, "Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store(2, "Astoria", listProducts);
            Customer customer = new Customer(1, store, "Megan", "Postlewait", "testPassword", 1100);
            Item item = new Item(product, 1);

            customer.AddToCart(product, 3);

            //Act
            bool result = customer.MakePurchase();

            //Assert
            Assert.False(result, "False");
        }

        [Fact]
        public void Person_ValidatePassword_IncorrectPassword_True() {
            //Arrange
            Person person = new Person(1, "Megan", "Postlewait", "frodobaggins", 1000);

            //Act
            bool isValid = person.ValidatePassword("frodobaggins");

            //Assert
            Assert.True(isValid, "True");
        }

        [Fact]
        public void Person_ValidatePassword_IncorrectPassword_False() {
            //Arrange
            Person person = new Person(1, "Megan", "Postlewait", "frodobaggins", 1000);

            //Act
            bool isValid = person.ValidatePassword("frodohogins");

            //Assert
            Assert.False(isValid, "False");
        }

        [Fact]
        public void Store_ResupplyProduct_Correct() {
            //Arrange
            Product product = new Product(1, "Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store(2, "Astoria", listProducts);

            //Act
            decimal result = store.ResupplyProduct(product.Name, 14);

            //Assert
            Assert.Equal(expected: 1400, actual: result);
        }

        [Fact]
        public void Order_CTotal_Correct() {
            //Arrange
            Product product = new Product(1, "Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store(2, "Astoria", listProducts);
            Customer customer = new Customer(1, store, "Megan", "Postlewait", "testPassword", 100000);
            Item item = new Item(product, 1);
            List<Item> listItems = new List<Item>();
            listItems.Add(item);
            Order order = new Order(store, customer, listItems);

            //Act
            decimal result = order.CTotal();

            //Assert
            Assert.Equal(expected: 1100, actual: result);
        }

        [Fact]
        public void Order_OTotal_Correct() {
            //Arrange
            Product product = new Product(1, "Poison Apple", 100, 1100, 100);
            List<Product> listProducts = new List<Product>();
            listProducts.Add(product);
            Store store = new Store(2, "Astoria", listProducts);
            Owner owner = new Owner(1, "Megan", "Postlewait", "testPassword", 100000);
            Item item = new Item(product, 1);

            Order order = new Order(store, owner, item);

            //Act
            decimal result = order.OTotal();

            //Assert
            Assert.Equal(expected: 100, actual: result);
        }
    }
}
