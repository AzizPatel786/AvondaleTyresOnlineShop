using AvondaleTyresOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Repository
{
    public class ProductRepository
    {
        public List<ProductModel> GetAllProducts()
        {
            return DataSource();
        }

        public ProductModel GetProductById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<ProductModel> SearchProduct(string item, string authorName)
        {
            return DataSource().Where(x => x.Item.Contains(item) || x.Category.Contains(authorName)).ToList();
        }

        private List<ProductModel> DataSource()
        {
            return new List<ProductModel>()
            {
                new ProductModel(){Id =1, Item="MVC", Category = "Nitish", Description="This is the description for MVC book" },
                new ProductModel(){Id =2, Item="Dot Net Core", Category = "Nitish", Description="This is the description for MVC book" },
                new ProductModel(){Id =3, Item="C#", Category = "Monika", Description="This is the description for MVC book" },
                new ProductModel(){Id =4, Item="Java", Category = "Webgentle", Description="This is the description for MVC book" },
                new ProductModel(){Id =5, Item="Php", Category = "Webgentle", Description="This is the description for MVC book" },
            };
        }
    }
}
