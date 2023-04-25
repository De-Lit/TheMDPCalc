using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    class MainCalculation
    {
        public static void DoWeightAnalysis(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, InputMainParams inputMainParams, double[,] data_1, double[,] data_2)
        {
            int t = 220;
            int i = 0;
            int j = 0;
            foreach (double lambda in new[] { 0.1, 0.15, 0.2, 0.25, 0.3 })
            {
                foreach (double G01 in new[] { inputMainParams.dm1, inputMainParams.dm1 + (inputMainParams.dm2 - inputMainParams.dm1) / 2, inputMainParams.dm2 })
                {
                    data_1[i, j] = WeightAnalysisFunctions.Muk(lambda, G01, firstRocketStage, t);
                    data_2[i, j] = WeightAnalysisFunctions.Muk(lambda, G01, secondRocketStage, t);
                    j += 1;
                }
                i++; j = 0;
            }
        }
    }
}
