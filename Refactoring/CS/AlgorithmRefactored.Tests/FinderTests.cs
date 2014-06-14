using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Tests
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var result = GetAgeComparison(AgeDifference.Closest, new List<Person>());
            AssertNull(result);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var result = GetAgeComparison(AgeDifference.Closest, new List<Person>() { sue });
            AssertNull(result);
        }

        
        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var result = GetAgeComparison(AgeDifference.Closest, new List<Person>() { sue, greg });
            AssertSame(result, sue, greg);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var result = GetAgeComparison(AgeDifference.Furthest, new List<Person>() { greg, mike });
            AssertSame(result, greg, mike);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var result = GetAgeComparison(AgeDifference.Furthest, 
                new List<Person>() { greg, mike, sarah, sue });
            AssertSame(result, sue, sarah);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var result = GetAgeComparison(AgeDifference.Closest,
                new List<Person>() { greg, mike, sarah, sue });
            AssertSame(result, sue, greg);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };

        private Combination GetAgeComparison(IAgeStrategy ageStrategy, List<Person> people)
        {
            var finder = new Finder(people);
            return finder.FindCombinationWith(ageStrategy);
        }

        public void AssertNull(Combination result)
        {
            Assert.Null(result.OlderPerson);
            Assert.Null(result.YoungerPerson);
        }

        public void AssertSame(Combination result, Person olderPerson, Person youngerPerson)
        {
            Assert.Same(olderPerson, result.OlderPerson);
            Assert.Same(youngerPerson, result.YoungerPerson);
        }

    }
}