using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Mateusz.DailyProgrammer._257
{
    public class AlivePresidentsCounterTests
    {
        [Test]
        public void AlivePresidentsCounter_GetYearsWithHighestCountOfAlivePresidents()
        {
            var counter = new AlivePresidentsCounter();

            var years = counter.GetYearsWithHighestCountOfAlivePresidents().ToList();

            var correctYears = new List<int>
            {
                1822,
                1823,
                1824,
                1825,
                1826,
                1831,
                1833,
                1834,
                1835,
                1836,
                1837,
                1838,
                1839,
                1840,
                1841,
                1843,
                1844,
                1845
            };

            Assert.AreEqual(correctYears.Count, years.Count);
            foreach (var correct in correctYears)
            {
                Assert.Contains(correct, years);
            }
        }
    }

    public class ReaderTests
    {
        [Test]
        public void Reader_GetPresidents_CheckCount()
        {
            var reader = new Reader();

            var items = reader.GetPresidents();

            Assert.NotNull(items);
            Assert.AreEqual(43, items.Count());
        }
    }

    public class PresidentTests
    {
        [Test]
        public void PresidentIsAlive_DoDNull_ReturnsTrue()
        {
            var presidents = new President("name", new DateTime(1990,7,1));

            Assert.True(presidents.IsAlive(2014));
        }

        [Test]
        public void PresidentIsAlive_DoDNotNull_ReturnsFalse()
        {
            var presidents = new President("name", new DateTime(1900, 7, 1), new DateTime(1990, 7, 1));

            Assert.False(presidents.IsAlive(2014));
        }

        [Test]
        public void PresidentIsAlive_CheckBeforeDeathDate_ReturnsTrue()
        {
            var presidents = new President("name", new DateTime(1900, 7, 1), new DateTime(1990, 7, 1));

            Assert.True(presidents.IsAlive(1989));
        }

        [Test]
        public void PresidentIsAlive_CheckInYearOfDeathDate_ReturnsTrue()
        {
            var presidents = new President("name", new DateTime(1900, 7, 1), new DateTime(1990, 7, 1));

            Assert.True(presidents.IsAlive(1990));
        }
    }
}
