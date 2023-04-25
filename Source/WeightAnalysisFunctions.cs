using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    public static class WeightAnalysisFunctions
    {
        private static double sigma(iInputRocketStageParams rocketStage, double t)
        {
            int k = 0;
            double[] SigmaV = new double[] { 35.6901, 32.6309, 19.8845, 13.2563, 9.8563, 7.75 };
            double[] temperature = new double[] { 20, 100, 200, 300, 400, 500 };
            double[] SpStr = new double[6];
            foreach (double el in SigmaV)
            {
                SpStr[k] = rocketStage.SpGr / el;
                k += 1;
            }
            alglib.spline1dinterpolant s;
            alglib.spline1dbuildcubic(temperature, SpStr, out s);
            return alglib.spline1dcalc(s, t);
        }
        private static double nuK(iInputRocketStageParams rocketStage) => rocketStage.K0 * rocketStage.aa;
        private static double nuV(iInputRocketStageParams rocketStage) => nuK(rocketStage) * rocketStage.Jg / rocketStage.Jo;
        private static double Gamma_og(iInputRocketStageParams rocketStage) => (1 + nuK(rocketStage)) / (1 / rocketStage.Jg + nuK(rocketStage) / rocketStage.Jo);
        private static double aSp(iInputRocketStageParams rocketStage) => rocketStage.aSpz / Gamma_og(rocketStage);
        private static double aTo(iInputRocketStageParams rocketStage, double t) => 3.45f * rocketStage.F * (rocketStage.PmaxO * sigma(rocketStage, t) * nuV(rocketStage) / (1 + nuV(rocketStage)) + rocketStage.PmaxG * sigma(rocketStage, t) * nuV(rocketStage) / (1 + nuV(rocketStage))) * 1e-2 / Gamma_og(rocketStage);
        private static double aSum(iInputRocketStageParams rocketStage, double t) => aTo(rocketStage, t) + aSp(rocketStage) + rocketStage.aTost;
        private static double A(iInputRocketStageParams rocketStage, double t) => aSum(rocketStage, t) / (1 + aSum(rocketStage, t) + rocketStage.kPr);
        public static double Muk(double lambda, double G01, FirstRocketStage firstRocketStage, double t)
        {
            double mu_Sum(double G01) => firstRocketStage.muHo + firstRocketStage.muSt + firstRocketStage.muOu / G01 + firstRocketStage.muSu / G01;
            return ((1 + firstRocketStage.muPer) * lambda + mu_Sum(G01) + firstRocketStage.GammaDU / firstRocketStage.nu) * (1 - A(firstRocketStage, t)) + A(firstRocketStage, t);
        }
        public static double Muk(double lambda, double G01, SecondRocketStage secondRocketStage, double t)
        {
            double mu_Sum(double G01) => secondRocketStage.muHo + secondRocketStage.muOu / G01 + secondRocketStage.muSu / G01 + secondRocketStage.muPo;
            return (secondRocketStage.Ggch / G01 / lambda + mu_Sum(G01) + secondRocketStage.GammaDU / secondRocketStage.nu) * (1 - A(secondRocketStage, t)) + A(secondRocketStage, t);
        }
    }
}
