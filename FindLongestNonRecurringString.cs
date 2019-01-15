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

    int[] visited = new int[255]; // get the unicode....
    int tempLen = 0;
    int finalLen = 0;
    int endIndex = 0;
    int[] result = new int[3];
    for (int i = 0; i < input.Length; i++)
    {
        char c = input[i];
        visited[c]++;
        tempLen++;
        if (visited[c] > 1)
        {
            tempLen = 1; // because new string will start from this count...

        }
        if (finalLen < tempLen)
        {
            endIndex = i;
            finalLen = tempLen;
        }

        int startIndex = endIndex - finalLen + 1;
        result[0] = startIndex;
        result[1] = endIndex;
        result[2] = finalLen;
    }

    return result;
}

// unit tests..
[TestCase("1234567890_=-()*&^%$£!", 0, 21, 22)]
[TestCase("1234567890", 0, 9, 10)]
[TestCase("qqqqqqqwwwwwrrrrwwwwtteteyrtrytuyiuoupupuoyoiyiruryurytuturirueyasdfghjklmnbvcxz", 63, 79, 17)]
[TestCase("asdfghjklmnbvcxzqqqqqqqwwwwwrrrrwwwwtteteyrtrytuyiuoupupuoyoiyiruryurytuturiruey", 0, 16, 17)]
[TestCase("", 0, 0, 0)]
[TestCase("a", 0, 0, 1)]
[TestCase("abcadefghhijklmnopqqqqqqqqqqq", 9, 18, 10)]
[TestCase("abcadefghhijklmnopq", 9, 18, 10)]
[TestCase("abcadefgh", 3, 8, 6)]
public void FindLongestNonRecurringString(string input, int startIndex, int endIndex, int expectedLen)
{
    int[] result = runner.FindLongestNonRecurringString(input);
    Assert.AreEqual(expectedLen, result[2]);
    Assert.AreEqual(endIndex, result[1]);
    Assert.AreEqual(startIndex, result[0]);
}
