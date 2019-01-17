private struct VisitedCharIndex
{
    public int Index { get; set; }
    public bool Visited { get; set; }
    public char Char { get; set; }  
}

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

    VisitedCharIndex[] visited = new VisitedCharIndex[255];
    int startIndex = 0;
    int tempLen = 0;
    int finalLen = 0;
    int lenStartIndex = 0;
    int[] result = new int[3];
    for (int i = 0; i < input.Length; i++)
    {
        char c = input[i];
        if (visited[c].Visited)
        {
            if (startIndex < visited[c].Index + 1)
                startIndex = visited[c].Index + 1;

            tempLen = i - startIndex + 1;
            visited[c].Index = i; // last seen index..
        }
        else
        {
            visited[c].Index = i;
            visited[c].Visited = true;
            visited[c].Char = c;
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
[TestCase("MyNameIsImanbcdfghjklggggggggggg", 7, 20, 14)]
[TestCase("MyNameIsImanbcdfg", 7, 16, 10)]
[TestCase("MyNameIsIman", 1, 7, 7)]
public void FindLongestNonRecurringString(string input, int startIndex, int endIndex, int expectedLen)
{
    int[] result = runner.FindLongestNonRecurringString(input.ToLower());
    Assert.AreEqual(expectedLen, result[2]);
    Assert.AreEqual(endIndex, result[1]);
    Assert.AreEqual(startIndex, result[0]);
}
