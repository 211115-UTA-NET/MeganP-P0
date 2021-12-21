using System.Data.SqlClient;

namespace MagicStore {
    public class Program {

        public static void Main() {
            Product poisonedApple = new Product(1, "Poisoned Apple", 100, 1100, 110);
            Product darkCurse = new Product(1, "Dark Curse", 5, 5000, 500);
            Product magicBean = new Product(1, "Magic Bean", 2, 10000, 1000);
            Product forgettingPotion = new Product(1, "Forgetting Potion", 5000, 100, 10);
            Product locatorPotion = new Product(1, "Locator Potion", 5000, 100, 10);
            Product sleepingCurse = new Product(1, "Sleeping Curse", 400, 2000, 200);
            Product mermaidLegsBracelet = new Product(1, "Mermaid Legs Bracelet", 6, 7500, 750);
            Product flyingCarpet = new Product(1, "Flying Carpet", 1, 1100, 110);
            Product lostSoulsWater = new Product(1, "Water from the River of Lost Souls", 10, 3000, 300);
            Product squidInk = new Product(1, "Squid Ink", 30, 300, 30);

            List<Product> products = new List<Product>();
            products.Add(poisonedApple);
            products.Add(darkCurse);
            products.Add(magicBean);
            products.Add(forgettingPotion);
            products.Add(locatorPotion);
            products.Add(sleepingCurse);
            products.Add(mermaidLegsBracelet);
            products.Add(flyingCarpet);
            products.Add(lostSoulsWater);
            products.Add(squidInk);

            Store store = new Store(1, "Rochester", products);
            Customer customer = new Customer(2, store, "Myra", "Gold", "testtesttest", 12000);
            customer.AddToCart(poisonedApple, 2);
            customer.AddToCart(squidInk, 3);

            Item item1 = new Item(poisonedApple, 2);
            Item item2 = new Item(squidInk, 3);
            List<Item> shoppingCart = new List<Item>();
            shoppingCart.Add(item1);
            shoppingCart.Add(item2);

            Order order = new Order(store, customer, shoppingCart);
            customer.SaveOrder(order);


        }
    }
}

    


