using Transform;
using System.Text;

public static class BWTTest
{
    public static bool Test()
    {
        string[] tests = { "banana", "SIX.MIXED.PIXIES.SIFT.SIXTY.PIXIE.DUST.BOXES", "0c\\ab", "\\cba0", "\\0", "0\\" , "ехал грека через реку видит грека в реке рак сунул грека руку в реку рак за руку грека цап" };
        foreach (string testCase in tests)
        {
            (StringBuilder BWTString, int lastPosition) = BWT.DirectBWT(testCase);
            if (BWTString.Length != testCase.Length && lastPosition == 0)
            {
                return false;
            }
            if (String.Compare(testCase, BWT.ReverseBWT(BWTString, lastPosition).ToString()) != 0)
            {
                return false;
            }
        }
        return true;
    }
}
