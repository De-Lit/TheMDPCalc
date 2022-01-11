using System;
using System.Collections.Generic;
using System.Text;

namespace Расчет_ОПП
{
    public class InputMainParams
    {
        public double L; //Дальность полета ракеты
        public double G0; //Масса полезного груза
        public double SpGr; //Удельный вес материала оболочки бака (кг/дм^3)
        public double nu1; //Стартовая нагрузка на тягу первй ступени
        public double nu2; //Стартовая нагрузка на тягу второй ступени
        public double dm1; //Начало интервала поиска конечной массы
        public double dm2; //Конец интервала поиска конечной массы

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
