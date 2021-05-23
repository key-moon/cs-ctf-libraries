using System;
using System.Collections.Generic;
using System.Text;

namespace CTFLibrary
{
    public interface IState<T>
    {
        public double Score { get; }
        public T RandomNextState { get; }
        public IEnumerable<T> NextStates();
    }
}
