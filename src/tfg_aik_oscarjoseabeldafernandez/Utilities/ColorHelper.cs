using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TFG_AIK_OscarJoseAbeldaFernandez.Utilities
{
    public static class ColorHelper
    {
        public static SolidColorBrush[] defaultColors = {   new SolidColorBrush(Colors.Red),
                                                            new SolidColorBrush(Colors.Yellow),
                                                            new SolidColorBrush(Colors.Blue),
                                                            new SolidColorBrush(Colors.Purple),
                                                            new SolidColorBrush(Colors.Pink),
                                                            new SolidColorBrush(Colors.Orange)};

        public static bool areSimilarColors(SolidColorBrush color1, SolidColorBrush color2, int requieredContrast)
        {
            return (
                        ((int)color1.Color.R <= (int)color2.Color.R + requieredContrast && (int)color1.Color.R >= (int)color2.Color.R - requieredContrast) &&
                        ((int)color1.Color.B <= (int)color2.Color.B + requieredContrast && (int)color1.Color.B >= (int)color2.Color.B - requieredContrast) &&
                        ((int)color1.Color.G <= (int)color2.Color.G + requieredContrast && (int)color1.Color.G >= (int)color2.Color.G - requieredContrast)

                    );
        }

    }
}
