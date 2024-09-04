using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Refactoring_Assignment_Two;
using Interfaces;

namespace UnitTesting
{
    [TestClass]
    public class LevelTest
    {
        [TestMethod]
        public void AddBishop_ExpectedBishop()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddBishop(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Bishop;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddBishop_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddBishop(11, 11);
        }

        [TestMethod]
        public void AddEmpty_ExpectedEmpty()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKnight(1, 1);
            levelDesigner.AddEmpty(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Empty;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddEmpty_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddEmpty(11, 11);
        }

        [TestMethod]
        public void AddKing_ExpectedKing()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKing(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.King;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddKing_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKing(11, 11);
        }

        [TestMethod]
        public void AddPlayerOnBishop_ExpectedPlayerOnBishop()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnBishop(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnBishop;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnBishop_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnBishop(11, 11);
        }

        [TestMethod]
        public void AddPlayerOnEmpty_ExpectedPlayerOnEmpty()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(1, 1);
            levelDesigner.AddPlayerOnEmpty(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnEmpty;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnEmpty_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnEmpty(11, 11);
        }

        [TestMethod]
        public void AddPlayerOnKing_ExpectedPlayerOnKing()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKing(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnKing;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnKing_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnBishop(11, 11);
        }


        [TestMethod]
        public void AddPlayerOnKnight_ExpectedPlayerOnKnight()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnKnight;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnKnight_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(11, 11);
        }

        [TestMethod]
        public void AddPlayerOnRook_ExpectedPlayerOnRook()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnRook(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.PlayerOnRook;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPlayerOnRook_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnRook(11, 11);
        }

        [TestMethod]
        public void AddRook_ExpectedRook()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddRook(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Rook;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddRook_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddRook(11, 11);
        }

        [TestMethod]
        public void AddKnight_ExpectedKnight()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKnight(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Knight;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddKnight_ExpectedThrowError()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKnight(11, 11);
        }

        [TestMethod]
        public void GetLevelWidth_Expected4()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(3, 4);
            int expectedWidth = 3;
            int actualWidth = levelDesigner.GetLevelWidth();
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void GetLevelWidth_Expected100()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(100, 4);
            int expectedWidth = 100;
            int actualWidth = levelDesigner.GetLevelWidth();
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void GetLevelHeight_Expected3()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(3, 4);
            int expectedHeight = 4;
            int actualHeight = levelDesigner.GetLevelHeight();
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        public void GetLevelHeight_Expected100()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(3, 100);
            int expectedHeight = 100;
            int actualHeight = levelDesigner.GetLevelHeight();
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        public void GetPlayerY_Expected1()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(0, 1);
            int actualY = levelDesigner.GetPlayerY();
            int expectedY = 1;
            Assert.AreEqual(expectedY, actualY);
        }

        [TestMethod]
        public void GetPlayerY_Expected9()                                  //F14 test 2
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(0, 9);
            int expectedY = 9;
            int actualY = levelDesigner.GetPlayerY();
            Assert.AreEqual(expectedY, actualY);
        }

        [TestMethod]
        public void CheckValid_ExpectedTrue()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKing(0, 0);
            Boolean actualResult = levelDesigner.CheckValid();
            Boolean expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CheckValid_ExpectedFalse()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            Boolean actualResult = levelDesigner.CheckValid();
            Boolean expectedResult = false;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetPartAtIndex_ExpectedEmpty()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Empty;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void GetPartAtIndex_ExpectedKnight()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKnight(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Knight;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void GetPartAtIndex_ExpectedBishop()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddBishop(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.Bishop;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void GetPartAtIndex_ExpectedKing()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddKing(1, 1);
            Part actualPart = levelDesigner.GetPartAtIndex(1, 1);
            Part expectedPart = Part.King;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void GetPlayerX_Expected0()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(0, 1);
            int actualX = levelDesigner.GetPlayerX();
            int expectedX = 0;
            Assert.AreEqual(expectedX, actualX);
        }

        [TestMethod]
        public void GetPlayerX_Expected9()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(10, 10);
            levelDesigner.AddPlayerOnKnight(9, 1);
            int expectedX = 9;
            int actualX = levelDesigner.GetPlayerX();
            Assert.AreEqual(expectedX, actualX);
        }

        [TestMethod]
        public void SaveMe_1x1()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(1, 1);
            levelDesigner.SaveMe();
        }

        [TestMethod]
        public void SaveMe_2x2()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(2, 2);
            levelDesigner.SaveMe();
        }

        [TestMethod]
        public void LoadMe_2x2()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(2, 2);
            levelDesigner.SaveMe();
            levelDesigner.LoadMe();
        }

        [TestMethod]
        public void LoadMe_CheckPart_expectedPlayerOnBishop()
        {
            Level levelDesigner = new Level();
            levelDesigner.CreateLevel(3, 3);
            levelDesigner.AddPlayerOnBishop(1, 2);
            levelDesigner.SaveMe();
            levelDesigner.LoadMe();
            Part expectedPart = Part.PlayerOnBishop;
            Part actualPart = levelDesigner.GetPartAtIndex(1, 2);
            Assert.AreEqual(expectedPart, actualPart);
        }
    }
}
