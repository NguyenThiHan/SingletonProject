using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSingleton
{
    class Store
    {
        public int IdStore { get; set; }
        public string NameStore { get; set; }
        public List<Product> Products { get; set; }
        public Store(int idStore, string nameStore)
        {
            Products = new List<Product>();
            IdStore = idStore;
            NameStore = nameStore;
        }

    }
    class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string CodeProduct { get; set; }
        public string QualityProduct { get; set; }

        public Product(int idProduct, string nameProduct, string codeProduct, string qualityProduct)
        {
            IdProduct = idProduct;
            NameProduct = nameProduct;
            CodeProduct = codeProduct;
            QualityProduct = qualityProduct;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, NameProduct: {1}, CodeProduct: {2}, QualityProduct: {3}", IdProduct, NameProduct, CodeProduct, QualityProduct);
        }
    }
    class StoreSampleDB
    {
        private static StoreSampleDB _instance;

        private List<Store> _stores = new List<Store>();
        private List<Product> _listproduct = new List<Product>();

        public static StoreSampleDB Instance()
        {
            if (_instance == null)
            {
                _instance = new StoreSampleDB();
            }
            return _instance;
        }

        public void AddStore(Store store)
        {
            this._stores.Add(store);
        }
        public void AddProduct(Product product)
        {
            this._listproduct.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            this._listproduct.Remove(product);
        }
        public void AddProductForStore(int storeId, Product product)
        {
            Store result = _stores.Find(item => item.IdStore == storeId);
            if (result != null)
            {
                result.Products.Add(product);
            }
            else
            {
                Console.WriteLine("Not Fount!");
            }
        }

        public void AddProductForStore(int storeId, int idProduct)
        {
            Store store = _stores.Find(item => item.IdStore == storeId);
            if (store != null)
            {
                var product = _listproduct.Find(n => n.IdProduct == idProduct);
                if (product != null)
                    store.Products.Add(product);
            }
            else
            {
                Console.WriteLine("Not Fount!");
            }
        }

        public void UpdateProduct(int idProduct, string nameProduct, string codeProduct, string qualityProduct)
        {
            Product result = _listproduct.Find(item => item.IdProduct == idProduct);
            if (result != null)
            {
                result.IdProduct = idProduct;
                result.NameProduct = nameProduct;
                result.CodeProduct = codeProduct;
                result.QualityProduct = qualityProduct;
            }
            else
            {
                Console.WriteLine("Not Fount !!!!");
            }
        }
        public Product FindProductInStore(int storeId, int productId)
        {
            //find Store 
            Store store = _stores.Find(item => item.IdStore == storeId);
            //check store
            return store != null ? store.Products.Find(item => item.IdProduct == productId) : null;
        }

    }
    public static  class SingletonSample
    {
      public  static void Test()
        {
            StoreSampleDB db = StoreSampleDB.Instance();

            #region Add stores into Database
            Store store1 = new Store(1, "Store1");
            Store store2 = new Store(2, "Store2");
            db.AddStore(store1);
            db.AddStore(store2); 
            #endregion

            #region Add products into Database
            Product product1 = new Product(1, "Item1", "Code1", "Good");
            Product product2 = new Product(2, "Item2", "Code2", "Bad");
            Product product3 = new Product(3, "Item3", "Code3", "Good");
            Product product4 = new Product(4, "Item4", "Code4", "Bad");
            Product product5 = new Product(5, "Item5", "Code5", "Good");

            db.AddProduct(product1);
            db.AddProduct(product2);
            db.AddProduct(product3);
            db.AddProduct(product4);
            db.AddProduct(product5);

            #endregion
            
            //Add store
            //Add product in store 1
            db.AddProductForStore(1, 1);
            db.AddProductForStore(1, 2);
            db.AddProductForStore(1, 3);

            //Add product in store 2
            db.AddProductForStore(2, 1);
            db.AddProductForStore(2, 4);
            db.AddProductForStore(2, 5);

            Console.WriteLine("-----Product1 in Store1 before editing-----");
            var product22 = db.FindProductInStore(1, 1);
            Console.WriteLine(product22.ToString());
            Console.WriteLine("==========");

            //Modifile product 1
            db.UpdateProduct(1, "Item6", "XYZ", "Like");
            //Display result

            Console.WriteLine("-----Result in Store1 after editing-----");
            var product11 = db.FindProductInStore(1, 1);
            Console.WriteLine(product11.ToString());
            Console.WriteLine("==========");

            Console.WriteLine("-----Result in Store2 -----");
            product11 = db.FindProductInStore(2, 1);
            Console.WriteLine(product11.ToString());
            Console.WriteLine("==========");

            Console.ReadKey();
        }
    }
}
