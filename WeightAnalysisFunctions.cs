using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    public static class WeightAnalysisFunctions
    {
        public static double Muk(double lambda, double G01, InputMainParams inputMainParams, FirstRocketStage firstRocketStage, double t)
        {
            double sigma(double t)
            {
                int k = 0;
                double[] SigmaV = new double[] { 35.6901, 32.6309, 19.8845, 13.2563, 9.8563, 7.75 };
                double[] temperature = new double[] { 20, 100, 200, 300, 400, 500 };
                double[] SpStr = new double[6];
                foreach (double el in SigmaV)
                {
                    SpStr[k] = firstRocketStage.SpGr / el;
                    k += 1;
                }
                alglib.spline1dinterpolant s;
                alglib.spline1dbuildcubic(temperature, SpStr, out s);
                return alglib.spline1dcalc(s, t);
            }
            double nuK() { return firstRocketStage.K0 * firstRocketStage.aa; }
            double nuV() { return nuK() * firstRocketStage.Jg / firstRocketStage.Jo; }
            double Gamma_og() { return (1 + nuK()) / (1 / firstRocketStage.Jg + nuK() / firstRocketStage.Jo); }
            double aSp() { return firstRocketStage.aSpz / Gamma_og(); }
            double aTo(double t) { return 3.45f * firstRocketStage.F * (firstRocketStage.PmaxO * sigma(t) * nuV() / (1 + nuV()) + firstRocketStage.PmaxG * sigma(t) * nuV() / (1 + nuV())) * 1e-2 / Gamma_og(); }
            double aSum(double t) { return aTo(t) + aSp() + firstRocketStage.aTost; }
            double A(double t) { return aSum(t) / (1 + aSum(t) + firstRocketStage.kPr); }
            double mu_Sum(double G01) { return firstRocketStage.muHo + firstRocketStage.muSt + firstRocketStage.muOu / G01 + firstRocketStage.muSu / G01;}
            return ((1 + firstRocketStage.muPer) * lambda + mu_Sum(G01) + firstRocketStage.GammaDU / inputMainParams.nu1) * (1 - A(t)) + A(t);
        }
        public static double Muk(double lambda, double G01, InputMainParams inputMainParams, SecondRocketStage secondRocketStage, double t)
        {
            double sigma(double t)
            {
                int k = 0;
                double[] SigmaV = new double[] { 35.6901, 32.6309, 19.8845, 13.2563, 9.8563, 7.75 };
                double[] temperature = new double[] { 20, 100, 200, 300, 400, 500 };
                double[] SpStr = new double[6];
                foreach (double el in SigmaV)
                {
                    SpStr[k] = secondRocketStage.SpGr / el;
                    k += 1;
                }
                alglib.spline1dinterpolant s;
                alglib.spline1dbuildcubic(temperature, SpStr, out s);
                return alglib.spline1dcalc(s, t);
            }
            double nuK() { return secondRocketStage.K0 * secondRocketStage.aa; }
            double nuV() { return nuK() * secondRocketStage.Jg / secondRocketStage.Jo; }
            double Gamma_og() { return (1 + nuK()) / (1 / secondRocketStage.Jg + nuK() / secondRocketStage.Jo); }
            double aSp() { return secondRocketStage.aSpz / Gamma_og(); }
            double aTo(double t) { return 3.45f * secondRocketStage.F * (secondRocketStage.PmaxO * sigma(t) * nuV() / (1 + nuV()) + secondRocketStage.PmaxG * sigma(t) * nuV() / (1 + nuV())) * 1e-2 / Gamma_og(); }
            double aSum(double t) { return aTo(t) + aSp() + secondRocketStage.aTost; }
            double A(double t) { return aSum(t) / (1 + aSum(t) + secondRocketStage.kPr); }
            double mu_Sum(double G01) { return secondRocketStage.muHo + secondRocketStage.muPo + secondRocketStage.muOu / G01 + secondRocketStage.muSu / G01; }
            return (secondRocketStage.Ggch / G01 / lambda + mu_Sum(G01) + secondRocketStage.GammaDU / inputMainParams.nu2) * (1 - A(t)) + A(t);
        }
    }
}