using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        #region Properties
        /// <summary>
        /// The maximum degree of a variable polynomial
        /// </summary>
        public int Degree { get; }

        /// <summary>
        /// Array with polynomial's coefficients
        /// </summary>
        private double[] Coefficients { get; }
        #endregion

        #region Construcrors
        /// <summary>
        /// Creates new Polynomial object with given coefficient
        /// </summary>
        /// <param name="first">First polynomial's coefficient</param>
        public Polynomial(double first)
        {
            this.Degree = 0;
            Coefficients = new double[] { first };
        }

        /// <summary>
        /// Creates new Polynomial object with given coefficients
        /// </summary>
        /// <param name="first">Polynomial's first coefficient</param>
        /// <param name="second">Polynomial's second coefficient</param>
        public Polynomial(double first, double second)
        {
            if (second == 0)
            {
                this.Degree = 0;
                Coefficients = new double[] { first };
            }
            else
            {
                this.Degree = 1;
                this.Coefficients = new double[] { first, second };
            }
        }

        /// <summary>
        /// Creates new Polynomial object with given coefficients
        /// </summary>
        /// <param name="coefficients">Polynomial's coefficients</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException(nameof(coefficients));
            if (coefficients.Length == 0)
            {
                this.Coefficients = new[] { .0 };
                this.Degree = 0;
                return;
            }

            this.Degree = coefficients.Length - 1;

            while (coefficients[this.Degree] == 0 && this.Degree > 0)
            {
                this.Degree--;
            }

            this.Coefficients = new double[this.Degree + 1];
            Array.Copy(coefficients, this.Coefficients, this.Degree + 1);
        }

        /// <summary>
        /// Creates new Polynomial object based on another polynomial
        /// </summary>
        /// <param name="polynomial">Base Polynomial object</param>
        public Polynomial(Polynomial obj) : this(obj.Coefficients) { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Represents the current polynomial
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        public override string ToString()
        {
            if (this == null)
                return base.ToString();
            if (Degree == 0)
                return Coefficients[0].ToString();

            StringBuilder temp = new StringBuilder();
            temp.Append($"{Coefficients[Degree]}x^{Degree}");

            for (int i = Degree - 1; i > 0; i--)
            {
                if (Coefficients[i] > 0)
                    temp.Append($" + {Coefficients[i]}x^{i}");
                else if (Coefficients[i] == 0)
                    continue;
                else
                    temp.Append($"{Coefficients[i]}x^{i}");
            }

            if (Coefficients[0] > 0)
                temp.Append($" + {Coefficients[0]}");
            else if (Coefficients[0] == 0)
                return temp.ToString();
            else temp.Append(Coefficients[0]);

            return temp.ToString();
        }

        /// <summary>
        /// Calculates hash code for current polynomial
        /// </summary>
        /// <returns>Hash code of the Polynomial object</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.Coefficients.Length; i++)
            {
                unchecked
                {
                    hash += (Coefficients[i] + i).GetHashCode();
                }
            }
            return hash;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current Polynomial object
        /// </summary>
        /// <param name="obj">The object to compare with the current Polynomial object</param>
        /// <returns>True if the specified object is equal to the current Polynomial object; otherwise, false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Polynomial temp = obj as Polynomial;

            if (this.GetHashCode() != temp.GetHashCode())
                return false;
            if (this.Coefficients.Length != temp.Coefficients.Length || this.Degree != temp.Degree)
                return false;

            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (this.Coefficients[i] != temp.Coefficients[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Calculate the value of lhs polynomial, if the variable is value
        /// </summary>
        /// <param name="value">Polynomial's variable</param>
        /// <returns>Value of polynomial</returns>
        public double Calculate(double value)
        {
            double result = 0;
            for (int i = 0; i <= Degree; i++)
                result += Math.Pow(value, i) * this.Coefficients[i];

            return result;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        private static Polynomial Add(Polynomial value1, Polynomial value2)
        {
            if (value1 == null)
                throw new ArgumentNullException(nameof(value1));
            if (value2 == null)
                throw new ArgumentNullException(nameof(value2));

            int newDegree = Math.Max(value1.Degree, value2.Degree);
            double[] tempArray = new double[newDegree + 1];

            for (int i = 0; i <= newDegree; i++)
            {
                if (i <= value1.Degree)
                    tempArray[i] += value1.Coefficients[i];
                if (i <= value2.Degree)
                    tempArray[i] += value2.Coefficients[i];
            }
            return new Polynomial(tempArray);
        }

        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        private static Polynomial Subtraction(Polynomial value1, Polynomial value2)
        {
            if (value1 == null)
                throw new ArgumentNullException(nameof(value1));
            if (value2 == null)
                throw new ArgumentNullException(nameof(value2));

            int newDegree = Math.Max(value1.Degree, value2.Degree);
            double[] tempArray = new double[newDegree + 1];

            for (int i = 0; i <= newDegree; i++)
            {
                if (i <= value1.Degree)
                    tempArray[i] += value1.Coefficients[i];
                if (i <= value2.Degree)
                    tempArray[i] -= value2.Coefficients[i];
            }
            return new Polynomial(tempArray);
        }

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        private static Polynomial Multiply(Polynomial value1, Polynomial value2)
        {
            if (value1 == null)
                throw new ArgumentNullException(nameof(value1));
            if (value2 == null)
                throw new ArgumentNullException(nameof(value2));
            
            int tempDegree = value1.Degree + value2.Degree;
            double[] newCoefficients = new double[tempDegree + 1];

            for (int i = value1.Degree; i >= 0; i--)
                for (int j = value2.Degree; j >= 0; j--)
                    newCoefficients[i + j] += value1.Coefficients[i] * value2.Coefficients[j];

            return new Polynomial(newCoefficients);
        }
        #endregion

        #region Operators
        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Polynomial operator +(Polynomial value1, Polynomial value2) => Add(value1, value2);

        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Polynomial operator -(Polynomial value1, Polynomial value2) => Subtraction(value1, value2);

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Polynomial operator *(Polynomial value1, Polynomial value2) => Multiply(value1, value2);

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="value1">First Polynomial variable</param>
        /// <param name="value2">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are equal, false if they are not</returns>
        public static bool operator ==(Polynomial value1, Polynomial value2) => ReferenceEquals(value1, value2);

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="value1">First Polynomial variable</param>
        /// <param name="value2">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are not equal, false if the are</returns>
        public static bool operator !=(Polynomial value1, Polynomial value2) => !(value1 == value2);
        #endregion
    }
}
