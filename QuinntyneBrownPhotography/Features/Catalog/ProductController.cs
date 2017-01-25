using System.Web.Http;

namespace QuinntyneBrownPhotography.Features.Catalog
{
    [Authorize]
    [RoutePrefix("api/product")]
    public class ProductController: ApiController
    {
        public ProductController()
        {

        }
    }
}
