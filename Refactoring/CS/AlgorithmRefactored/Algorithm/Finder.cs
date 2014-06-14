using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Combination FindCombinationWith(IAgeStrategy ageStrategy)
        {
            var candidates = GetPossibleCombinations();
            return ChooseBestCombinationFrom(candidates, ageStrategy);
        }

        private Combination ChooseBestCombinationFrom(List<Combination> candidates, IAgeStrategy ageStrategy)
        {
            if (ThereAreNoCombinations(candidates))
            {
                return new Combination();
            }

            Combination answer = candidates[0];
            foreach (var candidate in candidates)
            {
                if (ageStrategy.IsMatch(candidate, answer))
                {
                    answer = candidate;
                }
            }

            return answer;
        }

        private List<Combination> GetPossibleCombinations()
        {
            var ageComparisons = new List<Combination>();

            for (var i = 0; i < _people.Count - 1; i++)
            {
                var firstPerson = _people[i];
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var secondPerson = _people[j];
                    var ageComparison = new Combination();
                    if (firstPerson.IsOlderThan(secondPerson))
                    {
                        ageComparison.OlderPerson = firstPerson;
                        ageComparison.YoungerPerson = secondPerson;
                    }
                    else
                    {
                        ageComparison.OlderPerson = secondPerson;
                        ageComparison.YoungerPerson = firstPerson;
                    }
                    ageComparison.DifferenceInAge = ageComparison.YoungerPerson.BirthDate - ageComparison.OlderPerson.BirthDate;
                    ageComparisons.Add(ageComparison);
                }
            }
            return ageComparisons;
        }
        
        private static bool ThereAreNoCombinations(List<Combination> combinations)
        {
            return combinations.Count < 1;
        }
    }
}