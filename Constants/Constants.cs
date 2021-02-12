using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Constants
{
    public static class Constants
    {
        public static List<TimeSpan> tijdstippen = GetTijdstippen(new List<TimeSpan>());

        private static List<TimeSpan> GetTijdstippen(List<TimeSpan> tijdstippen) {
            for (int i = 11; i < 14; i++)
            {
                for (int j = 0; j < 60; j+=15)
                {
                    tijdstippen.Add(new TimeSpan(i, j, 00));
                }
            }
            return tijdstippen;
        }
    }
}