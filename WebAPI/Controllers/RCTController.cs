using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V107.Database;
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
            var walletAddress = "";
            try
            {
                var additional = "?a=";
                var accountAddress = balance;
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://goerli.etherscan.io/token/0x4685615246A0Caf18ca0CcED1533CF0659DB4FdE" + additional + accountAddress);
                IWebElement search = driver.FindElement(By.CssSelector("#ContentPlaceHolder1_divFilteredHolderBalance"));
                walletAddress = search.Text;
                driver.Close();
            }
            catch
            {
                return BadRequest();
            }
            finally
            {


            }
            return Ok(JsonConvert.SerializeObject(walletAddress));

        }
    }
}
