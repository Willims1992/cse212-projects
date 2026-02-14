


using System;
using System.Collections.Generic;

/// <summary>
/// A basic implementation of a FIFO Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the end of the queue (FIFO).
    /// </summary>
    public void Enqueue(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));
        _queue.Add(person); // append to the tail to preserve FIFO
    }

    /// <summary>
    /// Remove and return the person at the front of the queue.
    /// </summary>
    public Person Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var person = _queue[0];  // head
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty() => Length == 0;

    public override string ToString() => $"[{string.Join(", ", _queue)}]";
}