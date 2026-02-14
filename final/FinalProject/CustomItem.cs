namespace LaserOrderCalculator
{
    public sealed class CustomItem : OrderItem
    {
        public override void Parse(string raw)
        {
            var kv = SimpleTokens.ParseKeyValues(raw);
            Qty = kv.GetInt("qty", 1);
            WidthIn = kv.GetDecimal("w", 0);
            HeightIn = kv.GetDecimal("h", 0);
        }

        public override string Category() => "CUSTOM";
    }
}
