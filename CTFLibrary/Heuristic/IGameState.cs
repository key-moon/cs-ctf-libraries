using System;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public interface IGameState<T>
    {
        const double WIN = double.PositiveInfinity;
        const double LOSE = double.NegativeInfinity;
        public double EvaluationValue { get; }
        public IEnumerable<T> NextStates();
    }
}
