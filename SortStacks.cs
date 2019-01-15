public Stack<int> SortStack(Stack<int> unsorted)
{
    Stack<int> sorted = new Stack<int>(unsorted.Count);
    int temp;
    bool sortDescending = true;
    while (!IsSorted(sorted.ToArray()))
    {
        if (sortDescending)
        {
            temp = unsorted.Pop();
            while (unsorted.Count > 0)
            {
                int temp2 = unsorted.Pop();
                if (temp > temp2)
                {
                    sorted.Push(temp);
                    temp = temp2;
                }
                else
                {
                    sorted.Push(temp2);
                }
            }

            sorted.Push(temp);// remaining int.
            sortDescending = false;
        }
        else
        {
            temp = sorted.Pop();
            while (sorted.Count > 0)
            {
                int temp2 = sorted.Pop();
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

    return sorted;
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