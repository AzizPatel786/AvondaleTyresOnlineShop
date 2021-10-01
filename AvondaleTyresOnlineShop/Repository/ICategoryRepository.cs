using AvondaleTyresOnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetCategories();
    }
}
