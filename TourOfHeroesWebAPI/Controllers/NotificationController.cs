using Microsoft.AspNetCore.Mvc;
using TourOfHeroesCore.Interfaces;

namespace TourOfHeroesWebAPI.Controllers
{
    public class NotificationController : RootController
    {
        private readonly INotificationPool notificationPool;

        public NotificationController(INotificationPool notificationPool)
        {
            this.notificationPool = notificationPool;
        }

        [HttpGet]
        public IActionResult GetNotifications()
        {
            return Ok(notificationPool.GetNotifications());
        }
    }
}