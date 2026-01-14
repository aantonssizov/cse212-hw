using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test Enquing and Dequing in the right order based of priority 
    // Expected Result: message2, message3, message1
    // Defect(s) Found: the loop didn't work as it didn't include last item, and it also didn't remove item from the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("message1", 1);
        priorityQueue.Enqueue("message2", 3);
        priorityQueue.Enqueue("message3", 2);

        Assert.AreEqual("message2", priorityQueue.Dequeue());
        Assert.AreEqual("message3", priorityQueue.Dequeue());
        Assert.AreEqual("message1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: If there are two items with the same highest priority, the first one added should be removed.
    // Expected Result: message1, message4, message2, message3
    // Defect(s) Found: highest index was changing if the priority level was the same
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("message1", 3);
        priorityQueue.Enqueue("message2", 2);
        priorityQueue.Enqueue("message3", 2);
        priorityQueue.Enqueue("message4", 3);

        Assert.AreEqual("message1", priorityQueue.Dequeue());
        Assert.AreEqual("message4", priorityQueue.Dequeue());
        Assert.AreEqual("message2", priorityQueue.Dequeue());
        Assert.AreEqual("message3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Make sure that queue is not able to dequeue if it's empty
    // Expected Result: The queue is empty.
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Should throw exception if empty");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}