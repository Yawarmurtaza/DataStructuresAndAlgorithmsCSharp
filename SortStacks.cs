public Stack<int> SortStack(Stack<int> unsorted)
{
    Stack<int> partiallySorted = new Stack<int>(unsorted.Count);
    int temp;
    bool sortDescending = true;
    while (!IsSorted(partiallySorted.ToArray()))
    {
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

public  bool IsSorted(int[] arr)
{
    if (arr.Length < 1) return false;
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
 
