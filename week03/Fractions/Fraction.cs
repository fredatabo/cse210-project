namespace Fractions
{
    public class Fraction
    {
        // Private attributes
        private int _top;
        private int _bottom;

        // Constructors
        // Constructor with no parameters (defaults to 1/1)
        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        // Constructor with one parameter (denominator defaults to 1)
        public Fraction(int top)
        {
            _top = top;
            _bottom = 1;
        }

        // Constructor with two parameters
        public Fraction(int top, int bottom)
        {
            if (bottom == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            _top = top;
            _bottom = bottom;
        }

        // Getters and Setters for Top
        public int GetTop()
        {
            return _top;
        }

        public void SetTop(int top)
        {
            _top = top;
        }

        // Getters and Setters for Bottom
        public int GetBottom()
        {
            return _bottom;
        }

        public void SetBottom(int bottom)
        {
            if (bottom == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            _bottom = bottom;
        }

        // Method to return fraction as string
        public string GetFractionString()
        {
            return $"{_top}/{_bottom}";
        }

        // Method to return decimal value
        public double GetDecimalValue()
        {
            return (double)_top / _bottom;
        }
    }
}