using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    /// <summary>
    /// Класс с параметрами первой ступени
    /// </summary>
    class FirstRocketStage : InputRocketStageParams
    {
        /// <summary>
        /// Относительный вес стабилизаторов
        /// </summary>
        public double muSt { get; set; }
        /// <summary>
        /// Относительный вес переходного отсека
        /// </summary>
        public double muPer { get; set; }
        public FirstRocketStage(double[] Params)
        {
            Jg = Params[0];
            Jo = Params[1];
            K0 = Params[2];
            aa = Params[3];
            muHo = Params[4];
            muPer = Params[5];
            muOu = Params[6];
            muSu = Params[7];
            muSt = Params[8];
            aSpz = Params[9];
            aTost = Params[10];
            kPr = Params[11];
            PmaxO = Params[12];
            PmaxG = Params[13];
            F = Params[14];
            Cp = Params[15];
            C0 = Params[16];
            GammaDU = Params[17];
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
