using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Three items with different priorities.
    // Expected: Dequeue returns highest priority first (10, then 5, then 1).
    // Defect(s) Found:
    // - Off-by-one loop skipped the last element (could miss the real max).
    // - Did not remove the dequeued item (same item returned repeatedly).
    // - Tie-break used '>=' which broke FIFO among equal priorities.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("low", 1);
        pq.Enqueue("high", 10);
        pq.Enqueue("mid", 5);

        Assert.AreEqual("high", pq.Dequeue());
        Assert.AreEqual("mid", pq.Dequeue());
        Assert.AreEqual("low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Three items with the SAME priority.
    // Expected: Dequeue preserves insertion order (FIFO among equals).
    // Defect(s) Found:
    // - Using '>=' preferred later elements on ties (LIFO among equals).
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("a1", 5);
        pq.Enqueue("a2", 5);
        pq.Enqueue("a3", 5);

        Assert.AreEqual("a1", pq.Dequeue());
        Assert.AreEqual("a2", pq.Dequeue());
        Assert.AreEqual("a3", pq.Dequeue());
    }
}