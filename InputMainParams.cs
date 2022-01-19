using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    public class InputMainParams
    {
        /// <summary>
        /// Дальность полета ракеты
        /// </summary>
        public double L { get; set; }
        /// <summary>
        /// Масса полезного груза
        /// </summary>
        public double G0 { get; set; }
        /// <summary>
        /// Удельный вес материала оболочки бака (кг/дм^3)
        /// </summary>
        public double SpGr { get; set; }
        /// <summary>
        /// Стартовая нагрузка на тягу первй ступени
        /// </summary>
        public double nu1 { get; set; }
        /// <summary>
        /// Стартовая нагрузка на тягу второй ступени
        /// </summary>
        public double nu2 { get; set; }
        /// <summary>
        /// Начало интервала поиска конечной массы
        /// </summary>
        public double dm1 { get; set; }
        /// <summary>
        /// Конец интервала поиска конечной массы
        /// </summary>
        public double dm2 { get; set; }

        public InputMainParams(double[] Params)
        {
            L = Params[0];
            G0 = Params[1];
            SpGr = Params[2];
            nu1 = Params[3];
            nu2 = Params[4];
            dm1 = Params[5];
            dm2 = Params[6];
        }
    }
}
