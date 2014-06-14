namespace Algorithm
{
    public class FurtherAgeStrategy : IAgeStrategy
    {
        public bool IsMatch(Combination first, Combination second)
        {
            return first.DifferenceInAge > second.DifferenceInAge;
        }
    }
}