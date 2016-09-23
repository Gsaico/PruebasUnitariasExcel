using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersistenciaDatos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PruebaUnitariaExcelOK
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
       // [DeploymentItem("d:\\scratch\\Data.xls")]
        [DataSource("System.Data.OleDb",
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\scratch\\Data.xls;Persist Security Info=False;Extended Properties='Excel 8.0'",
            "Hoja2$", DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            Usuario add = new Usuario
            {
                dni = TestContext.DataRow["DNI"].ToString(),
                password = TestContext.DataRow["PASSWORD"].ToString()
            };
            var lstErrors = ValidateModel(add);
            Assert.IsTrue(lstErrors.Count == 0);
        }
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    
    }
}
