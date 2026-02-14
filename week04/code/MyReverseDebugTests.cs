//creatint a small test file just to see the output of 
//the Reverse() method in the LinkedList class. 
//This is not a comprehensive test, just a quick check 
//to see if the Reverse() method is working as expected.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

[TestClass]
public class MyReverseDebugTests
{
    [TestMethod]
    public void Reverse_DebugPrints()
    {
        var myLinkedList = new LinkedList();
        myLinkedList.InsertTail(1);
        myLinkedList.InsertTail(2);
        myLinkedList.InsertTail(3);

        foreach (var item in myLinkedList.Reverse())
        {
            Debug.WriteLine(item); // Visible in Debug Console when you click "Debug Test"
        }
    }
}