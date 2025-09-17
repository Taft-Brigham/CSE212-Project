public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // My Plan :
        // 1. Create a new double array with size 'length'.
        // 2. For each index i from 0 to length - 1:
        //      a. Compute the (i+1)-th multiple of 'number' (that is number * (i + 1)).
        //      b. Store it into result[i].
        // 3. Return the result array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            // i = 0 -> first multiple = number * 1
            // i = 1 -> second multiple = number * 2
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // My Plan For RotateListRight:
        // 1. Handle trivial cases: if data is null or has 0 or 1 element, nothing to do.
        // 2. Normalize 'amount' to handle cases where amount == data.Count (use amount % data.Count).
        //    i. If amount % data.Count == 0 then the list would be unchanged; return early.
        // 3. Use list slicing (GetRange) to build two slices:
        //      i. endSlice = the last 'amount' elements (these will become the new front).
        //      ii. startSlice = the first data.Count - amount elements (these will follow).
        // 4. Clear the original list and AddRange endSlice then startSlice to reconstruct rotated list.
        
        if (data == null || data.Count <= 1)
            return;

        // Normalize amount in case it's equal to data.Count (so rotation by data.Count => no change)
        amount = amount % data.Count;
        if (amount == 0)
            return;

        // Take the last 'amount' elements
        List<int> endSlice = data.GetRange(data.Count - amount, amount);

        // Take the first part (everything except the last 'amount' elements)
        List<int> startSlice = data.GetRange(0, data.Count - amount);

        // Rebuild the list: last part first, then the start part
        data.Clear();
        data.AddRange(endSlice);
        data.AddRange(startSlice);
    }
}
