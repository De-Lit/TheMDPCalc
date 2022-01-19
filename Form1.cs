using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Functions;


namespace Расчет_ОПП
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int t = 220;
            double[] inputMainParamsArray = new double[] {
                double.Parse(textBox31.Text), double.Parse(textBox37.Text), double.Parse(textBox38.Text),
                double.Parse(textBox39.Text), double.Parse(textBox40.Text), double.Parse(textBox41.Text),
                double.Parse(textBox42.Text)
            };
            InputMainParams inputMainParams = new InputMainParams(inputMainParamsArray);
            double[] firstStageParamsArray = new double[] { 
                double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text),
                double.Parse(textBox4.Text), double.Parse(textBox5.Text), double.Parse(textBox6.Text),
                double.Parse(textBox7.Text), double.Parse(textBox8.Text), double.Parse(textBox9.Text),
                double.Parse(textBox10.Text), double.Parse(textBox11.Text), double.Parse(textBox12.Text),
                double.Parse(textBox13.Text), double.Parse(textBox14.Text), double.Parse(textBox15.Text),
                double.Parse(textBox16.Text), double.Parse(textBox17.Text), double.Parse(textBox18.Text)
            };
            FirstRocketStage firstRocketStage = new FirstRocketStage(firstStageParamsArray);
            double[] secondStageParamsArray = new double[] {
                double.Parse(textBox36.Text), double.Parse(textBox35.Text), double.Parse(textBox34.Text),
                double.Parse(textBox33.Text), double.Parse(textBox32.Text), double.Parse(textBox30.Text),
                double.Parse(textBox29.Text), double.Parse(textBox28.Text), double.Parse(textBox27.Text),
                double.Parse(textBox26.Text), double.Parse(textBox25.Text), double.Parse(textBox24.Text),
                double.Parse(textBox23.Text), double.Parse(textBox22.Text), double.Parse(textBox21.Text),
                double.Parse(textBox20.Text), double.Parse(textBox19.Text), double.Parse(textBox37.Text)
            };
            SecondRocketStage secondRocketStage = new SecondRocketStage(secondStageParamsArray);

            label29.Text = Convert.ToString(MainCalculation.DoWeightAnalysis(firstRocketStage, secondRocketStage, t, inputMainParams.nu1, inputMainParams.nu2)[0, 2]);

        }
        private void CheckInput(KeyPressEventArgs e) //Ограничение ввода в textBox формы
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace, запятая
            {
                e.Handled = true;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox13_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox14_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox15_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox16_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox17_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox36_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox35_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox34_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox33_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox32_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox30_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox29_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox28_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox27_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox26_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox23_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox22_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox21_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox20_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox31_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox37_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox38_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox39_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox40_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox41_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }
        private void textBox42_KeyPress(object sender, KeyPressEventArgs e) { CheckInput(e); }

        private void Form1_Load(object sender, EventArgs e) //Загрузка в textBoxs формы значений из файла xml
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("SafedParams.xml");
            try { textBox1.Text = xDoc.DocumentElement["Jg1"].InnerText; } catch { }
            try { textBox2.Text = xDoc.DocumentElement["Jo1"].InnerText; } catch { }
            try { textBox3.Text = xDoc.DocumentElement["K01"].InnerText; } catch { }
            try { textBox4.Text = xDoc.DocumentElement["aa1"].InnerText; } catch { }
            try { textBox5.Text = xDoc.DocumentElement["mu_xo1"].InnerText; } catch { }
            try { textBox6.Text = xDoc.DocumentElement["mu_per1"].InnerText; } catch { }
            try { textBox7.Text = xDoc.DocumentElement["mu_ou1"].InnerText; } catch { }
            try { textBox8.Text = xDoc.DocumentElement["mu_su1"].InnerText; } catch { }
            try { textBox9.Text = xDoc.DocumentElement["mu_st"].InnerText; } catch { }
            try { textBox10.Text = xDoc.DocumentElement["a_spz1"].InnerText; } catch { }
            try { textBox11.Text = xDoc.DocumentElement["a_Tost1"].InnerText; } catch { }
            try { textBox12.Text = xDoc.DocumentElement["k_pr1"].InnerText; } catch { }
            try { textBox13.Text = xDoc.DocumentElement["P_maxO1"].InnerText; } catch { }
            try { textBox14.Text = xDoc.DocumentElement["P_maxG1"].InnerText; } catch { }
            try { textBox15.Text = xDoc.DocumentElement["F1"].InnerText; } catch { }
            try { textBox16.Text = xDoc.DocumentElement["Cp1"].InnerText; } catch { }
            try { textBox17.Text = xDoc.DocumentElement["C01"].InnerText; } catch { }
            try { textBox18.Text = xDoc.DocumentElement["Gamma_du1"].InnerText; } catch { }
            
            try { textBox36.Text = xDoc.DocumentElement["Jg2"].InnerText; } catch { }
            try { textBox35.Text = xDoc.DocumentElement["Jo2"].InnerText; } catch { }
            try { textBox34.Text = xDoc.DocumentElement["K02"].InnerText; } catch { }
            try { textBox33.Text = xDoc.DocumentElement["aa2"].InnerText; } catch { }
            try { textBox32.Text = xDoc.DocumentElement["mu_xo2"].InnerText; } catch { }
            try { textBox30.Text = xDoc.DocumentElement["mu_ou2"].InnerText; } catch { }
            try { textBox29.Text = xDoc.DocumentElement["mu_su2"].InnerText; } catch { }
            try { textBox28.Text = xDoc.DocumentElement["mu_po"].InnerText; } catch { }
            try { textBox27.Text = xDoc.DocumentElement["a_spz2"].InnerText; } catch { }
            try { textBox26.Text = xDoc.DocumentElement["a_Tost2"].InnerText; } catch { }
            try { textBox25.Text = xDoc.DocumentElement["k_pr2"].InnerText; } catch { }
            try { textBox24.Text = xDoc.DocumentElement["P_maxO2"].InnerText; } catch { }
            try { textBox23.Text = xDoc.DocumentElement["P_maxG2"].InnerText; } catch { }
            try { textBox22.Text = xDoc.DocumentElement["F2"].InnerText; } catch { }
            try { textBox21.Text = xDoc.DocumentElement["Cp2"].InnerText; } catch { }
            try { textBox20.Text = xDoc.DocumentElement["C02"].InnerText; } catch { }
            try { textBox19.Text = xDoc.DocumentElement["Gamma_du2"].InnerText; } catch { }

            try { textBox39.Text = xDoc.DocumentElement["nu1"].InnerText; } catch { }
            try { textBox40.Text = xDoc.DocumentElement["nu2"].InnerText; } catch { }
            try { textBox37.Text = xDoc.DocumentElement["Ggch"].InnerText; } catch { }
            try { textBox31.Text = xDoc.DocumentElement["L"].InnerText; } catch { }
            try { textBox38.Text = xDoc.DocumentElement["SpGr"].InnerText; } catch { }
            try { textBox41.Text = xDoc.DocumentElement["dm1"].InnerText; } catch { }
            try { textBox42.Text = xDoc.DocumentElement["dm2"].InnerText; } catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //Сохранение значений из textBoxs формы в файл xml
        {
            XDocument doc = new XDocument(new XElement("SafedParams"));

            doc.Root.Add(
                new XElement("Jg1", textBox1.Text),
                new XElement("Jo1", textBox2.Text),
                new XElement("K01", textBox3.Text),
                new XElement("aa1", textBox4.Text),
                new XElement("mu_xo1", textBox5.Text),
                new XElement("mu_per1", textBox6.Text),
                new XElement("mu_ou1", textBox7.Text),
                new XElement("mu_su1", textBox8.Text),
                new XElement("mu_st", textBox9.Text),
                new XElement("a_spz1", textBox10.Text),
                new XElement("a_Tost1", textBox11.Text),
                new XElement("k_pr1", textBox12.Text),
                new XElement("P_maxO1", textBox13.Text),
                new XElement("P_maxG1", textBox14.Text),
                new XElement("F1", textBox15.Text),
                new XElement("Cp1", textBox16.Text),
                new XElement("C01", textBox17.Text),
                new XElement("Gamma_du1", textBox18.Text),
                
                new XElement("Jg2", textBox36.Text),
                new XElement("Jo2", textBox35.Text),
                new XElement("K02", textBox34.Text),
                new XElement("aa2", textBox33.Text),
                new XElement("mu_xo2", textBox32.Text),
                new XElement("mu_ou2", textBox30.Text),
                new XElement("mu_su2", textBox29.Text),
                new XElement("mu_po", textBox28.Text),
                new XElement("a_spz2", textBox27.Text),
                new XElement("a_Tost2", textBox26.Text),
                new XElement("k_pr2", textBox25.Text),
                new XElement("P_maxO2", textBox24.Text),
                new XElement("P_maxG2", textBox23.Text),
                new XElement("F2", textBox22.Text),
                new XElement("Cp2", textBox21.Text),
                new XElement("C02", textBox20.Text),
                new XElement("Gamma_du2", textBox19.Text),

                new XElement("nu1", textBox39.Text),
                new XElement("nu2", textBox40.Text),
                new XElement("Ggch", textBox37.Text),
                new XElement("L", textBox31.Text),
                new XElement("SpGr", textBox38.Text),
                new XElement("dm1", textBox41.Text),
                new XElement("dm2", textBox42.Text)
                );

            doc.Save("SafedParams.xml");
        } 

    }
}
