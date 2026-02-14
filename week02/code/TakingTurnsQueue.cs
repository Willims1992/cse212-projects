/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private class Entry
    {
        public Person Person { get; }
        // null => infinite turns (original Person.Turns <= 0)
        public int? Remaining { get; set; }

        public Entry(Person person)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
            Remaining = person.Turns > 0 ? person.Turns : (int?)null;
        }
    }

    private readonly Queue<Entry> _queue = new();

    /// <summary>
    /// Number of active people currently in the queue.
    /// </summary>
    public int Length => _queue.Count;

    /// <summary>
    /// Enqueue a person by name with the specified number of turns.
    /// Turns <= 0 are treated as infinite.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _queue.Enqueue(new Entry(person));
    }

    /// <summary>
    /// Dequeue the next person in round-robin order and return them.
    /// Re-enqueue if they have remaining turns or infinite turns.
    /// Throws InvalidOperationException("No one in the queue.") if empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        var entry = _queue.Dequeue();
        var result = entry.Person;

        if (entry.Remaining == null)
        {
            // Infinite: always re-enqueue; never mutate Person.Turns.
            _queue.Enqueue(entry);
        }
        else if (entry.Remaining > 1)
        {
            // Consume one and re-enqueue while turns remain.
            entry.Remaining--;
            _queue.Enqueue(entry);
        }
        else
        {
            // Remaining == 1: last turn; do not re-enqueue.
        }

        return result;
    }
}