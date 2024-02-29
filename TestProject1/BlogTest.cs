using BlogLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestFixture]
    public class BlogTest
    {
        [Test]
        public void BlogInfo_ValidProperties_PassesValidation()
        {
            
            // Arrange
            var blogInfo = new BlogInfo
            {
                BlogId = 10,
                Title = "Azure",
                Subject = "Azure Connect to MVC",
                BlogUrl = "https://github.com/deepakk2000/Deploy-an-ASP.NET-WebForms-Application-on-Azure.git",
                EmpEmailId = "sumu@gmail.com",

            };

            // Act
            var validationResults = ValidateModel(blogInfo);

            // Assert
            Assert.IsEmpty(validationResults); // If validationResults is empty, validation passed
        }

       
        public void BlogInfo_MissingRequiredProperties_FailsValidation()
        {
            // Arrange
            var blogInfo = new BlogInfo();

            // Act
            var validationResults = ValidateModel(blogInfo);

            // Assert
            Assert.IsNotEmpty(validationResults); // If validationResults is not empty, validation failed
            Assert.AreEqual(5, validationResults.Count); // Adjust the count based on the number of required properties
        }

        private List<ValidationResult> ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);

            return validationResults;
        }
    }
}
