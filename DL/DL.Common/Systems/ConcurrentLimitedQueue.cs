﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DL.Common.Systems
{
    /// <summary>
    /// 定长队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentLimitedQueue<T> : ConcurrentQueue<T>
    {
        public int Limit { get; set; }

        public ConcurrentLimitedQueue(int limit)
        {
            Limit = limit;
        }

        public ConcurrentLimitedQueue(IEnumerable<T> list) : base(list)
        {
            Limit = list.Count();
        }

        public new void Enqueue(T item)
        {
            if (Count >= Limit)
            {
                TryDequeue(out var _);
            }

            base.Enqueue(item);
        }
    }
}