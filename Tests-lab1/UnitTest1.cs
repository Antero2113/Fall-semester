using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1;
using System.Collections.Generic;


namespace UnitTestProject
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestFirstPart()
		{
			// Arrange
			int size = 5;
			var firstPart = new FirstPart(size);
			// Act
			int min = firstPart.GetMin();
			int sumBetweenPositive = firstPart.GetSumBetweenPositive();
			firstPart.SortByZero();
			List<int> sortedVector = firstPart.Vector;

			// Assert
			Assert.IsNotNull(min);
			Assert.IsNotNull(sumBetweenPositive);
			Assert.IsNotNull(sortedVector);
			Assert.AreEqual(size, sortedVector.Count);
		}

		[TestMethod]
		public void TestSecondPart()
		{
			// Arrange
			int rows = 3;
			int columns = 4;
			var secondPart = new SecondPart(rows, columns);

			// Act
			int element = secondPart.GetElement(1, 2);
			int sumOfRowsWithBelowZero = secondPart.GetSumOfRowsWithBelowZero();

			// Assert
			Assert.IsNotNull(element);
			Assert.IsNotNull(sumOfRowsWithBelowZero);
			Assert.AreEqual(rows, secondPart.Matrix.Count);
			Assert.AreEqual(columns, secondPart.Matrix[0].Count);
		}
	}
}