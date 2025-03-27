﻿using ASC.Tests.TestUtilities;
using ASC.Web.Configuration;
using ASC.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASC.Utilities;
namespace ASC.Tests
{
    public class HomeControllerTests
    { 
        private readonly Mock<IOptions<ApplicationSettings>> optionsMock;
        private readonly Mock<HttpContext> mockHttpContext;

        public HomeControllerTests()
        {
           
            optionsMock = new Mock<IOptions<ApplicationSettings>>();
            mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(p => p.Session).Returns(new FakeSesstion());


            optionsMock.Setup(ap => ap.Value).Returns(new ApplicationSettings
            {
                //ApplicationTitle = "ABC"
                AdminName = "admin",
                AdminEmail = "admin@gmail.com",
                ApplicationTitle ="TEST"
            });
        }
    [Fact]
    public void HomeController_Index_View_Test()
    {
            // Home controller instantianted with Mock IOptions<> object

          var controller = new HomeController(optionsMock.Object);
          controller.ControllerContext.HttpContext = mockHttpContext.Object;
            //Assert.NotNull(controller);
          Assert.IsType(typeof(ViewResult), controller.Index());
    }
    [Fact]
    public void HomeController_Index_NoModel_Test()
    {
         var controller = new HomeController(optionsMock.Object);
         controller.ControllerContext.HttpContext = mockHttpContext.Object;

            // Assert Model for Null  
            Assert.Null((controller.Index() as ViewResult).ViewData.Model);
    }

    [Fact]
     public void HomeController_Index_Validation_Test()
    {
        var controller = new HomeController(optionsMock.Object);
        controller.ControllerContext.HttpContext = mockHttpContext.Object;

            // Assert ModelState Error Count to 0  
            Assert.Equal(0, (controller.Index() as ViewResult).ViewData.ModelState.ErrorCount);
     }
   
    [Fact]
    public void HomeController_Index_Session_Test()
    {
          var controller = new HomeController(optionsMock.Object);
          controller.ControllerContext.HttpContext = mockHttpContext.Object;
          controller.Index();

          // Session value with key "Test" should not be null.  
          Assert.NotNull(controller.HttpContext.Session.GetSession<ApplicationSettings>("Test"));
    }
    }
}
