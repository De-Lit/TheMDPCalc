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

        /// <summary>
        /// Стартовая нагрузка на тягу первй ступени
        /// </summary>
        public double nu { get; set; }
    }
}
