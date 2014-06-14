namespace Algorithm
{
    public class ClosestAgeStrategy : IAgeStrategy
    {
        public bool IsMatch(Combination first, Combination second)
        {
            return first.DifferenceInAge < second.DifferenceInAge;
        }
    }
}