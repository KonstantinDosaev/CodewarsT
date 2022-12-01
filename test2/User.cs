using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    public class User
    {
        public int rank  = -8;
        public int progress = 0;
        public void incProgress (int kataRank)
        {
            if (kataRank > 8 || kataRank < -8 || kataRank == 0) throw new ArgumentException("Invalid number", "Rank kata");
            try
            {
                if (rank - kataRank == -1 && rank > kataRank && rank != 8 ||  kataRank == -1 && rank == 1) { IncRank(1);return; }
                if (rank > kataRank || rank > 8) return;
                if (rank == kataRank) { IncRank(3); return; }
                var diffRank = rank;
                var diffCounter = 0;
                while (diffRank != kataRank)
                {   
                    diffCounter++;
                    if (diffRank == -1) { diffRank = 1; continue; }
                    diffRank += 1;
                }
                IncRank((int)(Math.Pow(diffCounter, 2)) * 10);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
        }
        public void IncRank(int progressUp)
        {
            progress += progressUp;
             
            while (progress>=100)
            {
                progress -= 100;
                switch (rank)
                {
                    case 8: progress = 0; break;
                    case -1: rank = 1; break;
                    default: rank += 1; ; break;
                }                   
            }
        }
    }
}
