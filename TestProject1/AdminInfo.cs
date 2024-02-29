using BlogLib;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestProject1
{
    [TestFixture]
    public class AdminInfoTesting
    {
        [Test]
        public void ValidAdminInfo()
        {
            var adminInfo = new AdminInfo
            {
                EmailId = "sumu@gmail.com",
                Password = "sumu998"
            };
            var validationContext = new ValidationContext(adminInfo, null, null);
            var validationResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResult, true);
            Assert.IsTrue(isValid);
        }
        
        public void InvalidAdminInfo_MissingEmail_ShouldFailValidation()
        {
            var adminInfo = new AdminInfo
            {
                Password = "SecurePassword123"
            };

            // Act
            var validationContext = new ValidationContext(adminInfo, null,null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResults, false);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Email field is required.", validationResults[0].ErrorMessage);
        }


        
        public void InvalidAdminInfo_InvalidEmailFormat_ShouldFailValidation()
        {
            // Arrange
            var adminInfo = new AdminInfo
            {
                EmailId = "de@gml.com",
                Password = "SecurePassword123"
            };

            // Act
            var validationContext = new ValidationContext(adminInfo, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual("The Email field is not a valid e-mail address.", validationResults[0].ErrorMessage);
        }
    }
}