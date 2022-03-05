using System;
using System.Collections.Generic;
using System.Text;
using RocketFunctions;


namespace Расчет_ОПП
{
    public static class BalisticAnalisisFunctions
    {
        private const double g_0 = 9.81;
        private const double g_sr = 9.5;
        private const double g_sr1 = 9.73;
        private const double g_sr2 = 9.4;
        private const double Rz = 6371e3;
        private static double Pud(iInputRocketStageParams rocketStage) => rocketStage.C0 / g_0;
        private static double T(iInputRocketStageParams rocketStage) => rocketStage.nu * Pud(rocketStage);
        private static double tau_1(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2)
            => T((iInputRocketStageParams)firstRocketStage) * (1 - MuK_1) / (T((iInputRocketStageParams)firstRocketStage) * (1 - MuK_1) + T((iInputRocketStageParams)secondRocketStage) * (1 - MuK_2));
        private static double tau_2(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2)
            => 1 - tau_1(firstRocketStage, secondRocketStage, MuK_1, MuK_2);
        private static double Vk(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => -firstRocketStage.Cp * Math.Log(MuK_1) - secondRocketStage.Cp * Math.Log(MuK_2) - g_sr * Functions.f(Theta) * (T((iInputRocketStageParams)firstRocketStage) * (1 - MuK_1) + T((iInputRocketStageParams)secondRocketStage) * (1 - MuK_2)) - Functions.dV23(firstRocketStage.nu);
        private static double Va(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => -firstRocketStage.Cp * Math.Log(MuK_1) - g_sr1 * Functions.f1(tau_1(firstRocketStage, secondRocketStage, MuK_1, MuK_2), Theta) * T((iInputRocketStageParams)firstRocketStage) * (1 - MuK_1) - Functions.dV23(firstRocketStage.nu);
        private static double Xk_1(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => T((iInputRocketStageParams)firstRocketStage) * (1 - MuK_1) * (firstRocketStage.Cp * Functions.Ax1(MuK_1, Theta) * Functions.Kx1(tau_1(firstRocketStage, secondRocketStage, MuK_1, MuK_2)) - g_sr1 * T((iInputRocketStageParams)firstRocketStage) * (1 - MuK_1) * Functions.Bx1(tau_1(firstRocketStage, secondRocketStage, MuK_1, MuK_2), Theta));

        private static double Xk_2(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => T((iInputRocketStageParams)secondRocketStage) * (1 - MuK_2) * (secondRocketStage.Cp * Functions.Ax2(MuK_2, Theta) + Va(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) * Functions.fx2(tau_2(firstRocketStage, secondRocketStage, MuK_1, MuK_2), Theta) - g_sr2 * T((iInputRocketStageParams)secondRocketStage) * (1 - MuK_2) * Functions.Bx2(tau_2(firstRocketStage, secondRocketStage, MuK_1, MuK_2), Theta));

        private static double Xk(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => Xk_1(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Xk_2(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta);
        private static double Yk_1(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => T((iInputRocketStageParams)firstRocketStage) * (1 - MuK_1) * (firstRocketStage.Cp * Functions.Ay1(MuK_1, Theta) * Functions.Ky1(tau_1(firstRocketStage, secondRocketStage, MuK_1, MuK_2), Theta) - g_sr1 * T((iInputRocketStageParams)firstRocketStage) * (1 - MuK_1) * Functions.By1(tau_1(firstRocketStage, secondRocketStage, MuK_1, MuK_2), Theta));
        private static double Yk_2(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => T((iInputRocketStageParams)secondRocketStage) * (1 - MuK_2) * (secondRocketStage.Cp * Functions.Ay2(MuK_2, Theta) + Va(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) * Functions.fy2(tau_2(firstRocketStage, secondRocketStage, MuK_1, MuK_2), Theta) - g_sr2 * T((iInputRocketStageParams)secondRocketStage) * (1 - MuK_2) * Functions.By2(tau_2(firstRocketStage, secondRocketStage, MuK_1, MuK_2), Theta));
        private static double Yk(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => Yk_1(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Yk_2(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta);
        private static double Xab(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => 2 * (Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Rz) * Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) / g_0 / (Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Rz) * Math.Tan(Theta / 57.296) / (1 - Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) / g_0 / (Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Rz) + Math.Pow(Math.Tan(Theta / 57.296), 2));
        private static double Xbc(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) * Math.Cos(Theta / 57.296) / g_0 * (Math.Sqrt(Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) * Math.Pow(Math.Sin(Theta / 57.296), 2) + 2 * g_0 * Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta)) - Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) * Math.Sin(Theta / 57.296));
        public static double X(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => Xk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Xab(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Xbc(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta);
        public static double Y(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + (Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Rz) * Math.Pow(Math.Sin(Theta / 57.296), 2) / (Math.Sqrt(1 - (2 - Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) / g_0 / (Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Rz)) * Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) / g_0 / (Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Rz) * Math.Pow(Math.Cos(Theta / 57.296), 2)) + 1 - Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) / g_0 / (Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) + Rz));
        public static double Theta(FirstRocketStage firstRocketStage, SecondRocketStage secondRocketStage, double MuK_1, double MuK_2, double Theta)
            => 57.296 * Math.Atan(Math.Sqrt(((Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) * (1 + Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) / Rz) / g_0 / Rz) / 2) * (2 - (2 + Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) / Rz) * (Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) * (1 + Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) / Rz) / g_0 / Rz)) / ((Math.Pow(Vk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta), 2) * (1 + Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) / Rz) / g_0 / Rz) + 2 * Yk(firstRocketStage, secondRocketStage, MuK_1, MuK_2, Theta) / Rz)));
    }
}
