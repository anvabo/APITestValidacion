using System.ComponentModel.DataAnnotations;

namespace APITestValidacion.Models.Binding
{
    public class RangoFecha : IParsable<RangoFecha>
    {
        [Required]
        public DateOnly? From { get; init; }
        public DateOnly? To { get; init; }

        public static RangoFecha Parse(string value, IFormatProvider? provider)
        {
            if (!TryParse(value, provider, out var result))
            {
                throw new ArgumentException("Could not parse supplied value.", nameof(value));
            }

            return result;
        }

        public static bool TryParse(string? value,
                                    IFormatProvider? provider, out RangoFecha dateRange)
        {
            var segments = value?.Split(',', StringSplitOptions.RemoveEmptyEntries
                                           | StringSplitOptions.TrimEntries);

            if (segments?.Length == 2
                && DateOnly.TryParse(segments[0], provider, out var fromDate)
                && DateOnly.TryParse(segments[1], provider, out var toDate))
            {
                dateRange = new RangoFecha { From = fromDate, To = toDate };
                return true;
            }

            dateRange = new RangoFecha { From = default, To = default };
            return false;
        }
    }
}
