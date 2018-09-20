using System;

/// <summary>
/// Matrix Multiple program
/// </summary>
namespace MatrixMultiple
{
    /// <summary>
    /// Main class for Matrix Multiple program
    /// </summary>
    class Program
    {
        /// <summary>
        /// This program allows a user to enter values to create 2 matricies, and performs Matrix Multiplication
        /// </summary>
        static void Main()
        {
            // Get input for the matrix rows
            DoTheWork();
        }

        /// <summary>
        /// This is the method that manages all the work
        /// </summary>
        internal static void DoTheWork()
        {
            // clear the console
            Console.Clear();
            // Get input for the matrix rows
            Console.WriteLine("First Matrix - enter rows");
            string input = Console.ReadLine();
            int rows1 = ConvertString(input);
            // Get input for the first matrix columns
            Console.WriteLine("First Matrix - enter columns");
            input = Console.ReadLine();
            int cols1 = ConvertString(input);
            // Get input for an array of all the user inputs for the first matrix
            int[] mat1vals = new int[rows1 * cols1];
            Console.WriteLine($"First Matrix - enter {rows1 * cols1} numbers with return after each");
            // convert input to array
            int i = 0;
            while (i < rows1 * cols1)
            {
                input = Console.ReadLine();
                mat1vals[i] = ConvertString(input);
                i++;
            }
            // Get input for the second matrix columns
            Console.WriteLine("Second Matrix - enter columns");
            input = Console.ReadLine();
            int cols2 = ConvertString(input);
            // Get input for an array of all the user inputs for the second matrix
            int[] mat2vals = new int[cols1 * cols2];
            Console.WriteLine($"Second Matrix - enter {cols1 * cols2} numbers with return after each");
            // convert input to array
            i = 0;
            while (i < cols1 * cols2)
            {
                input = Console.ReadLine();
                mat2vals[i] = ConvertString(input);
                i++;
            }
            // call the CreateMatrix functin for first, second, and final arrays
            int[,] matx1 = CreateMatrix(rows1, cols1, mat1vals);
            int[,] matx2 = CreateMatrix(cols1, cols2, mat2vals);
            int[,] finalmatx = MatrixMultiply(matx1, matx2);
            // call the output function to display information in the console
            OutputMatrix("Matrix 1", matx1);
            OutputMatrix("Matrix 2", matx2);
            OutputMatrix("Multiplied Matrix", finalmatx);
            // prompt the user to try again
            Console.WriteLine("Try again? (y/n)");
            string tryAgain = Console.ReadLine();
            if (tryAgain.ToLower() == "y")
                DoTheWork();
        }
        /// <summary>
        /// The actual Matrix Multiplication
        /// </summary>
        /// <param name="matrix1">First Matrix</param>
        /// <param name="matrix2">Second Matrix</param>
        /// <returns>Multidimensional array of integers</returns>
        internal static int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2)
        {
            // get the rows and columns from the two matricies
            int r1 = matrix1.GetLength(0);
            int c1 = matrix1.GetLength(1);
            int c2 = matrix2.GetLength(1);
            // Create the multi-dimentional array to return
            int[,] sums = new int[r1, c2];
            // loop for first matrix row count
            int i = 0;
            while (i < r1)
            {
                int j = 0;
                // loop for second matrix column count
                while (j < c2)
                {
                    int k = 0;
                    // loop for first matrix column with both outer loops
                    while (k < c1)
                    {
                        // sum the products of the row multiplied by the column
                        sums[i, j] += (matrix1[i, k] * matrix2[k, j]);

                        k++;
                    }
                    j++;
                }
                i++;
            }
            // return array of values
            return sums;
        }
        /// <summary>
        /// Intakes rows, columns, and an array to build a Matrix
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="cols">Number of columns</param>
        /// <param name="values">Array of values</param>
        /// <returns>Multidimensional array of integers</returns>
        internal static int[,] CreateMatrix(int rows, int cols, int[] values)
        {
            // create array
            int[,] data = new int[rows, cols];
            // add an iterator
            int iterator = 0;
            // loop through columns
            int i = 0;
            while (i < cols)
            {
                int j = 0;
                // loop through rows
                while (j < rows)
                {
                    // add value, and update iterator
                    data[j, i] = values[iterator];
                    iterator++;
                    j++;
                }
                i++;
            }
            // return array
            return data;
        }
        /// <summary>
        /// Writing to console
        /// </summary>
        /// <param name="title">Title of section</param>
        /// <param name="matrix">Matrix to console out</param>
        internal static void OutputMatrix(string title, int[,] matrix)
        {
            // get the rows and columns from the two matricies
            int oLoop = matrix.GetLength(0);
            int iLoop = matrix.GetLength(1);
            // output title
            Console.WriteLine(title);
            // loop through outer loop
            int i = 0;
            while (i < oLoop)
            {
                // loop through inner loop
                int j = 0;
                while (j < iLoop)
                {
                    // output tabbed value
                    Console.Write($"{matrix[i, j]} \t");
                    j++;
                }
                // add line break
                Console.WriteLine();
                i++;
            }
            // add blank line
            Console.WriteLine();
        }
        /// <summary>
        /// Convert an string to an int, or try again
        /// </summary>
        /// <param name="input">String to be converted</param>
        /// <returns>Converted int</returns>
        internal static int ConvertString(string input)
        {
            // instantiate integer
            int output;
            // check for successful parse from string to int
            if (!Int32.TryParse(input, out output))
            {
                // if not successful, try again
                Console.WriteLine("You did not enter a valid integer. Please try again");
                input = Console.ReadLine();
                return ConvertString(input);
            } else
            {
                // if successful output integer
                return output;
            }
        }
    }
}
