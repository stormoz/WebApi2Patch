namespace WebApi2Patch.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.OData;
    using WebApi2Patch.Models;

    //the code is only to demo usage of PATCH with Delta

    //http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/DeltaJsonDeserialization/DeltaJsonDeserialization.Server/Controllers/PatchController.cs
    public class ProductsController : ApiController
    {
        //PUT http://localhost:63491/api/Products/1
        //{"Name":"asdf","Id":"123","Flag":true}
        public void Put(int id, [FromBody]ProductModel model)
        {
            if (ModelState.IsValid)
            {
                //update - replace (200)
            }
            else
            {
                //400
            }
        }

        //PATCH http://localhost:63491/api/Products/1
        //{"Flag":true}
        public void Patch(int id, [FromBody]Delta<ProductModel> deltaModel)
        {
            if (deltaModel.GetChangedPropertyNames().Any())
            {
                var model = GetProductModelById(id);

                if (model != null)
                {
                    deltaModel.Patch(model);
                    this.Validate(model);

                    if (ModelState.IsValid)
                    {
                        //update - partial (200)
                    }
                    else
                    {
                        //invalid 400
                    }
                }
            }
            //wrong format (400)
        }

        //should be repo in real life
        ProductModel GetProductModelById(int id)
        {
            return new ProductModel { Code = "1", Name = "blabla", Flag = false };
        }
    }
}
