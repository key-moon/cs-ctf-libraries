using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace CTFLibrary
{
    /// <summary>
    /// ビームサーチをする
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BeamSearchRunner<T> where T : IState<T>
    {
        public BeamSerachConfig Config;
        public BeamSearchRunner(BeamSerachConfig config)
        {
            Config = config;
        }

        public T NextState(T prevState)
        {
            IEnumerable<ImmutableStack<T>> states = new List<ImmutableStack<T>>() 
            {
                ImmutableStack<T>.Empty.Push(prevState) 
            };
            for (int i = 0; i < Config.BeamLength; i++)
            {
                for (int j = 0; j < Config.Turn; j++)
                {
                    states = states
                        .SelectMany(
                            x => x.PeekRef().NextStates().Select(nxt => x.Push(nxt))
                        )
                        .OrderByDescending(x => x.Peek().Score);
                }
                states = states.Take(Config.BeamWidth);
            }
            T res = default;
            var seq = states.First();
            while (!seq.IsEmpty)
            {
                res = seq.Peek();
                seq = seq.Pop();
            }
            return res;
        }
    }

    public class BeamSerachConfig
    {
        public int BeamWidth;
        public int BeamLength;
        public int Turn;
    }
}
