using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Расчет_ОПП
{
    /// <summary>
    /// Абстрактный класс с параметрами, общими для обеех ступеней
    /// </summary>
    public abstract class iInputRocketStageParams
    {
        /// <summary>
        /// Удельный вес материала оболочки бака (кг/дм^3)
        /// </summary>
        public double SpGr = 2.64;
        /// <summary>
        /// Плотность горючего
        /// </summary>
        public double Jg { get; set; }
        /// <summary>
        /// Плотность окислителя
        /// </summary>
        public double Jo { get; set; }
        /// <summary>
        /// Стехиометрическое соотношение КРТ
        /// </summary>
        public double K0 { get; set; }
        /// <summary>
        /// Коэфициент избытка окислителя
        /// </summary>
        public double aa { get; set; }
        /// <summary>
        /// Относительный вес хвостового отсека
        /// </summary>

        public double muHo { get; set; }
        /// <summary>
        /// Относительный вес органов управления
        /// </summary>
        public double muOu { get; set; }
        /// <summary>
        /// Масса ситемы управления
        /// </summary>
        public double muSu { get; set; }
        /// <summary>
        /// Относительный вес системы подачи топлива
        /// </summary>
        public double aSpz { get; set; }
        /// <summary>
        /// Относительный вес остатков топлива
        /// </summary>
        public double aTost { get; set; }
        /// <summary>
        /// Коэффициент, учитывающий расход прочих компонентов
        /// </summary>
        public double kPr { get; set; }
        /// <summary>
        /// Давление в баке окислителя
        /// </summary>
        public double PmaxO { get; set; }
        /// <summary>
        /// Давление в баке горючего
        /// </summary>
        public double PmaxG { get; set; }
        /// <summary>
        /// Запас прочности
        /// </summary>
        public double F { get; set; }
        /// <summary>
        /// Эффективная скорость истечения газа в пустоте
        /// </summary>
        public double Cp { get; set; }
        /// <summary>
        /// Эффективная скорость истечения газа на поверхности Земли
        /// </summary>
        public double C0 { get; set; }
        /// <summary>
        /// Относительный вес двигательной установки блока ступени
        /// </summary>
        public double GammaDU { get; set; }

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
}