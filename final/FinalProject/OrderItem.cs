namespace LaserOrderCalculator
{
    public abstract class OrderItem
    {
        private int _qty;
        private decimal _widthIn;
        private decimal _heightIn;

        public int Qty
        {
            get => _qty;
            set => _qty = value < 0 ? 0 : value;
        }

        public decimal WidthIn
        {
            get => _widthIn;
            set => _widthIn = value < 0 ? 0 : value;
        }

        public decimal HeightIn
        {
            get => _heightIn;
            set => _heightIn = value < 0 ? 0 : value;
        }

        public abstract void Parse(string raw);
        public abstract string Category();

        public decimal AreaSqIn() => WidthIn * HeightIn;
    }
}
