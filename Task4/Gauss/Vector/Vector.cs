namespace Gauss.Vector
{
    public class Vector
    {
        private readonly double[] _answers;

        public Vector(double[] answers) => _answers = answers;

        public double this[int index] => _answers[index];
        public int Count => _answers.Length;
    }
}