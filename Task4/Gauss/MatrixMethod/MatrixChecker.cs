using System;

namespace Gauss.MatrixMethod
{
    public static class MatrixChecker
    {
        public static void CheckRow(int rowFirst, int rowCount)
        {
            if (rowFirst < 0 || rowFirst > rowCount)
                throw new InvalidOperationException("Row number cannot be <0 or > row count");
        }

        public static void CheckColumn(int position, int columnCount)
        {
            if (position < 0 || position > columnCount)
                throw new InvalidOperationException("Column number cannot be < 0 or > column count");
        }
    }
}