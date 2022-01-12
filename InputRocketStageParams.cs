using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Расчет_ОПП
{
    public abstract class InputRocketStageParams //Класс с параметрами, общими для обеех ступеней
    {
        public double SpGr = 2.64; //Удельный вес материала оболочки бака (кг/дм^3)

        public double Jg; //Плотность горючего
        public double Jo; //Плотность окислителя
        public double K0; //Стехиометрическое соотношение КРТ
        public double aa; //Коэфициент избытка окислителя

        public double muHo; //Относительный вес хвостового отсека
        public double muOu; //Относительный вес органов управления
        public double muSu; //Масса ситемы управления
        

        public double aSpz; //Относительный вес системы подачи топлива
        public double aTost; //Относительный вес остатков топлива

        public double kPr; //Коэффициент, учитывающий расход прочих компонентов
        public double PmaxO; //Давление в баке окислителя
        public double PmaxG; //Давление в баке горючего
        public double F; //Запас прочности
        public double Cp; //Эффективная скорость истечения газа в пустоте
        public double C0; //Эффективная скорость истечения газа на поверхности Земли
        public double GammaDU; //Относительный вес двигательной установки блока ступени

        double sigma(double t)
        {
            int k = 0;
            double[] SigmaV = new double[] { 35.6901, 32.6309, 19.8845, 13.2563, 9.8563, 7.75 };
            double[] temperature = new double[] { 20, 100, 200, 300, 400, 500 };
            double[] SpStr = new double[6];
            foreach (double el in SigmaV)
            {
                SpStr[k] = this.SpGr / el;
                k += 1;
            }
            alglib.spline1dinterpolant s;
            alglib.spline1dbuildcubic(temperature, SpStr, out s);
            return alglib.spline1dcalc(s, t);
        }
        private double nuK() { return this.K0 * this.aa; }
        private double nuV() { return nuK() * this.Jg / this.Jo; }
        private double Gamma_og() { return (1 + nuK()) / (1 / this.Jg + nuK() / this.Jo); }
        private double aSp() { return this.aSpz / Gamma_og(); }
        private double aTo(double t) { return 3.45f * this.F * (this.PmaxO * sigma(t) * nuV() / (1 + nuV()) + this.PmaxG * sigma(t) * nuV() / (1 + nuV())) * 1e-2 / Gamma_og(); }
        private double aSum(double t) { return aTo(t) + aSp() + this.aTost; }
        public double A(double t) { return aSum(t) / (1 + aSum(t) + this.kPr); }
        public abstract double mu_Sum(double G01);
        public abstract double Muk(double lambda, double G01, double nu, double t);
    }
    public class FirstRocketStage : InputRocketStageParams //Класс с параметрами первой ступени
    {
        public double muSt; //Относительный вес стабилизаторов
        public double muPer; //Относительный вес переходного отсека
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

    public class SecondRocketStage : InputRocketStageParams //Класс с параметрами второй ступени
    {
        public double Ggch; //Масса головной части
        public double muPo; //Относительный вес приборного отсека
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