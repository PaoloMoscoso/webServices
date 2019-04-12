using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebServices.Data.Models;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;

namespace WebServices.ODataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code:
            config.EnableCors();
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<User>("Users");
            config.Routes.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
