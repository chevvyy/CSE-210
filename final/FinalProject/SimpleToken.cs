using System;
using System.Collections.Generic;
using System.Globalization;

namespace LaserOrderCalculator
{
    internal sealed class TokenBag
    {
        private readonly Dictionary<string, string> _kv;

        public TokenBag(Dictionary<string, string> kv)
        {
            _kv = kv ?? throw new ArgumentNullException(nameof(kv));
        }

        public int GetInt(string key, int fallback)
        {
            if (_kv.TryGetValue(key, out var v) &&
                int.TryParse(v, NumberStyles.Integer, CultureInfo.InvariantCulture, out var n))
            {
                return n;
            }

            return fallback;
        }

        public decimal GetDecimal(string key, decimal fallback)
        {
            if (_kv.TryGetValue(key, out var v) &&
                decimal.TryParse(v, NumberStyles.Number, CultureInfo.InvariantCulture, out var d))
            {
                return d;
            }

            return fallback;
        }
    }

    internal static class SimpleTokens
    {
        // "TYPE|qty=2|w=12|h=18" => { qty:2, w:12, h:18 }
        public static TokenBag ParseKeyValues(string raw)
        {
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var parts = raw.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (var p in parts)
            {
                var eq = p.IndexOf('=');
                if (eq <= 0) continue;

                var key = p[..eq].Trim();
                var val = p[(eq + 1)..].Trim();

                if (!string.IsNullOrWhiteSpace(key))
                {
                    dict[key] = val;
                }
            }

            return new TokenBag(dict);
        }
    }
}