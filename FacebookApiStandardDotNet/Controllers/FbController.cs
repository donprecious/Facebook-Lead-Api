using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FacebookApiStandardDotNet.Services;
namespace FacebookApiStandardDotNet.Controllers
{
    //[Produces("application/json")]
    [RoutePrefix("api/fb")]
    public class FbController : ApiController
    {
        [HttpGet]
        [Route("leads")]
        public  IHttpActionResult GetLeads()
        {
            var leads = new FacebookLeads().GetLeadData();
            return Ok(leads);
        }

        [HttpGet]
        [Route("leads/{leadId}")]
        public IHttpActionResult GetLeads(string leadId)
        {
            var leads = new FacebookLeads().GetLeadData(leadId);
            return Ok(leads);
        }

        [HttpGet]
        [Route("ads/{adId}/leads")]
        public IHttpActionResult GetLeadsbyAdsId(string adId)
        {
            var leads = new FacebookLeads().GetAdsLeadData(adId);
            return Ok(leads);
        }

        [HttpGet]
        [Route("Form/{formId}/leads")]
        public IHttpActionResult GetLeadsbyFormId(string formId)
        {
            var leads = new FacebookLeads().GetLeadByFormId(formId);
            return Ok(leads);
        }
    }
}
