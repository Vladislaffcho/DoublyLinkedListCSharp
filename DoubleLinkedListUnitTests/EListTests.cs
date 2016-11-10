using System;
using System.Linq;
using DoubleLinkedList;
using NUnit.Framework;

namespace DoubleLinkedListUnitTests
{
    [TestFixture]
    public class EListTests
    {
        /// <summary>
        /// Init method
        /// </summary>
        // init with one element array
        [Test]
        public void Init_OneElementArray_Initialized()
        {
            var initArray = new[] { 1 };
            var arrayToCompare = new[] { 1 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        // init with two elements array
        [Test]
        public void Init_TwoElementArray_Initialized()
        {
            var initArray = new[] { 1, 3 };
            var arrayToCompare = new[] { 1, 3 };

            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        // init with many elements array
        [Test]
        public void Init_ManyElementArray_Initialized()
        {
            var initArray = new[] { 1, 3, 777, -33, -777, 35 };
            var arrayToCompare = new[] { 1, 3, 777, -33, -777, 35 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        // check that wrong initialization throws expected exception
        [Test]
        public void InvalidListInit_OnNullArray_ExceptionThrown()
        {
            var doublyLinkedList = new EList();
            Assert.Throws<NullReferenceException>(() => doublyLinkedList.Init(null));
        }

        // check that wrong initialization throws expected exception
        [Test]
        public void InvalidListInit_OnEmptyArray_EmptyListCreated()
        {
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(new int[] {});

            Assert.AreEqual(0, doublyLinkedList.Size());
        }

        /// <summary>
        /// ToArray method
        /// </summary>
        [Test]
        public void ToArray_CheckArrayMatches_ArraysAreEqual()
        {
            var initArray = new[] { 3, -33, -777, 35 };
            var arrayToCompare = new[] { 3, -33, -777, 35 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        //
        [Test]
        public void ToArray_EmptyList_IsEmptyArray()
        {
            int[] arr = new int[]{};
            var doublyLinkedList = new EList();
            
            Assert.AreEqual(arr, doublyLinkedList.ToArray());
        }

        /// <summary>
        /// Clear method
        /// </summary>
        // check clear list functionality
        [Test]
        public void ClearList_Cleared()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.Clear();
            
            Assert.AreEqual(0, doublyLinkedList.Size());
        }

        // check clear list functionality
        [Test]
        public void ClearEmptyList_Cleared()
        {
            var doublyLinkedList = new EList();
            
            doublyLinkedList.Clear();

            Assert.AreEqual(0, doublyLinkedList.Size());
        }

        /// <summary>
        /// Size method
        /// </summary>
        // testing Size method for initialized list
        [Test]
        public void CheckListSize_InitializedList_ReturnsSize()
        {
            var initArray = new[] { 1, 7, 48, 33, 55, 10 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray.Length, doublyLinkedList.Size());
        }

        // testing Size method for empty list
        [Test]
        public void CheckListSize_EmptyList_ReturnsZero()
        {
            var doublyLinkedList = new EList();

            Assert.AreEqual(0, doublyLinkedList.Size());
        }

        // testing Size method for empty list
        [Test]
        public void CheckListSize_OneElementList_ReturnsZero()
        {
            var initArray = new[] { 1 };
            var arrayToCompare = new[] { 1 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(arrayToCompare.Length, doublyLinkedList.Size());
        }

        /// <summary>
        /// MinPos method
        /// </summary>
        // test MinPos method for initialized list
        [Test]
        public void MinPosNode_InitializedList_Value()
        {
            var doublyLinkedList = new EList();
            int[] initArray = new[] { 111, 7, 48, 33, 55 };

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[0], doublyLinkedList.MinPos());
        }

        // test MinPos method for initialized list
        [Test]
        public void MinPosNode_OneNodeList_Value()
        {
            var doublyLinkedList = new EList();
            int[] initArray = new[] { 777 };

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[0], doublyLinkedList.MinPos());
        }

        // test MinPos method for empty list
        [Test]
        public void MinPosNode_EmptyList_Exception()
        {
            var doublyLinkedList = new EList();

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.MinPos());
        }

        /// <summary>
        /// MaxPos method
        /// </summary>
        // test MaxPos method
        [Test]
        public void MaxPosNode_InitializedList_Value()
        {
            var doublyLinkedList = new EList();
            int[] initArray = new[] { 111, 7, 48, 33, 55 };

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[initArray.Length-1], doublyLinkedList.MaxPos());
        }

        // test MaxPos method
        [Test]
        public void MaxPosNode_OneNodeList_Value()
        {
            var doublyLinkedList = new EList();
            int[] initArray = new[] { 33 };

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[initArray.Length - 1], doublyLinkedList.MaxPos());
        }

        // test MaxPos method for empty list
        [Test]
        public void MaxPosNode_EmptyList_Exception()
        {
            var doublyLinkedList = new EList();

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.MaxPos());
        }

        /// <summary>
        /// AddStart method
        /// </summary>
        // test if the node gets added correctly to the beginning of the list
        [Test]
        public void AddStartNode_EmptyList_Added()
        {
            var valueToAdd = 5;
            var doublyLinkedList = new EList();

            doublyLinkedList.AddStart(valueToAdd);

            Assert.AreEqual(valueToAdd, doublyLinkedList.MinPos());
        }

        // test if the node gets added correctly to the beginning of the list
        [Test]
        public void AddStartNode_InitializedList_Added()
        {
            var initArray = new[] { 3, -33, -777, 35 };
            var valueToAdd = 5;
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            doublyLinkedList.AddStart(valueToAdd);

            Assert.AreEqual(valueToAdd, doublyLinkedList.MinPos());
        }

        // test if the node gets added correctly to the beginning of the list
        [Test]
        public void AddStartNode_OneNodeList_Added()
        {
            var initArray = new[] { 10 };
            var valueToAdd = 555;
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            doublyLinkedList.AddStart(valueToAdd);

            Assert.AreEqual(valueToAdd, doublyLinkedList.MinPos());
        }

        /// <summary>
        /// AddEnd method
        /// </summary>
        // test if the node gets added correctly to the end of the list
        [Test]
        public void AddEndNode_EmptyList_Added()
        {
            var valueToAdd = 555;
            var doublyLinkedList = new EList();

            doublyLinkedList.AddEnd(valueToAdd);

            Assert.AreEqual(valueToAdd, doublyLinkedList.MaxPos());
        }

        // test if the node gets added correctly to the end of the list
        [Test]
        public void AddEndNode_InitializedList_Added()
        {
            var initArray = new[] { 3, -33, -777, 35 };
            var valueToAdd = 551;
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            doublyLinkedList.AddEnd(valueToAdd);

            Assert.AreEqual(valueToAdd, doublyLinkedList.MaxPos());
        }

        // test if the node gets added correctly to the end of the list
        [Test]
        public void AddEndNode_OneNodeList_Added()
        {
            var initArray = new[] { 99 };
            var valueToAdd = 111;
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            doublyLinkedList.AddEnd(valueToAdd);

            Assert.AreEqual(valueToAdd, doublyLinkedList.MaxPos());
        }

        /// <summary>
        /// Set method
        /// </summary>
        // test set by index method
        [Test]
        public void SetNode_InitializedList_SetValues()
        {
            var firstValToChange = 10;
            var secondValToChange = 50;
            var thirdValToChange = -77;
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var arrayToCompare = new[] { 10, 7, 50, 33, -77 };
            var doublyLinkedList = new EList();
            
            doublyLinkedList.Init(initArray);

            doublyLinkedList.Set(1, firstValToChange);
            doublyLinkedList.Set(3, secondValToChange);
            doublyLinkedList.Set(5, thirdValToChange);

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }
        
        // test Set method for nodes index range
        [Test]
        public void SetNode_NegativeIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            // check SetNode method range functionality
            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.Set(-1, 10));
        }

