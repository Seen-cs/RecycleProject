using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RCTController : Controller
    {
        [HttpPost("balance")]
        public ActionResult balance(string balance)
        {
            var additional = "?a=";
            var accountAddress = balance;
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://goerli.etherscan.io/token/0x4685615246A0Caf18ca0CcED1533CF0659DB4FdE" + additional + accountAddress);
            IWebElement search = driver.FindElement(By.CssSelector("#ContentPlaceHolder1_divFilteredHolderBalance"));
            var deneme = search.Text;
            driver.Close();
            return Ok(deneme);
        }
    }
}
