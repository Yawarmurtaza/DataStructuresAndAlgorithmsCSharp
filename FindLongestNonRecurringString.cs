public int[] FindLongestNonRecurringString(string input)
{
    if (input == null) return null;
    if (input == string.Empty)
    {
        return new int[] { 0, 0, 0 };
    }
    if (input.Length == 1)
    {
        return new int[] { 0, 0, 1 };
    }

    // to keep track of chars that we have visited and their indices
    IDictionary<char, int> visited = new Dictionary<char, int>();
   
    int startIndex = 0;
    int tempLen = 0;
    int finalLen = 0;
    int lenStartIndex = 0;
    int[] result = new int[3];
    for (int i = 0; i < input.Length; i++)
    {
        char c = input[i];
        if (visited.ContainsKey(c))
        {
            if (startIndex < visited[c] + 1)
                startIndex = visited[c] + 1;

            tempLen = i - startIndex + 1; // tempLen should be from last non repeating char till start index.
            visited[c] = i; // last seen index..
        }
        else
        {
            visited.Add(c, i);
            tempLen++;
        }

        if (finalLen < tempLen)
        {
            lenStartIndex = startIndex; // we need to store the start index of longest length.
            finalLen = tempLen;
        }
    }
    
    result[0] = lenStartIndex;
    result[1] = lenStartIndex + finalLen - 1;
    result[2] = finalLen;
    return result;
}
// Unit tests
[TestCase("1234567890_=-()*&^%$£!", 0, 21, 22)]
[TestCase("qqqqqqqwwwwwrrrrwwwwtteteyrtrytuyiuoupupuoyoiyiruryurytuturirueyasdfghjklmnbvcxz", 59, 79, 21)]
[TestCase("asdfghjklmnbvcxzqqqqqqqwwwwwrrrrwwwwtteteyrtrytuyiuoupupuoyoiyiruryurytuturiruey", 0, 16, 17)]
[TestCase("", 0, 0, 0)]
[TestCase("1234567890", 0, 9, 10)]
[TestCase("a", 0, 0, 1)]
[TestCase("abcadefghhijklmnopqqqqqqqqqqq", 9, 18, 10)]
[TestCase("abcadefghhijklmnopq", 9, 18, 10)]
[TestCase("abcadefgh", 1, 8, 8)]
[TestCase("MyNameIsYawarbcdfghjklggggggggggg", 10, 21, 12)]
[TestCase("MyNameIsYawarbcdfg", 10, 17, 8)]
[TestCase("MyNameIsYawar", 1, 7, 7)]
public void FindLongestNonRecurringString(string input, int startIndex, int endIndex, int expectedLen)
{
    int[] result = runner.FindLongestNonRecurringString(input.ToLower());
    Assert.AreEqual(expectedLen, result[2]);
    Assert.AreEqual(endIndex, result[1]);
    Assert.AreEqual(startIndex, result[0]);
}