        // test Set method for nodes index range
        [Test]
        public void SetNode_ZeroIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.Set(0, 10));
        }

        // test Set method for nodes index range
        [Test]
        public void SetNode_ExceedingIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.Set(10, 10));
        }

        /// <summary>
        /// AddPos method
        /// </summary>
        // test Add by position method
        [Test]
        public void AddPosNode_FirstPosition_UninitializedList_Added()
        {
            var valToAdd = 777;
            var doublyLinkedList = new EList();

            doublyLinkedList.AddPos(1, valToAdd);

            Assert.AreEqual(valToAdd, doublyLinkedList.MinPos());
        }

        // test Add by position method
        [Test]
        public void AddPosNode_MiddlePosition_ItializedList_Added()
        {
            var valToAdd = 777;
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.AddPos(3, valToAdd);

            Assert.AreEqual(valToAdd, doublyLinkedList.Get(3));
        }

        // test Add by position method
        [Test]
        public void AddPosNode_AsSizePlusOnePosition_ItializedList_Added()
        {
            var valToAdd = 777;
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.AddPos(doublyLinkedList.Size() + 1, valToAdd);

            Assert.AreEqual(valToAdd, doublyLinkedList.Get(doublyLinkedList.Size()));
        }

        // test Add by position method
        [Test]
        public void AddPosNode_AsSizePlusOnePosition_EmptyList_Added()
        {
            var valToAdd = 123;
            var doublyLinkedList = new EList();
            
            doublyLinkedList.AddPos(doublyLinkedList.Size() + 1, valToAdd);

            Assert.AreEqual(valToAdd, doublyLinkedList.Get(doublyLinkedList.Size()));
        }

        // test Add by position method
        [Test]
        public void AddPosNode_ChangesListSize()
        {
            var valToAdd = 777;
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.AddPos(doublyLinkedList.Size(), valToAdd);

            Assert.AreEqual(initArray.Length+1, doublyLinkedList.Size());
        }

        // test Add by position method
        [Test]
        public void AddPosNode_NegativeIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            // check SetNode method range functionality
            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.AddPos(-1, -1));
        }

        // test Add by position method
        [Test]
        public void AddPosNode_ZeroIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.AddPos(0, 10));
        }

        // test Add by position method
        [Test]
        public void AddPosNode_ExceedingIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.AddPos(initArray.Length+2, 77));
        }

        /// <summary>
        /// Get method
        /// </summary>
        // test get method
        [Test]
        public void GetNode_FirstNode_ManyNodesInList_ReturnedNodeValue()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[0], doublyLinkedList.Get(1));
        }

        // test get method
        [Test]
        public void GetNode_FirstNode_OneNodeInList_ReturnedNodeValue()
        {
            var initArray = new[] { 1 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[0], doublyLinkedList.Get(1));
        }

        // test get method
        [Test]
        public void GetNode_InsideListNode_ReturnedNodeValue()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[2], doublyLinkedList.Get(3));
        }

        // test get method
        [Test]
        public void GetNode_LastNode_ReturnedNodeValue()
        {
            var initArray = new[] { 1, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[initArray.Length-1], doublyLinkedList.Get(doublyLinkedList.Size()));
        }

        // test Set method for nodes index range
        [Test]
        public void GetNode_NegativeIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            // check SetNode method range functionality
            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.Get(-1));
        }

        // test Set method for nodes index range
        [Test]
        public void GetNode_ZeroIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.Get(0));
        }

        // test Set method for nodes index range
        [Test]
        public void GetNode_ExceedingIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.Get(10));
        }

        /// <summary>
        /// Max method
        /// </summary>
        // test Max method with initialized list
        [Test]
        public void MaxValueNode_InitializedList_Value()
        {
            var initArray = new[] { 3, 7, 111, 33, 222 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray.Max(), doublyLinkedList.Max());
        }

        // test Max method with initialized list
        [Test]
        public void MaxValueNode_OneNodeList_Value()
        {
            var initArray = new[] { 3 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray.Max(), doublyLinkedList.Max());
        }

        // test Max method with initialized list
        [Test]
        public void MaxValueNode_TwoNodesList_Value()
        {
            var initArray = new[] { 99, 3 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray.Max(), doublyLinkedList.Max());
        }

        // test Max method for empty list
        [Test]
        public void MaxValueNode_EmptyList_Exception()
        {
            var doublyLinkedList = new EList();

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.Max());
        }

        /// <summary>
        /// Min method
        /// </summary>
        // test MinPos method
        [Test]
        public void MinValueNode_InitializedList_Value()
        {
            var doublyLinkedList = new EList();
            int[] initArray = new[] { 3, 7, -111, 33, 222 };
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray.Min(), doublyLinkedList.Min());
        }

        // test MinPos method
        [Test]
        public void MinValueNode_OneNodeList_Value()
        {
            var doublyLinkedList = new EList();
            int[] initArray = new[] { 55 };
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray.Min(), doublyLinkedList.Min());
        }

        // test MinPos method
        [Test]
        public void MinValueNode_TwoNodesList_Value()
        {
            var doublyLinkedList = new EList();
            int[] initArray = new[] { 551, -11 };
            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray.Min(), doublyLinkedList.Min());
        }

        // test Min method for empty list
        [Test]
        public void MinValueNode_EmptyList_Exception()
        {
            var doublyLinkedList = new EList();

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.Min());
        }

        /// <summary>
        /// DeleteStart method
        /// </summary>
        // check if first node gets deleted as expected
        [Test]
        public void DeleteStartNode_InitializedList_Deleted()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[0], doublyLinkedList.DelStart());
        }

        // check if first node gets deleted as expected
        [Test]
        public void DeleteStartNode_OneNodeList_Deleted()
        {
            var initArray = new[] { 37 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[0], doublyLinkedList.DelStart());
        }

        // check if first node gets deleted as expected
        [Test]
        public void DeleteStartNode_TwoNodesList_Deleted()
        {
            var initArray = new[] { 35, 99 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[0], doublyLinkedList.DelStart());
        }

        // check if first node gets deleted as expected
        [Test]
        public void DeleteStartNode_CompareSize_SizeChanged()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.DelStart();

            Assert.AreEqual(initArray.Length - 1, doublyLinkedList.Size());
        }

        // check if trying to delete start node for empty list throws exception
        [Test]
        public void DeleteStartNode_EmptyList_ExceptionThrown()
        {
            var doublyLinkedList = new EList();

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.DelStart());
        }

        /// <summary>
        /// DelEnd method
        /// </summary>
        // check if last node gets deleted as expected
        [Test]
        public void DeleteEndNode_InitializedList_Deleted()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[initArray.Length-1], doublyLinkedList.DelEnd());
        }

        // check if last node gets deleted as expected
        [Test]
        public void DeleteEndNode_OneNodeList_Deleted()
        {
            var initArray = new[] { 187 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[initArray.Length - 1], doublyLinkedList.DelEnd());
        }

        // check if last node gets deleted as expected
        [Test]
        public void DeleteEndNode_CompareSize_SizeChanged()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            doublyLinkedList.DelEnd();

            Assert.AreEqual(initArray.Length - 1, doublyLinkedList.Size());
        }

        // check if trying to delete end node for empty list throws exception
        [Test]
        public void DeleteEndNode_EmptyList_ExceptionThrown()
        {
            var doublyLinkedList = new EList();

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.DelEnd());
        }

        /// <summary>
        /// DelPos method
        /// </summary>
        // test that first node can be deleted by index successfully
        [Test]
        public void DeleteNodeByPosition_FirstNode_Deleted()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[0], doublyLinkedList.DelPos(1));
        }

        // test that a node inside the list can be deleted by index successfully
        [Test]
        public void DeleteNodeByPosition_MiddleNode_Deleted()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[2], doublyLinkedList.DelPos(3));
        }

        // test that the last node can be deleted by index successfully
        [Test]
        public void DeleteNodeByPosition_LastNode_Deleted()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(initArray[4], doublyLinkedList.DelPos(5));
        }

        // test that the last node can be deleted by index successfully
        [Test]
        public void DeleteNodeByPosition_ListSize_Deleted()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            doublyLinkedList.DelPos(5);

            Assert.AreEqual(initArray.Length-1, doublyLinkedList.Size());
        }

        // test that the last node can be deleted by index successfully
        [Test]
        public void DeleteNodeByPosition_OneElement_Deleted()
        {
            var initArray = new[] { 1 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            doublyLinkedList.DelPos(1);

            Assert.AreEqual(initArray.Length - 1, doublyLinkedList.Size());
        }

        // test that the last node can be deleted by index successfully
        [Test]
        public void DeleteNodeByPosition_TwoElement_Deleted()
        {
            var initArray = new[] { 77, 91 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            doublyLinkedList.DelPos(1);

            Assert.AreEqual(initArray.Length - 1, doublyLinkedList.Size());
        }

        // test DelPos method for nodes index range
        [Test]
        public void DeleteNodeByPosition_NegativeIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            // check SetNode method range functionality
            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.DelPos(-1));
        }

        // test DelPos method for nodes index range
        [Test]
        public void DeleteNodeByPosition_ZeroIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.DelPos(0));
        }

        // test DelPos method for nodes index range
        [Test]
        public void DeleteNodeByPosition_ExceedingIndex_Exception()
        {
            var initArray = new[] { 1, 7, 48, 33, 55 };
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            Assert.Throws<InvalidOperationException>(() => doublyLinkedList.DelPos(10));
        }

        /// <summary>
        /// Sort method
        /// </summary>
        // Test sorting method
        [Test]
        public void SortInitializedList_OneElement_NoChanges()
        {
            var initArray = new[] { 3 };
            var arrayToCompare = new[] { 3 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            
            doublyLinkedList.Sort();
            
            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        // Test sorting method
        [Test]
        public void SortInitializedList_TwoElements_Sorted()
        {
            var initArray = new[] { 777, -3 };
            var arrayToCompare = new[] { -3, 777 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.Sort();

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        // Test sorting method
        [Test]
        public void SortInitializedList_ZeroElements_NoError()
        {
            var arrayToCompare = new int[] {};
            var doublyLinkedList = new EList();
            
            doublyLinkedList.Sort();

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        // Test sorting method
        [Test]
        public void SortInitializedList_ManyElements_Sorted()
        {
            var initArray = new[] { 3, -7, 999, 0, 500 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Array.Sort(initArray);
            doublyLinkedList.Sort();

            Assert.AreEqual(initArray, doublyLinkedList.ToArray());
        }

        // Test sorting method
        [Test]
        public void SortInitializedList_ArrayNoNeedToSort_NotChanged()
        {
            var initArray = new[] { 3, 7, 10 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.Sort();

            Assert.AreEqual(initArray, doublyLinkedList.ToArray());
        }

        /// <summary>
        /// Reverse method
        /// </summary>
        // Test reverse linked list method
        [Test]
        public void ReverseLinkedList_OneElement_NotChanged()
        {
            var initArray = new[] { 3 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            
            Array.Reverse(initArray);
            doublyLinkedList.Reverse();

            Assert.AreEqual(initArray, doublyLinkedList.ToArray());
        }

        // Test reverse linked list method
        [Test]
        public void ReverseLinkedList_ManyElements_Reversed()
        {
            var initArray = new[] { 3, 7, 18, -9 };
            var arrayToCompare = new[] {-9, 18, 7, 3};
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.Reverse();

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        // Test reverse linked list method
        [Test]
        public void ReverseLinkedList_EmptyList_NoErrors()
        {
            var arrayToCompare = new int[] { };
            var doublyLinkedList = new EList();
            
            doublyLinkedList.Reverse();

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        /// <summary>
        /// HalfReverse method
        /// </summary>
        // Test Halfreverse linked list method
        [Test]
        public void HalfReverseList_OneElement_NotChanged()
        {
            var initArray = new[] { 3 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);
            
            doublyLinkedList.HalfReverse();

            Assert.AreEqual(initArray, doublyLinkedList.ToArray());
        }

        // Test Halfreverse linked list method
        [Test]
        public void HalfReverseList_TwoElements_NotChanged()
        {
            var initArray = new[] { 3, 99 };
            var arrayToCompare = new[] { 99, 3 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.HalfReverse();

            Assert.AreEqual(arrayToCompare, doublyLinkedList.ToArray());
        }

        // Test Halfreverse linked list method
        [Test]
        public void HalfReverseList_OddNodesNumber_HalfSorted_LastUnchanged()
        {
            var initArray = new[] { 3, 7, 15, 18, 0 };
            var initArrayToCompare = new[] { 18, 0, 15, 3, 7 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            doublyLinkedList.HalfReverse();

            Assert.AreEqual(initArrayToCompare, doublyLinkedList.ToArray());
        }

        // Test Halfreverse linked list method
        [Test]
        public void HalfReverseList_EvenNodesNumber_HalfSorted()
        {
            var initArray = new[] { 1, 3, 6, 10, 15, 18 };
            var initArrayToCompare = new[] { 10, 15, 18, 1, 3, 6 };
            
            var doublyLinkedList = new EList();
            doublyLinkedList.Init(initArray);

            doublyLinkedList.HalfReverse();

            Assert.AreEqual(initArrayToCompare, doublyLinkedList.ToArray());
        }

        /// <summary>
        /// ToString method
        /// </summary>
        // test empty list to string
        [Test]
        public void ToString_EmptyList_NoError()
        {
            var doublyLinkedList = new EList();

            Assert.AreEqual(string.Join(", ", new int[] {}), doublyLinkedList.ToString());
        }

        // test initialized list to string
        [Test]
        public void ToString_InitializedList_String()
        {
            var initArray = new[] { 3, 7, 15, 18, 0 };
            var doublyLinkedList = new EList();

            doublyLinkedList.Init(initArray);

            Assert.AreEqual(string.Join(", ", initArray), doublyLinkedList.ToString());
        }
    }
}
