using System.Collections.Generic;
using System.Collections.ObjectModel;
using ExperimentalProbability.Contracts.Properties.Resources.Numbers;

namespace ExperimentalProbability.Contracts.Utilities
{
    public static class NumberTranslater
    {
        public static readonly ReadOnlyDictionary<int, string> NumberToWord = new ReadOnlyDictionary<int, string>(
            new Dictionary<int, string>()
            {
                { 0, Resources.Zero },
                { 1, Resources.One },
                { 2, Resources.Two },
                { 3, Resources.Three },
                { 4, Resources.Four },
                { 5, Resources.Five },
                { 6, Resources.Six },
                { 7, Resources.Seven },
                { 8, Resources.Eight },
                { 9, Resources.Nine },
                { 10, Resources.Ten },
                { 11, Resources.Eleven },
                { 12, Resources.Twelve },
                { 13, Resources.Thirteen },
                { 14, Resources.Fourteen },
                { 15, Resources.Fifteen },
                { 16, Resources.Sixteen },
                { 17, Resources.Seventeen },
                { 18, Resources.Eighteen },
                { 19, Resources.Nineteen },
                { 20, Resources.Twenty },
                { 21, JoinTwoWords(Resources.Twenty, Resources.One) },
                { 22, JoinTwoWords(Resources.Twenty, Resources.Two) },
                { 23, JoinTwoWords(Resources.Twenty, Resources.Three) },
                { 24, JoinTwoWords(Resources.Twenty, Resources.Four) },
                { 25, JoinTwoWords(Resources.Twenty, Resources.Five) },
                { 26, JoinTwoWords(Resources.Twenty, Resources.Six) },
                { 27, JoinTwoWords(Resources.Twenty, Resources.Seven) },
                { 28, JoinTwoWords(Resources.Twenty, Resources.Eight) },
                { 29, JoinTwoWords(Resources.Twenty, Resources.Nine) },
                { 30, Resources.Thirty },
                { 31, JoinTwoWords(Resources.Thirty, Resources.One) },
                { 32, JoinTwoWords(Resources.Thirty, Resources.Two) },
                { 33, JoinTwoWords(Resources.Thirty, Resources.Three) },
                { 34, JoinTwoWords(Resources.Thirty, Resources.Four) },
                { 35, JoinTwoWords(Resources.Thirty, Resources.Five) },
                { 36, JoinTwoWords(Resources.Thirty, Resources.Six) },
                { 37, JoinTwoWords(Resources.Thirty, Resources.Seven) },
                { 38, JoinTwoWords(Resources.Thirty, Resources.Eight) },
                { 39, JoinTwoWords(Resources.Thirty, Resources.Nine) },
                { 40, Resources.Fourty },
                { 41, JoinTwoWords(Resources.Fourty, Resources.One) },
                { 42, JoinTwoWords(Resources.Fourty, Resources.Two) },
                { 43, JoinTwoWords(Resources.Fourty, Resources.Three) },
                { 44, JoinTwoWords(Resources.Fourty, Resources.Four) },
                { 45, JoinTwoWords(Resources.Fourty, Resources.Five) },
                { 46, JoinTwoWords(Resources.Fourty, Resources.Six) },
                { 47, JoinTwoWords(Resources.Fourty, Resources.Seven) },
                { 48, JoinTwoWords(Resources.Fourty, Resources.Eight) },
                { 49, JoinTwoWords(Resources.Fourty, Resources.Nine) },
                { 50, Resources.Fifty },
                { 51, JoinTwoWords(Resources.Fifty, Resources.One) },
                { 52, JoinTwoWords(Resources.Fifty, Resources.Two) },
                { 53, JoinTwoWords(Resources.Fifty, Resources.Three) },
                { 54, JoinTwoWords(Resources.Fifty, Resources.Four) },
                { 55, JoinTwoWords(Resources.Fifty, Resources.Five) },
                { 56, JoinTwoWords(Resources.Fifty, Resources.Six) },
                { 57, JoinTwoWords(Resources.Fifty, Resources.Seven) },
                { 58, JoinTwoWords(Resources.Fifty, Resources.Eight) },
                { 59, JoinTwoWords(Resources.Fifty, Resources.Nine) },
                { 60, Resources.Sixty },
                { 61, JoinTwoWords(Resources.Sixty, Resources.One) },
                { 62, JoinTwoWords(Resources.Sixty, Resources.Two) },
                { 63, JoinTwoWords(Resources.Sixty, Resources.Three) },
                { 64, JoinTwoWords(Resources.Sixty, Resources.Four) },
                { 65, JoinTwoWords(Resources.Sixty, Resources.Five) },
                { 66, JoinTwoWords(Resources.Sixty, Resources.Six) },
                { 67, JoinTwoWords(Resources.Sixty, Resources.Seven) },
                { 68, JoinTwoWords(Resources.Sixty, Resources.Eight) },
                { 69, JoinTwoWords(Resources.Sixty, Resources.Nine) },
                { 70, Resources.Seventy },
                { 71, JoinTwoWords(Resources.Seventy, Resources.One) },
                { 72, JoinTwoWords(Resources.Seventy, Resources.Two) },
                { 73, JoinTwoWords(Resources.Seventy, Resources.Three) },
                { 74, JoinTwoWords(Resources.Seventy, Resources.Four) },
                { 75, JoinTwoWords(Resources.Seventy, Resources.Five) },
                { 76, JoinTwoWords(Resources.Seventy, Resources.Six) },
                { 77, JoinTwoWords(Resources.Seventy, Resources.Seven) },
                { 78, JoinTwoWords(Resources.Seventy, Resources.Eight) },
                { 79, JoinTwoWords(Resources.Seventy, Resources.Nine) },
                { 80, Resources.Eighty },
                { 81, JoinTwoWords(Resources.Eighty, Resources.One) },
                { 82, JoinTwoWords(Resources.Eighty, Resources.Two) },
                { 83, JoinTwoWords(Resources.Eighty, Resources.Three) },
                { 84, JoinTwoWords(Resources.Eighty, Resources.Four) },
                { 85, JoinTwoWords(Resources.Eighty, Resources.Five) },
                { 86, JoinTwoWords(Resources.Eighty, Resources.Six) },
                { 87, JoinTwoWords(Resources.Eighty, Resources.Seven) },
                { 88, JoinTwoWords(Resources.Eighty, Resources.Eight) },
                { 89, JoinTwoWords(Resources.Eighty, Resources.Nine) },
                { 90, Resources.Ninety },
                { 91, JoinTwoWords(Resources.Ninety, Resources.One) },
                { 92, JoinTwoWords(Resources.Ninety, Resources.Two) },
                { 93, JoinTwoWords(Resources.Ninety, Resources.Three) },
                { 94, JoinTwoWords(Resources.Ninety, Resources.Four) },
                { 95, JoinTwoWords(Resources.Ninety, Resources.Five) },
                { 96, JoinTwoWords(Resources.Ninety, Resources.Six) },
                { 97, JoinTwoWords(Resources.Ninety, Resources.Seven) },
                { 98, JoinTwoWords(Resources.Ninety, Resources.Eight) },
                { 99, JoinTwoWords(Resources.Ninety, Resources.Nine) },
                { 100, Resources.Hundred },
            });

