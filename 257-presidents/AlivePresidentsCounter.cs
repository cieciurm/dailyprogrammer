using System.Collections.Generic;
using System.Linq;

namespace Mateusz.DailyProgrammer._257
{
    public class AlivePresidentsCounter
    {
        private readonly IEnumerable<President> _presidents;

        public AlivePresidentsCounter()
        {
            var reader = new Reader();
            _presidents = reader.GetPresidents();
        }

        public IEnumerable<int> GetYearsWithHighestCountOfAlivePresidents()
        {
            var years = Enumerable.Range(1800, 216).ToList();

            var yearsWithHighestCount = new List<int>();
            var highestCount = 0;
            foreach (var year in years)
            {
                var count = GetAlivePresidentsCount(year);

                if (count > highestCount)
                {
                    highestCount = count;
                    yearsWithHighestCount.Clear();
                    yearsWithHighestCount.Add(year);
                }
                else if (count == highestCount)
                {
                    yearsWithHighestCount.Add(year);
                }
            }

            return yearsWithHighestCount;
        }

        private int GetAlivePresidentsCount(int year)
        {
            int alivePresidentsCount = 0;

            foreach (var president in _presidents)
            {
                if (president.IsAlive(year))
                {
                    alivePresidentsCount++;
                }
            }

            return alivePresidentsCount;
        }
    }
}
