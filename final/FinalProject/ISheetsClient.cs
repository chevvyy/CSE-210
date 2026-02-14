using System.Collections.Generic;

namespace LaserOrderCalculator
{
    public interface ISheetsClient
    {
        List<List<string>> Read(string rangeA1);
    }
}
