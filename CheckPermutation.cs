/*
 * Given two strings, write a method to decide if one is a permutation
 * of the other.         
 */
public bool CheckPermutation(string a, string b)
{
    // base cases...

    if (a == null || b == null) return false;
    if (a.Length != b.Length) return false;
    if (string.Compare(a, b, StringComparison.InvariantCulture) == 0) return true;

    var charMapA = new Dictionary<char, int>();
    foreach (var ch in a)
    {
        if (charMapA.ContainsKey(ch))
        {
            charMapA[ch]++;
        }
        else
        {
            charMapA.Add(ch, 1);
        }
    }

    var charMapB = new Dictionary<char, int>();
    foreach (var ch in b)
    {
        if (!charMapA.ContainsKey(ch)) return false;
        if (charMapB.ContainsKey(ch))
        {
            charMapB[ch]++;
        }
        else
        {
            charMapB.Add(ch, 1);
        }
    }

    // now check if the count for each char in a matches with those in b.
  
    for (int i = 0; i < charMapA.Count; i++)
    {
        if (charMapA[a[i]] != charMapB[a[i]])
        {
            return false;
        }
    }

    return true;
}

public bool CheckPermutation_UsingArray(string a, string b)
{
    // base cases...
    if (a == null || b == null) return false;
    if (a.Length != b.Length) return false;
    if (string.Compare(a, b, StringComparison.InvariantCulture) == 0) return true;

    int[] arr = new int[255];

    for (int i = 0; i < a.Length; i++)
    {
        arr[a[i]]++;
        arr[b[i]]++;
    }

    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 != 0)
        {
            return false;
        }
    }

    return true;
}
