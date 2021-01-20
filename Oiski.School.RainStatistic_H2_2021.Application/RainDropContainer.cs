﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.RainStatistic_H2_2021.Application
{
    /// <summary>
    /// A container that can store raindrop values collected over time
    /// </summary>
    public class RainDropContainer
    {
        /// <summary>
        /// The pool of raindrop values
        /// </summary>
        public decimal[] ValuePool { get; }

        /// <summary>
        /// Adds a range of raindrop values to the pool at the given <paramref name="_startIndex"/>
        /// </summary>
        /// <param name="_values">The values to insert</param>
        /// <param name="_startIndex">Where to begin inserting the values</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void AddRange (decimal[] _values, int _startIndex = 0)
        {
            int i = _startIndex;
            foreach ( decimal value in _values )
            {
                if ( i >= ValuePool.Length )
                {
                    throw new IndexOutOfRangeException($"Index was out of bounds for ValuePool: (Index ({i}) >= Length ({ValuePool.Length})).");
                }

                ValuePool[i] = value;
                i++;
            }
        }

        /// <summary>
        /// Creates a new instance of type <see cref="RainDropContainer"/> where the <paramref name="_poolSize"/> is defined
        /// </summary>
        /// <param name="_poolSize">The size of the raindrop value pool</param>
        public RainDropContainer (int _poolSize)
        {
            ValuePool = new decimal[_poolSize];
        }
    }
}