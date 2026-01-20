public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        // PLAN:
        // 1. Create an array to hold 'length' items.
        // 2. Loop from i = 0 to i < length.
        // 3. For each i, compute number * (i + 1).
        // 4. Store the result into the array at index i.
        // 5. Return the array.


        //comment 1. Create an array to hold 'length' items.
        double[] multiples = new double[length];

        //comment 2. Loop from i = 0 to i < length.
        for (int i = 0; i < length; i++)

        {
            //comment 3. and 4. For each i, compute number * (i + 1) and store the result into the array at index i.
            multiples[i] = number * (i + 1);

        }
        //comment 5. Return the array.
        return multiples;
    }
        //comment End Problem 1
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.




        // PLAN:
        // 1. Figure out where to split the list by subtracting amount from the list size.
        // 2. Extract the last 'amount' items (these will move to the front).
        // 3. Extract the items before the split (these will move after the first part).
        // 4. Clear the original list so we can rebuild it in rotated order.
        // 5. Add the last items first.
        // 6. Add the first items next.

        // 1. Find the index to cut the list
        int cutIndex = data.Count - amount;

        // 2. Get the last 'amount' elements
        List<int> rightPart = data.GetRange(
            cutIndex, amount);

        // 3. Get the first part of the list
        List<int> leftPart = data.GetRange(0, cutIndex);

        // 4. Clear the original list so we can rebuild it in rotated order.
        data.Clear();

        // 5. Add the last items first.
        data.AddRange(rightPart);

        // 6. Add the first items next.
        data.AddRange(leftPart);
    }
}
