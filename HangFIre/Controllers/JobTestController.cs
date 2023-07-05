using Hangfire;
using HangFIre.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangFIre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTestController : ControllerBase
    {
        private readonly IJobTestService _jobTestService;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public JobTestController(IJobTestService jobTestService, IBackgroundJobClient backgroundJobClient)
        {
            _jobTestService = jobTestService;
            _backgroundJobClient = backgroundJobClient;
        }
        [HttpGet]
        [Route("login")]
        public String Login()
        {
            //Fire - and - Forget Job - this job is executed only once
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Welcome to Shopping World!"));

            return $"Job ID: {jobId}. Welcome mail sent to the user!";
        }

        [HttpGet]
        [Route("productcheckout")]
        public String CheckoutProduct()
        {
            //Delayed Job - this job executed only once but not immedietly after some time.
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("You checkout new product into your checklist!"), TimeSpan.FromSeconds(20));

            return $"Job ID: {jobId}. You added one product into your checklist successfully!";
        }

        [HttpGet]
        [Route("productpayment")]
        public String ProductPayment()
        {
            //Fire and Forget Job - this job is executed only once
            var parentjobId = BackgroundJob.Enqueue(() => Console.WriteLine("You have done your payment suceessfully!"));

            //Continuations Job - this job executed when its parent job is executed.

            return "You have done payment and receipt sent on your mail id!";
        }

        [HttpGet]
        [Route("dailyoffers")]
        public String DailyOffers()
        {
            //Recurring Job - this job is executed many times on the specified cron schedule
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), Cron.Daily);

            return "offer sent!";
        }
    }
}
