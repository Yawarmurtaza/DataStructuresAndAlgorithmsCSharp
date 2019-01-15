/// <summary>
/// Sorts an unsorted stack and returns it.
/// </summary>
/// <param name="unsorted">Unsorted stack to be sorted.</param>
/// <returns>Sorted stack.</returns>
public Stack<int> SortStack(Stack<int> unsorted)
{
    if (unsorted == null) return null;
    if (unsorted.Count < 2) return unsorted;

    Stack<int> partiallySorted = new Stack<int>(unsorted.Count);
    bool sortDescending = true;
    while (!IsSorted(partiallySorted.ToArray()))
    {
        int temp;
        if (sortDescending)
        {
            temp = unsorted.Pop();
            while (unsorted.Count > 0)
            {
                int temp2 = unsorted.Pop();
                if (temp > temp2)
                {
                    partiallySorted.Push(temp);
                    temp = temp2;
                }
                else
                {
                    partiallySorted.Push(temp2);
                }
            }

            partiallySorted.Push(temp);// remaining int.
            sortDescending = false;
        }
        else
        {
            temp = partiallySorted.Pop();
            while (partiallySorted.Count > 0)
            {
                int temp2 = partiallySorted.Pop();
                if (temp < temp2)
                {
                    unsorted.Push(temp);
                    temp = temp2;
                }
                else
                {
                    unsorted.Push(temp2);
                }
            }

            unsorted.Push(temp);// remaining int.
            sortDescending = true;
        }
    }

    return partiallySorted;
}

/// <summary>
/// Determines if given integer array is sorted (ascending or descending) 
/// </summary>
/// <param name="arr">Array to check</param>
/// <returns>A value that indicates if the array is sorted. True is sorted, false otherwise.</returns>
public  bool IsSorted(int[] arr)
{
    // edge cases...
    if (arr.Length < 1) return false;
    if (arr.Length == 1) return true;
    
    int diff = arr[1] - arr[0];
    
    // if the diff is a positive number than its ascending order else descending
    if (diff > 0)
    {
        // is ascending order...
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i + 1]) return false;
        }
    }
    else
    {
        // is descending order...
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] < arr[i + 1]) return false;
        }
    }

    return true;
}


// Unit tests...
[TestCase(new int[] { 5 })]
[TestCase(new int[] { -10, 55, 1, 4, -8, 2, 3, -5, 50, -200, 33, 7, 9, -3 })]
[TestCase(new int[] { 10, 55, 1, 4, 8, 2, 3, 5, 50 })]
[TestCase(new int[] { 4, 8, 2, 3, 5, 50 })]
public void SortStack(int[] unsortedArrayToStack)
{
    Stack<int> unSorted = new Stack<int>(unsortedArrayToStack);
    Stack<int> sorted = runner.SortStack(unSorted);

    // Assert..

    Assert.IsTrue(runner.IsSorted(sorted.ToArray()));
}

[Test]
public void SortStack_ShouldReturnNullWhenInputStackIsNull()
{
    Stack<int> result = runner.SortStack(null);
    Assert.IsNull(result);
}

[Test]
public void SortStack_ShouldReturnEmptyStackWhenAnEmpryStackIsInput()
{
    Stack<int> unSorted = new Stack<int>(new int[] { });
    Stack<int> sorted = runner.SortStack(unSorted);

    // Assert... since empty stack is not considered as sorted....
    Assert.IsFalse(runner.IsSorted(sorted.ToArray()));
}


/*IsSorted unit tests...*/
[TestCase(new int[] { 5 })]
[TestCase(new int[] { 1, 2, -3, 4, 5, -6, 7, 8, -9 }, false)]
[TestCase(new int[] { 10, 2, -3, -4, -5, -6, -7, -8, -9 }, true)]
[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, true)]
public void IsSorted(int[] arr, bool expectedResult)
{
    bool result = runner.IsSorted(arr);
    Assert.AreEqual(expectedResult, result);
}
 
