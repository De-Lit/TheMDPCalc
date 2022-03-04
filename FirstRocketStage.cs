using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    /// <summary>
    /// Класс с параметрами первой ступени
    /// </summary>
    public class FirstRocketStage : iInputRocketStageParams
    {
        /// <summary>
        /// Относительный вес стабилизаторов
        /// </summary>
        public double muSt { get; set; }
        /// <summary>
        /// Относительный вес переходного отсека
        /// </summary>
        public double muPer { get; set; }
        public FirstRocketStage(Dictionary<string, double> Params)
        {
            Jg = Params["Jg"];
            Jo = Params["Jo"];
            K0 = Params["K0"];
            aa = Params["aa"];
            muHo = Params["muHo"];
            muPer = Params["muPer"];
            muOu = Params["muOu"];
            muSu = Params["muSu"];
            muSt = Params["muSt"];
            aSpz = Params["aSpz"];
            aTost = Params["aTost"];
            kPr = Params["kPr"];
            PmaxO = Params["PmaxO"];
            PmaxG = Params["PmaxO"];
            F = Params["F"];
            Cp = Params["Cp"];
            C0 = Params["C0"];
            GammaDU = Params["GammaDU"];
            nu = Params["nu1"];
        }
    }
}
