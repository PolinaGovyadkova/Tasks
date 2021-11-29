using System.Linq;

namespace Gauss.Vector
{
    public class Vector
    {
        private readonly double[] _answers;

        public Vector(double[] answers) => _answers = answers;

        public double this[int index] => _answers[index];
        public int Count => _answers.Length;
        public override string ToString() => $"{GetType().Name}. Count: {Count}";
        
        public bool Equals(Vector other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return _answers.Except(other._answers).Any() == false;
        }

        public override int GetHashCode() => _answers.GetHashCode();
    }
}