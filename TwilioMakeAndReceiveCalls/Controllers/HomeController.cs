using System;
using System.Web.Mvc;
using Twilio;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace TwilioMakeAndReceiveCalls.Controllers
{
    public class HomeController : TwilioController
    {
        //Get: Index
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: MakeCall
        public ActionResult MakeCall(string id)
        {
            
            // Instantiate new Rest API object
            var client = new TwilioRestClient(Settings.AccountSid, Settings.AuthToken);
            client.InitiateOutboundCall(Settings.MyNumber, string.Format("+{0}", id), "http://www.televisiontunes.com/uploads/audio/Star%20Wars%20-%20The%20Imperial%20March.mp3");

            return Content("The call has been is initiated");
        }

        // Get: ReceiveCall
        public ActionResult ReceiveCall()
        {
            var twiml = new TwilioResponse();
            return TwiML(twiml.Say("You are calling Marcos Placona").Dial(Settings.MyNumber));
        }
    }
}