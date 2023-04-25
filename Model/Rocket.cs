using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    public class Rocket
    {
        public Rocket()
        {
            inputParams_ = new InputMainParams();
            firstRocketStage_ = new FirstRocketStage();
            secondRocketStage_ = new SecondRocketStage();
        }

        public void SetParams(Dictionary<string, double> iPParams, Dictionary<string, double> fRTParams, Dictionary<string, double> sRSParams)
        {
            inputParams_.SetParams(iPParams);
            firstRocketStage_.SetParams(fRTParams);
            secondRocketStage_.SetParams(sRSParams);
        }

        public void Calculation()
        {
            MainCalculation.DoWeightAnalysis(firstRocketStage_, secondRocketStage_, inputParams_, array1_, array2_);
        }

        public string Get()
        {
            return Convert.ToString(array1_[3, 2]);
        }

        private InputMainParams inputParams_;
        private FirstRocketStage firstRocketStage_;
        private SecondRocketStage secondRocketStage_;
        private double[,] array1_ = new double[5, 3];
        private double[,] array2_ = new double[5, 3];
    }
}
