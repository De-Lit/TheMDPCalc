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
        //public double nu1 { get; set; }
        /// <summary>
        /// Стартовая нагрузка на тягу второй ступени
        /// </summary>
        //public double nu2 { get; set; }
        /// <summary>
        /// Начало интервала поиска конечной массы
        /// </summary>
        public double dm1 { get; set; }
        /// <summary>
        /// Конец интервала поиска конечной массы
        /// </summary>
        public double dm2 { get; set; }

        public InputMainParams(Dictionary<string, double> Params)
        {
            L = Params["L"];
            G0 = Params["G0"];
            SpGr = Params["SpGr"];
            //nu1 = Params["nu1"];
            //nu2 = Params["nu2"];
            dm1 = Params["dm1"];
            dm2 = Params["dm2"];
        }
    }
}
