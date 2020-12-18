using System.Collections.Generic;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Controllers
{
    //[Authorize]
    public class ProductController : ApiController
    {
        public IList<ProductModel> Get()
        { 
            var data = new ProductData();

            return data.GetAllProducts();
        }
    }
}