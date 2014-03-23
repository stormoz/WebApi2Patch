namespace WebApi2Patch.Controllers
{
    using System.Linq;

    using WebApi2Patch.Models;
    using System.Web.Http.OData;
    using System.Web.Http;

    //http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/DeltaJsonDeserialization/DeltaJsonDeserialization.Server/Controllers/PatchController.cs
    public class ProductsController : ApiController
    {
        //PUT http://localhost:63491/api/Products/1
        //{"Name":"asdf","Id":"123","Flag":true}
        public void Put(int id, [FromBody]ProductModel model)
        {
            if (ModelState.IsValid)
            {
                //update - replace
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
                        //update - partial
                    }
                    else
                    {
                        //400
                    }
                }
            }
            
            //nothing changed or wrong format
        }

        //should be repo in real life
        ProductModel GetProductModelById(int id)
        {
            return new ProductModel { Code = "1", Name = "blabla", Flag = false };
        }
    }
}
