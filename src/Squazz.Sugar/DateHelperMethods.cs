using System;

namespace Squazz.Sugar
{
    public static class DateHelperMethods
    {
        public static bool DoesDateRangesOverlap(DateTime startRangeA, DateTime endRangeA, DateTime startRangeB, DateTime endRangeB)
        {
            // Based on logic from this StackOverflow answer: https://stackoverflow.com/a/325964

            return startRangeA <= endRangeB
                   && endRangeA >= startRangeB;
        }

        public static bool DoesDateRangesOverlap(DateTimeOffset startRangeA, DateTimeOffset endRangeA, DateTimeOffset startRangeB, DateTimeOffset endRangeB)
        {
            // Based on logic from this StackOverflow answer: https://stackoverflow.com/a/325964

            return startRangeA <= endRangeB
                   && endRangeA >= startRangeB;
        }
    }
}
