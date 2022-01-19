using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    /// <summary>
    /// Класс с параметрами второй ступени
    /// </summary>
    class SecondRocketStage : InputRocketStageParams
    {
        /// <summary>
        /// Масса головной части
        /// </summary>
        public double Ggch { get; set; }
        /// <summary>
        /// Относительный вес приборного отсека
        /// </summary>
        public double muPo { get; set; }
        public SecondRocketStage(double[] Params)
        {
            Jg = Params[0];
            Jo = Params[1];
            K0 = Params[2];
            aa = Params[3];
            muHo = Params[4];
            muOu = Params[5];
            muSu = Params[6];
            muPo = Params[7];
            aSpz = Params[8];
            aTost = Params[9];
            kPr = Params[10];
            PmaxO = Params[11];
            PmaxG = Params[12];
            F = Params[13];
            Cp = Params[14];
            C0 = Params[15];
            GammaDU = Params[16];
            Ggch = Params[17] * 1.55f;
        }
        public override double mu_Sum(double G01)
        {
            return this.muHo + this.muPo + this.muOu / G01 + this.muSu / G01;
        }
        public override double Muk(double lambda, double G01, double nu, double t)
        {
            return (Ggch / G01 / lambda + mu_Sum(G01) + GammaDU / nu) * (1 - A(t)) + A(t);
        }
    }
}
