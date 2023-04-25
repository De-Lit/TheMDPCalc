using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    /// <summary>
    /// Класс с параметрами второй ступени
    /// </summary>
    public class SecondRocketStage : iInputRocketStageParams
    {
        public SecondRocketStage() { }
        /// <summary>
        /// Масса головной части
        /// </summary>
        public double Ggch { get; set; }
        /// <summary>
        /// Относительный вес приборного отсека
        /// </summary>
        public double muPo { get; set; }
        public void SetParams(Dictionary<string, double> Params)
        {
            Jg = Params["Jg"];
            Jo = Params["Jo"];
            K0 = Params["K0"];
            aa = Params["aa"];
            muHo = Params["muHo"];
            muOu = Params["muOu"];
            muSu = Params["muSu"];
            muPo = Params["muPo"];
            aSpz = Params["aSpz"];
            aTost = Params["aTost"];
            kPr = Params["kPr"];
            PmaxO = Params["PmaxO"];
            PmaxG = Params["PmaxG"];
            F = Params["F"];
            Cp = Params["Cp"];
            C0 = Params["C0"];
            GammaDU = Params["GammaDU"];
            Ggch = Params["G0"] * 1.55f;
            nu = Params["nu2"];
        }
    }
}