        public static readonly ReadOnlyDictionary<string, int> WordToNumber = new ReadOnlyDictionary<string, int>(
           new Dictionary<string, int>()
           {
                { Resources.Zero, 0 },
                { Resources.One, 1 },
                { Resources.Two, 2 },
                { Resources.Three, 3 },
                { Resources.Four, 4 },
                { Resources.Five, 5 },
                { Resources.Six, 6 },
                { Resources.Seven, 7 },
                { Resources.Eight, 8 },
                { Resources.Nine, 9 },
                { Resources.Ten, 10 },
                { Resources.Eleven, 11 },
                { Resources.Twelve, 12 },
                { Resources.Thirteen, 13 },
                { Resources.Fourteen, 14 },
                { Resources.Fifteen, 15 },
                { Resources.Sixteen, 16 },
                { Resources.Seventeen, 17 },
                { Resources.Eighteen, 18 },
                { Resources.Nineteen, 19 },
                { Resources.Twenty, 20 },
                { JoinTwoWords(Resources.Twenty, Resources.One), 21 },
                { JoinTwoWords(Resources.Twenty, Resources.Two), 22 },
                { JoinTwoWords(Resources.Twenty, Resources.Three), 23 },
                { JoinTwoWords(Resources.Twenty, Resources.Four), 24 },
                { JoinTwoWords(Resources.Twenty, Resources.Five), 25 },
                { JoinTwoWords(Resources.Twenty, Resources.Six), 26 },
                { JoinTwoWords(Resources.Twenty, Resources.Seven), 27 },
                { JoinTwoWords(Resources.Twenty, Resources.Eight), 28 },
                { JoinTwoWords(Resources.Twenty, Resources.Nine), 29 },
                { Resources.Thirty, 30 },
                { JoinTwoWords(Resources.Thirty, Resources.One), 31 },
                { JoinTwoWords(Resources.Thirty, Resources.Two), 32 },
                { JoinTwoWords(Resources.Thirty, Resources.Three), 33 },
                { JoinTwoWords(Resources.Thirty, Resources.Four), 34 },
                { JoinTwoWords(Resources.Thirty, Resources.Five), 35 },
                { JoinTwoWords(Resources.Thirty, Resources.Six), 36 },
                { JoinTwoWords(Resources.Thirty, Resources.Seven), 37 },
                { JoinTwoWords(Resources.Thirty, Resources.Eight), 38 },
                { JoinTwoWords(Resources.Thirty, Resources.Nine), 39 },
                { Resources.Fourty, 40 },
                { JoinTwoWords(Resources.Fourty, Resources.One), 41 },
                { JoinTwoWords(Resources.Fourty, Resources.Two), 42 },
                { JoinTwoWords(Resources.Fourty, Resources.Three), 43 },
                { JoinTwoWords(Resources.Fourty, Resources.Four), 44 },
                { JoinTwoWords(Resources.Fourty, Resources.Five), 45 },
                { JoinTwoWords(Resources.Fourty, Resources.Six), 46 },
                { JoinTwoWords(Resources.Fourty, Resources.Seven), 47 },
                { JoinTwoWords(Resources.Fourty, Resources.Eight), 48 },
                { JoinTwoWords(Resources.Fourty, Resources.Nine), 49 },
                { Resources.Fifty, 50 },
                { JoinTwoWords(Resources.Fifty, Resources.One), 51 },
                { JoinTwoWords(Resources.Fifty, Resources.Two), 52 },
                { JoinTwoWords(Resources.Fifty, Resources.Three), 53 },
                { JoinTwoWords(Resources.Fifty, Resources.Four), 54 },
                { JoinTwoWords(Resources.Fifty, Resources.Five), 55 },
                { JoinTwoWords(Resources.Fifty, Resources.Six), 56 },
                { JoinTwoWords(Resources.Fifty, Resources.Seven), 57 },
                { JoinTwoWords(Resources.Fifty, Resources.Eight), 58 },
                { JoinTwoWords(Resources.Fifty, Resources.Nine), 59 },
                { Resources.Sixty, 60 },
                { JoinTwoWords(Resources.Sixty, Resources.One), 61 },
                { JoinTwoWords(Resources.Sixty, Resources.Two), 62 },
                { JoinTwoWords(Resources.Sixty, Resources.Three), 63 },
                { JoinTwoWords(Resources.Sixty, Resources.Four), 64 },
                { JoinTwoWords(Resources.Sixty, Resources.Five), 65 },
                { JoinTwoWords(Resources.Sixty, Resources.Six), 66 },
                { JoinTwoWords(Resources.Sixty, Resources.Seven), 67 },
                { JoinTwoWords(Resources.Sixty, Resources.Eight), 68 },
                { JoinTwoWords(Resources.Sixty, Resources.Nine), 69 },
                { Resources.Seventy, 70 },
                { JoinTwoWords(Resources.Seventy, Resources.One), 71 },
                { JoinTwoWords(Resources.Seventy, Resources.Two), 72 },
                { JoinTwoWords(Resources.Seventy, Resources.Three), 73 },
                { JoinTwoWords(Resources.Seventy, Resources.Four), 74 },
                { JoinTwoWords(Resources.Seventy, Resources.Five), 75 },
                { JoinTwoWords(Resources.Seventy, Resources.Six), 76 },
                { JoinTwoWords(Resources.Seventy, Resources.Seven), 77 },
                { JoinTwoWords(Resources.Seventy, Resources.Eight), 78 },
                { JoinTwoWords(Resources.Seventy, Resources.Nine), 79 },
                { Resources.Eighty, 80 },
                { JoinTwoWords(Resources.Eighty, Resources.One), 81 },
                { JoinTwoWords(Resources.Eighty, Resources.Two), 82 },
                { JoinTwoWords(Resources.Eighty, Resources.Three), 83 },
                { JoinTwoWords(Resources.Eighty, Resources.Four), 84 },
                { JoinTwoWords(Resources.Eighty, Resources.Five), 85 },
                { JoinTwoWords(Resources.Eighty, Resources.Six), 86 },
                { JoinTwoWords(Resources.Eighty, Resources.Seven), 87 },
                { JoinTwoWords(Resources.Eighty, Resources.Eight), 88 },
                { JoinTwoWords(Resources.Eighty, Resources.Nine), 89 },
                { Resources.Ninety, 90 },
                { JoinTwoWords(Resources.Ninety, Resources.One), 91 },
                { JoinTwoWords(Resources.Ninety, Resources.Two), 92 },
                { JoinTwoWords(Resources.Ninety, Resources.Three), 93 },
                { JoinTwoWords(Resources.Ninety, Resources.Four), 94 },
                { JoinTwoWords(Resources.Ninety, Resources.Five), 95 },
                { JoinTwoWords(Resources.Ninety, Resources.Six), 96 },
                { JoinTwoWords(Resources.Ninety, Resources.Seven), 97 },
                { JoinTwoWords(Resources.Ninety, Resources.Eight), 98 },
                { JoinTwoWords(Resources.Ninety, Resources.Nine), 99 },
                { Resources.Hundred, 100 },
           });

        public static readonly ReadOnlyDictionary<int, string> NumberToPosition = new ReadOnlyDictionary<int, string>(
            new Dictionary<int, string>()
            {
                { 0, Resources.First },
                { 1, Resources.Second },
                { 2, Resources.Third },
                { 3, Resources.Fourth },
                { 4, Resources.Fifth },
                { 5, Resources.Sixth },
                { 6, Resources.Seventh },
                { 7, Resources.Eighth },
                { 8, Resources.Ninth },
                { 9, Resources.Tenth },
            });

        private static string JoinTwoWords(string firstWord, string secondWord)
        {
            return string.Concat(firstWord, ' ', secondWord);
        }
    }
}
