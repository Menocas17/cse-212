using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
    // Expected Result: in the _queue the elements were added one after the other in order and the data and priority is stored: [Valu1 (Pri:1), value2 (Pri:2), value3 (Pri:3)]"
    // Defect(s) Found: No defects found :) 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Valu1", 1);
        priorityQueue.Enqueue("value2", 2);
        priorityQueue.Enqueue("value3", 3);

        var expectedResult = "[Valu1 (Pri:1), value2 (Pri:2), value3 (Pri:3)]";

        var result = priorityQueue.ToString();

        Assert.AreEqual(result, expectedResult);
    }


    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with the highest priority and return its value.
    // Expected Result: The value who gets dequeue should be value 3 as it has the higher prioity with 90
    // Defect(s) Found: I found that there is an error in the range of iteration in the high priority calculation, which never takes in consideration the last item of the queque. I corrected the issue by changing the index range calculation
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("value1", 30);
        priorityQueue.Enqueue("value2", 50);
        priorityQueue.Enqueue("value3", 90);

        var expectedResult = "value3";

        var quequeAfterRemoving = "[value1 (Pri:30), value2 (Pri:50)]";

        var result = priorityQueue.Dequeue();

        Assert.AreEqual(result, expectedResult);
        Assert.AreEqual(priorityQueue.ToString(), quequeAfterRemoving);
    }

    [TestMethod]
    // Scenario: If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Expected Result: The value number 4 should be dequeque because it's has the same priority as value number 6 but is closest to the beggining of the queque
    // Defect(s) Found: I found that there is an error in the operator when comparing the hightness of priority, as it was >= and it should just > in order to keep the value closer to the beggining of the queque and with the highest priproty 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("value1", 30);
        priorityQueue.Enqueue("value2", 10);
        priorityQueue.Enqueue("value3", 50);
        priorityQueue.Enqueue("value4", 90);
        priorityQueue.Enqueue("value5", 14);
        priorityQueue.Enqueue("value5", 90);


        var expectedResult = "value4";

        var result = priorityQueue.Dequeue();

        Assert.AreEqual(result, expectedResult);
    }
    

            [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown.
    // Expected Result: There should be an exception error
    // Defect(s) Found: No defects found :)
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();


          try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }


    }
}