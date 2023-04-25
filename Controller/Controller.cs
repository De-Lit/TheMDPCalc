using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    public class Controller
    {
        public Controller(Rocket rocket)
        {
            this.rocket_ = rocket;
        }

        public string Calculate(Dictionary<string, double> iPParams, Dictionary<string, double> fRTParams, Dictionary<string, double> sRSParams)
        {
            rocket_.SetParams(iPParams, fRTParams, sRSParams);
            rocket_.Calculation();
            return rocket_.Get();
        }

        private Rocket rocket_;
    }
}
