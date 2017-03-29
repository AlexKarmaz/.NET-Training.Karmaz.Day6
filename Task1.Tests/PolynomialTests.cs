using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;

namespace Task1.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(2, 2, ExpectedResult = 2)]
        [TestCase(0, 2, ExpectedResult = 0)]
        public double Calculate_OneCoefficient_PositiveTest(double coefficients, double variable)
        {
            return (new Polynomial(coefficients)).Calculate(variable);
        }

        [TestCase(2, 2, 2, ExpectedResult = 6)]
        [TestCase(0, 2, 2, ExpectedResult = 4)]
        [TestCase(2, 0, 2, ExpectedResult = 2)]
        [TestCase(0, 0, 2, ExpectedResult = 0)]
        [TestCase(2, 4, 2, ExpectedResult = 10)]
        [TestCase(2, -4, 2, ExpectedResult = -6)]
        [TestCase(2, 0, -2, ExpectedResult = 2)]
        public double Calculate_TwoCoefficients_PositiveTest(double coefficient1, double coefficient2, double variable)
        {
            return (new Polynomial(coefficient1, coefficient2)).Calculate(variable);
        }

        [TestCase(1, -2, 3, 5, 2, ExpectedResult = 81)]
        [TestCase(2, 5, 1, -2, 3, 3, ExpectedResult = 144)]
        [TestCase(0, 0, 0, 0, 0, 5, ExpectedResult = 160)]
        [TestCase(3, 4, 0, 2, ExpectedResult = 27)]
        [TestCase(7, 8, 9, 3, 0, ExpectedResult = 83)]
        [TestCase(0, 0, 0, 0, 0, 0, ExpectedResult = 0)]
        public double Calculate_ParamsCoefficients_PositiveTest(params double[] coefficients)
        {
            double variable = 2;
            return (new Polynomial(coefficients)).Calculate(variable);
        }

        public void Constructor_ParamsCoefficients_ThrowsArgumentNullException()
        {
            double[] arr = null;
            Assert.Throws<ArgumentNullException>(() => new Polynomial(arr));
        }

        [TestCase(new double[] { 1 }, ExpectedResult = "1")]
        [TestCase(new double[] { 1, 2, 3, 4 }, ExpectedResult = "4x^3 + 3x^2 + 2x^1 + 1")]
        public string ToString_PositiveTest(double[] coeffArray) => new Polynomial(coeffArray).ToString();

        [TestCase(new double[] { 1, -2, 3 }, null, ExpectedResult = false)]
        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, -2, 3 }, new double[] { 1, -2, 3 }, ExpectedResult = true)]
        public bool Equals_PositiveTest(double[] coefficients1, double[] coefficients2)
        {
            Polynomial polynomial1 = null;
            Polynomial polynomial2 = null;
            if (coefficients1 != null)
                polynomial1 = new Polynomial(coefficients1);
            if (coefficients2 != null)
                polynomial2 = new Polynomial(coefficients2);

            return polynomial1.Equals(polynomial2);
        }

        [TestCase(new double[] { 1, -2, 3, 4 }, new double[] { 0, 0, 0 }, 4, ExpectedResult = 297)]
        [TestCase(new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 3, ExpectedResult = 215)]
        [TestCase(new double[] { 1, 2, 3, 5 }, new double[] { -1, -2, -3, -5 }, 6, ExpectedResult = 0)]
        [TestCase(new double[] { 5, 2, 3, 5 }, new double[] { -4, -2, -3, -5 }, 7, ExpectedResult = 1)]
        [TestCase(new double[] { 6 }, new double[] { 1, -2, 3 }, 2, ExpectedResult = 15)]
        public double Add_PositiveTest(double[] coefficients1, double[] coefficients2, double variable)
        {
            return (new Polynomial(coefficients1) + new Polynomial(coefficients2)).Calculate(variable);
        }

        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 }, 2, ExpectedResult = 9)]
        [TestCase(new double[] { 1, -2, -3 }, new double[] { 0, 0, 0 }, 3, ExpectedResult = -32)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 4, ExpectedResult = -678)]
        [TestCase(new double[] { 9, 15 }, new double[] { 1, -2, 3 }, 4, ExpectedResult = 28)]
        [TestCase(new double[] { 1, 2, 3, 5 }, new double[] { 1, 2, 3, 5 }, 5, ExpectedResult = 0)]
        [TestCase(new double[] { 1, 2, 3, 5 }, new double[] { 2, 2, 3, 5 }, 6, ExpectedResult = -1)]
        public double Substract_PositiveTest(double[] coefficients1, double[] coefficients2, double variable)
        {
            return (new Polynomial(coefficients1) - new Polynomial(coefficients2)).Calculate(variable);
        }

        [TestCase(new double[] { 1, -2, 3, 4 }, new double[] { 0, 0, 0 }, 2, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, 3, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 1, 0 }, new double[] { 2, 5, 1, -2, 3 }, 4, ExpectedResult = 2712)]
        [TestCase(new double[] { 6, 21 }, new double[] { 1, -2, 3 }, 5, ExpectedResult = 7326)]
        public double MultiplyAndValueAt_TwoPolynomials_ResultOfPolynomialExpression(double[] coefficients1, double[] coefficients2, double variable)
        {
            return (new Polynomial(coefficients1) * new Polynomial(coefficients2)).Calculate(variable);
        }

        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, ExpectedResult = true)]
        public bool OperatorEqual_PositiveTest(double[] coefficients1, double[] coefficients2)
        {
            return new Polynomial(coefficients1) == new Polynomial(coefficients2);
        }

        [TestCase(new double[] { 1, -2, 3 }, new double[] { 0, 0, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0 }, new double[] { 2, 5, 1, -2, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, -2, 3 }, new double[] { 1, -2, 3 }, ExpectedResult = false)]
        public bool OperatorNotEqual_PositiveTest(double[] coefficients1, double[] coefficients2)
        {
            return new Polynomial(coefficients1) != new Polynomial(coefficients2);
        }
    }
}
