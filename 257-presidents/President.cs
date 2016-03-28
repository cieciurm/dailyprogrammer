using System;

namespace Mateusz.DailyProgrammer._257
{
    public class President
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public President(string name, DateTime dateOfBirth, DateTime? dateOfDeath = null)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
        }

        public bool IsAlive(int year)
        {
            if (year < DateOfBirth.Year)
            {
                return false;
            }

            if (DateOfDeath == null)
            {
                return true;
            }

            return DateOfDeath.Value.Year >= year;
        }
    }
}