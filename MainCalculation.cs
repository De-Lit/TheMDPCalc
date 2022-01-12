using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    class MainCalculation
    {
        
        static public double[,] DoWeightAnalysis(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, int t, double nu1, double nu2)
        {

            int i = 0;
            int j = 0;
            double[,] array1 = new double[5, 3];
            double[,] array2 = new double[5, 3];
            foreach (double lambda in new[] { 0.1, 0.15, 0.2, 0.25, 0.3 })
            {
                foreach (double G01 in new[] { 99e3, 99e3 + (100e3 - 99e3) / 2, 100e3 })
                {
                    array1[i, j] = firstRocketStage.Muk(lambda, G01, nu1, t);
                    array2[i, j] = secondRocketStage.Muk(lambda, G01, nu2, t);
                    j += 1;
                }
                i += 1; j = 0;
            }
            return array1;
        }
    }
}
