using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class Polynomial
    {
        #region Private members
         private static double epsilon;

        private readonly double[] coefficients;

        private double this[int index]
        {
            get
            {
                if (index < 0 || index > Degree)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return coefficients[index];
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// The maximum degree of a variable polynomial
        /// </summary>
        public int Degree { get; }

        #endregion

        #region Construcrors
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
                this.coefficients = new[] { .0 };
                this.Degree = 0;
                return;
            }

            this.Degree = coefficients.Length - 1;
            

            while ((coefficients[this.Degree] == 0 || Math.Abs(coefficients[this.Degree]) < epsilon) && this.Degree > 0)
            {
                this.Degree--;
            }

            this.coefficients = new double[this.Degree + 1];
            Array.Copy(coefficients, this.coefficients, this.Degree + 1);
        }

        static Polynomial()
        {
            epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Creates new Polynomial object based on another polynomial
        /// </summary>
        /// <param name="polynomial">Base Polynomial object</param>
        public Polynomial(Polynomial obj) : this(obj.coefficients) { }
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
                return coefficients[0].ToString();

            StringBuilder temp = new StringBuilder();
            temp.Append($"{coefficients[Degree]}x^{Degree}");

            for (int i = Degree - 1; i > 0; i--)
            {
                if (coefficients[i] > 0)
                    temp.Append($" + {coefficients[i]}x^{i}");
                else if (coefficients[i] == 0)
                    continue;
                else
                    temp.Append($"{coefficients[i]}x^{i}");
            }

            if (coefficients[0] > 0)
                temp.Append($" + {coefficients[0]}");
            else if (coefficients[0] == 0)
                return temp.ToString();
            else temp.Append(coefficients[0]);

            return temp.ToString();
        }

        /// <summary>
        /// Calculates hash code for current polynomial
        /// </summary>
        /// <returns>Hash code of the Polynomial object</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                unchecked
                {
                    hash += (coefficients[i] + i).GetHashCode();
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
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType())
                return false;

            Polynomial temp = obj as Polynomial;

            if (this.GetHashCode() != temp.GetHashCode())
                return false;
            if (this.coefficients.Length != temp.coefficients.Length || this.Degree != temp.Degree)
                return false;

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i] != temp.coefficients[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current Polynomial object
        /// </summary>
        /// <param name="obj">The object to compare with the current Polynomial object</param>
        /// <returns>True if the specified object is equal to the current Polynomial object; otherwise, false</returns>
        public bool Equals(Polynomial obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (this.GetHashCode() != obj.GetHashCode())
                return false;
            if (this.coefficients.Length != obj.coefficients.Length || this.Degree != obj.Degree)
                return false;

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i] != obj.coefficients[i]) return false;
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
                result += Math.Pow(value, i) * this.coefficients[i];

            return result;
        }

        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial Add(Polynomial value1, Polynomial value2)
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
                    tempArray[i] += value1.coefficients[i];
                if (i <= value2.Degree)
                    tempArray[i] += value2.coefficients[i];
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
        public static Polynomial Subtraction(Polynomial value1, Polynomial value2) => value1 + (-value2);


        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="value1">First polynomial</param>
        /// <param name="value2">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null</exception>
        public static Polynomial Multiply(Polynomial value1, Polynomial value2)
        {
            if (value1 == null)
                throw new ArgumentNullException(nameof(value1));
            if (value2 == null)
                throw new ArgumentNullException(nameof(value2));

            int tempDegree = value1.Degree + value2.Degree;
            double[] newCoefficients = new double[tempDegree + 1];

            for (int i = value1.Degree; i >= 0; i--)
                for (int j = value2.Degree; j >= 0; j--)
                    newCoefficients[i + j] += value1.coefficients[i] * value2.coefficients[j];

            return new Polynomial(newCoefficients);
        }
        #endregion

        #region Operators
        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Sum of polynomials</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs) => Add(lhs, rhs);

        public static Polynomial operator -(Polynomial polinom)
        {
            if (polinom == null)
                throw new ArgumentNullException(nameof(polinom));

            double[] tempArray = new double[polinom.Degree + 1];
            for (int i = 0; i <= polinom.Degree; i++)
                tempArray[i] = polinom[i] * (-1);

            return new Polynomial(tempArray);
        }

        /// <summary>
        /// Calculates the substraction of two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Substraction of polynomials</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs) => Subtraction(lhs, rhs);

        /// <summary>
        /// Mutliplies two polynomials
        /// </summary>
        /// <param name="lhs">First polynomial</param>
        /// <param name="rhs">Second polynomial</param>
        /// <returns>Multiplication of polynomials</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs) => Multiply(lhs, rhs);

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="lhs">First Polynomial variable</param>
        /// <param name="rhs">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are equal, false if they are not</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if ((object)lhs == null || (object)rhs == null)
                return false;
            if (lhs.GetHashCode() != rhs.GetHashCode())
                return false;
            if (lhs.coefficients.Length != rhs.coefficients.Length || lhs.Degree != rhs.Degree)
                return false;

            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                if (lhs.coefficients[i] != rhs.coefficients[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Compares two Polynomial variables
        /// </summary>
        /// <param name="lhs">First Polynomial variable</param>
        /// <param name="rhs">Second Polynomial variable</param>
        /// <returns>Result of comparison: true if variables are not equal, false if the are</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs) => !(lhs == rhs);
        #endregion
    }
}
