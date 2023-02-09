using supermarketapp.Enum;

namespace supermarketapp.UnitConverters
{
    public static class WeightUnitConverter
    {

        #region Kilo Converters
        private static decimal KiloToGram(decimal kilo)
        {
            return kilo * 1000;
        }
        private static decimal KiloToMiligram(decimal kilo)
        {
            return kilo * (1000 ^ 2);
        }
        private static decimal KiloToPound(decimal kilo)
        {
            return kilo * 2.205m;
        }
        private static decimal KiloToOunce(decimal kilo)
        {
            return kilo * 35.274m;
        }
        private static decimal ConvertFromKilo(WeightUnit toUnit, decimal conversionAmount)
        {
            switch (toUnit)
            {
                case WeightUnit.Gram: return KiloToGram(conversionAmount);
                case WeightUnit.Miligram: return KiloToMiligram(conversionAmount);
                case WeightUnit.Pound: return KiloToPound(conversionAmount);
                case WeightUnit.Ounce: return KiloToOunce(conversionAmount);
                default: return conversionAmount;

            }
        }
        #endregion

        #region Gram Converters
        private static decimal GramToKilo(decimal gram)
        {
            return gram / 1000;
        }
        private static decimal GramToMiligram(decimal gram)
        {
            return gram * 1000;
        }
        private static decimal GramToPound(decimal gram)
        {
            return KiloToPound(GramToKilo(gram));
        }
        private static decimal GramToOunce(decimal gram)
        {
            return KiloToOunce(GramToKilo(gram));
        }
        private static decimal ConvertFromGram(WeightUnit toUnit, decimal conversionAmount)
        {
            switch (toUnit)
            {
                case WeightUnit.Kilo: return GramToKilo(conversionAmount);
                case WeightUnit.Miligram: return GramToMiligram(conversionAmount);
                case WeightUnit.Pound: return GramToPound(conversionAmount);
                case WeightUnit.Ounce: return GramToOunce(conversionAmount);
                default: return conversionAmount;

            }
        }
        #endregion

        #region Miligram Converters
        private static decimal MiligramToKilo(decimal miligram)
        {
            return miligram * (1000 ^ 2);
        }

        private static decimal MiligramToGram(decimal miligram)
        {
            return miligram * 1000;
        }

        private static decimal MiligramToPound(decimal miligram)
        {
            return KiloToPound(MiligramToKilo(miligram));
        }
        private static decimal MiligramToOunce(decimal miligram)
        {
            return KiloToOunce(MiligramToKilo(miligram));
        }
        private static decimal ConvertFromMiligram(WeightUnit toUnit, decimal conversionAmount)
        {
            switch (toUnit)
            {
                case WeightUnit.Kilo: return MiligramToKilo(conversionAmount);
                case WeightUnit.Gram: return MiligramToGram(conversionAmount);
                case WeightUnit.Pound: return MiligramToPound(conversionAmount);
                case WeightUnit.Ounce: return MiligramToOunce(conversionAmount);
                default: return conversionAmount;

            }
        }
        #endregion

        #region Pound Converters
        private static decimal PoundToKilo(decimal pound)
        {
            return pound / 2.205m;
        }

        private static decimal PoundToGram(decimal pound)
        {
            return KiloToGram(PoundToKilo(pound));
        }

        private static decimal PoundToMiligram(decimal pound)
        {
            return KiloToMiligram(PoundToKilo(pound));
        }
        private static decimal PoundToOunce(decimal pound)
        {
            return KiloToMiligram(PoundToKilo(pound));
        }
        private static decimal ConvertFromPound(WeightUnit toUnit, decimal conversionAmount)
        {
            switch (toUnit)
            {
                case WeightUnit.Kilo: return PoundToKilo(conversionAmount);
                case WeightUnit.Gram: return PoundToGram(conversionAmount);
                case WeightUnit.Miligram: return PoundToMiligram(conversionAmount);
                case WeightUnit.Ounce: return PoundToOunce(conversionAmount);
                default: return conversionAmount;

            }
        }
        #endregion

        #region Ounce Converters
        private static decimal OunceToKilo(decimal ounce)
        {
            return ounce / 35.274m;
        }

        private static decimal OunceToGram(decimal ounce)
        {
            return KiloToGram(OunceToKilo(ounce));
        }

        private static decimal OunceToMiligram(decimal ounce)
        {
            return KiloToMiligram(OunceToKilo(ounce));
        }
        private static decimal OunceToPound(decimal ounce)
        {
            return KiloToPound(OunceToKilo(ounce));
        }
        private static decimal ConvertFromOunce(WeightUnit toUnit, decimal conversionAmount)
        {
            switch (toUnit)
            {
                case WeightUnit.Kilo: return OunceToKilo(conversionAmount);
                case WeightUnit.Gram: return OunceToGram(conversionAmount);
                case WeightUnit.Miligram: return OunceToMiligram(conversionAmount);
                case WeightUnit.Pound: return OunceToPound(conversionAmount);
                default: return conversionAmount;

            }
        }
        #endregion

        #region converter 
        /// <summary>
        /// Convert weights
        /// </summary>
        /// <param name="fromUnit"></param>
        /// <param name="toUnit"></param>
        /// <param name="conversionAmount"></param>
        /// <returns></returns>
        public static decimal Convert(WeightUnit fromUnit, WeightUnit toUnit, decimal conversionAmount)
        {
            switch (fromUnit)
            {
                case WeightUnit.Kilo: return ConvertFromKilo(toUnit, conversionAmount);
                case WeightUnit.Gram: return ConvertFromGram(toUnit, conversionAmount);
                case WeightUnit.Miligram: return ConvertFromMiligram(toUnit, conversionAmount);
                case WeightUnit.Pound: return ConvertFromPound(toUnit, conversionAmount);
                case WeightUnit.Ounce: return ConvertFromOunce(toUnit, conversionAmount);
                default: return conversionAmount;
            }
        }
        #endregion
    }
}
