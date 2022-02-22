using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    /// <summary>
    /// Класс с параметрами первой ступени
    /// </summary>
    class FirstRocketStage : iInputRocketStageParams
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
        }
        public override double mu_Sum(double G01)
        {
            return this.muHo + this.muSt + this.muOu / G01 + this.muSu / G01;
        }
        public override double Muk(double lambda, double G01, double nu, double t)
        {
            return ((1 + muPer) * lambda + mu_Sum(G01) + GammaDU / nu) * (1 - A(t)) + A(t);
        }
    }
}
