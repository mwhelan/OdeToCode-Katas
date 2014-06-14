namespace Algorithm
{
    public class AgeDifference
    {
        public static IAgeStrategy Closest
        {
            get
            {
                return new ClosestAgeStrategy();
            }
        }

        public static IAgeStrategy Furthest
        {
            get
            {
                return new FurtherAgeStrategy();
            }
        }
    }

    public enum AgeDifference2
    {
        Closest,
        Furthest
    }
}