namespace FilerNS
{
    public interface IChecker
    {
        // Nullable Types
        // https://msdn.microsoft.com/en-us/library/1t3y8s4s(VS.80).aspx
        bool? PreExpandingCheck(string input);
        bool? PreCompressingCheck(string input);
    }
}
