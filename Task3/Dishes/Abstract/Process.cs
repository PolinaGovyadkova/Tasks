using System;
using System.Collections.Generic;
using Dishes.Interfaces;

namespace Dishes.Abstract
{
    public abstract class Process : IProcessing
    {
        public abstract int Load { get; set; }

        protected Process(TimeSpan time, float price)
        {
            Time = time;
            Price += price;
        }

        public TimeSpan Time { get; }
        public float Price { get; }

        public abstract Product Update(Product product);
        public override bool Equals(object obj) => obj is Process process && process.Load == Load && process.Time == Time && process.Price == Price;
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => GetType().Name;
    }
}