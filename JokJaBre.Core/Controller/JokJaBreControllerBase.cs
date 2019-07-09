using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Controller
{
    public class JokJaBreControllerBase : ControllerBase
    {
        protected IActionResult CheckState(object result)
        {
            return !ModelState.IsValid ? BadRequest() : (IActionResult)Ok(result);
        }
    }
}
