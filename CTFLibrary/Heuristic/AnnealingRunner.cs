using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public class AnnealingRunner<T> where T : IState<T>
    {
        double StartTemp;
        double EndTemp;
        XorShift Rng;
        public bool Debug = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxTemp">考えられるスコアの最大値</param>
        /// <param name="minTemp">考えられるスコアの最小値</param>
        /// <param name="seed"></param>
        public AnnealingRunner(double maxTemp, double minTemp, ulong seed = 0)
        {
            StartTemp = maxTemp;
            EndTemp = minTemp;
            Rng = new XorShift(seed);
        }

        public T Run(T initState, double time = 5)
        {
            var startAt = DateTime.Now;
            var invTime = 1 / time;

            T cur = initState;
            T res = cur;

            int cnt = 0;
            double temp = StartTemp;
            while (true)
            {
                if ((cnt & 1024) == 0)
                {
                    var progress = (double)(DateTime.Now - startAt).TotalSeconds * invTime;
                    if (1 <= progress) break;
                    temp = StartTemp + (EndTemp - StartTemp) * progress;
                    if (Debug) Console.WriteLine(cur.ToString());
                }
                
                var nxt = initState.RandomNextState;
                var prob = Math.Exp((nxt.Score - initState.Score) / temp);
                if (prob * uint.MaxValue >= Rng.UInt)
                {
                    cur = nxt;
                    if (res.Score < cur.Score) res = cur;
                }
                cnt++;
            }
            return res;
        }

    }
}
