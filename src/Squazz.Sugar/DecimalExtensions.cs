using System;
using System.Globalization;

namespace Squazz.Sugar
{
    public static class DecimalExtensions
    {
        private static readonly CultureInfo Culture = new CultureInfo("da-DK");

        public static string ToPriceString(this decimal? input)
        {
            if (input.HasValue)
                return input.Value.ToPriceString();

            return string.Empty;
        }

        public static string ToPriceString(this decimal input)
        {
            return input.ToString("###,###,##0.00 kr", Culture) + ".";
        }

        private static decimal ToPriceRoundedInternal(this decimal price, int decimals, MidpointRounding midpointRounding)
        {
            //AwayFromZero means if its 100.505, then its rounding to 100.51
            //and if its 100.504, then its rounding to 100.50
            //Its same in the ToPriceString() format function

            return Math.Round(price, decimals, midpointRounding);
        }

        public static decimal ToPriceRoundedZeroDecimalsAwayFromZero(this decimal price)
        {
            return price.ToPriceRoundedInternal(0, MidpointRounding.AwayFromZero);
        }

        public static decimal ToPriceRoundedTwoDecimalsAwayFromZero(this decimal price)
        {
            return price.ToPriceRoundedInternal(2, MidpointRounding.AwayFromZero);
        }

        public static decimal ToPriceRoundedZeroDecimalsDownToZero(this decimal price)
        {
            return price.ToPriceRoundedInternal(0, MidpointRounding.ToEven);
        }

        public static decimal GetSalesPrice(decimal listPrice, decimal discountPercentage)
        {
            return (listPrice - listPrice * (discountPercentage / 100)).ToPriceRoundedZeroDecimalsAwayFromZero();
        }

        /// <summary>
		/// Important, this should only be used to a view. WHen the percentage is rounded, it should not be used to calculate
		/// </summary>
        public static decimal RoundDiscountPercentage(decimal discountPercentage)
        {
            return Math.Round(discountPercentage, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Important, this should only be used to a view. WHen the percentage is rounded, it should not be used to calculate
        /// </summary>
        public static decimal GetDiscountPercentageRounded(decimal listPrice, decimal salesPrice)
        {
            //TODO: Theres a static class called SengeSpecialisten.Models.Extensions.Percentage.
            //Maybe put it in there?
            if (listPrice == 0)
                return 0;
            decimal discountPercentage = 1 - (salesPrice / listPrice); //eg 0.554
            discountPercentage *= 100; //now its 55.4
            return RoundDiscountPercentage(discountPercentage); //Now its 55
        }
    }
}
