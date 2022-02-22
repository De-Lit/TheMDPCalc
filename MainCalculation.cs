using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    class MainCalculation
    {
        
        static public double[,] DoWeightAnalysis(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, InputMainParams inputMainParams)
        {
            int t = 220;
            int i = 0;
            int j = 0;
            double[,] array1 = new double[5, 3];
            double[,] array2 = new double[5, 3];
            foreach (double lambda in new[] { 0.1, 0.15, 0.2, 0.25, 0.3 })
            {
                foreach (double G01 in new[] { inputMainParams.dm1, inputMainParams.dm1 + (inputMainParams.dm2 - inputMainParams.dm1) / 2, inputMainParams.dm2 })
                {
                    array1[i, j] = WeightAnalysisFunctions.Muk(lambda, G01, inputMainParams, firstRocketStage, t);
                    array2[i, j] = WeightAnalysisFunctions.Muk(lambda, G01, inputMainParams, secondRocketStage, t);
                    j += 1;
                }
                i += 1; j = 0;
            }
            return array1;
        }
    }
}
