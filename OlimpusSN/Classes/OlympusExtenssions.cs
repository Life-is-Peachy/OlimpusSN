using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OlimpusSN.Models
{
    public static class OlympusExtenssions
    {
        public static long GetId(this Controller controller)
            => Convert.ToInt64(controller.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
