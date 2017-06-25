//#define __A__

using System;
using System.Windows.Forms;
using WinLib;               // using WinLib !!!!!!!!!!!!! 

namespace CalcStress_003
{
    public partial class Form_CalcStress : aForm
    {
        #region Объявление ссылок на контролы (чтоб видны были издаля)

        PictureBox pict_01, pict_02;
        TxtBoxDbl TBox_1, TBox_2, TBox_3;   // для ввода размеров сечения 
        TxtBoxDbl TBox_10, TBox_11;         // для ввода усилия и длины консоли 
        LabelR lbl_TBox_1, lbl_TBox_2, lbl_TBox_3, lbl_TBox_10, lbl_TBox_11;  // Каменты к окнам ввода 
        // GroupBox + RadioButton
        GroupBoxChoice groupBox1;       // создаем ссылку groupBox1 на объект типа GroupBoxChoice 
        RadioButtonChoice radioBtn_CircleRod, radioBtn_CircleTube, radioBtn_RectangleRod, radioBtn_RectangleTube;
        GroupBoxChoice groupBox2;       // создаем ссылку groupBox2 на объект типа GroupBoxChoice 
        RadioButtonChoice radioBtn_Stretch, radioBtn_Bend, radioBtn_Twist, radioBtn_Cut;
        aLabel Result_1, Result_2;      // Окно результатов расчета 
        // Материалы 
        ListBoxSteelChoice listBoxSteel;
        // Строка сообщений внизу винформы 
        StatusStrip sStrip1;
        ToolStripStatusLabel sStrip1Lbl;

        #endregion Объявление ссылок на контролы (чтоб видны были издаля)


            // InitializeDynamicComponent() 
        void InitializeDynamicComponent()
        {
            TxtBoxDbl.TBoxesWdt = 140; // Задание ширины всех TxtBoxDbl в ЭТОЙ программе (default = 100) 

            #region PictureBox1
            //
            // pict_01
            //
            pict_01 = new PictureBox();
            //pict_01.Top = 28;          // т.е. коорд Y == 25
            pict_01.Top = menuStrip1.Bottom + gap;  //msg("pict top = ", pict_01.Top);
            pict_01.Left = gap; // т.е. коорд X == 5
            pict_01.BorderStyle = BorderStyle.FixedSingle;   //pict_01.BorderStyle = BorderStyle.FixedSingle;
            pict_01.Height = 385;
            pict_01.Width  = 385;
            pict_01.Image = CalcStress_003.Properties.Resources.CircleRod;
            pict_01.TabStop = false;
            pict_01.MouseClick += new MouseEventHandler(pict_01_MouseClick);    // = Button RUN
            #endregion  PictureBox1

            // Теперь по порядку установки компонентов на форму - GroupBox1 и RadioButtons к нему 

            #region GroupBox1 и RadioButtons к нему
            //
            // radioBtnCircle (Круг)
            //
            radioBtn_CircleRod = new RadioButtonChoice(null, "Круг", true);
            this.radioBtn_CircleRod.CheckedChanged += new EventHandler(radioBtn_CircleRod_CheckedChanged);

#if __A__       // if exist -  #define __A__
            MessageBox.Show("Height of RadioBtn == " + radioBtn_CircleRod.Height.ToString());
#endif      
            //
            // radioBtnCircleRing (Труба круглая)
            //
            radioBtn_CircleTube = new RadioButtonChoice(radioBtn_CircleRod, "Труба круглая", false);
            this.radioBtn_CircleTube.CheckedChanged += new EventHandler(radioBtn_CircleTube_CheckedChanged);
            //
            // radioBtnRectangle (Прямоугольник)
            //
            radioBtn_RectangleRod = new RadioButtonChoice(radioBtn_CircleTube, "Прямоугольник", false);
            this.radioBtn_RectangleRod.CheckedChanged += new EventHandler(radioBtn_RectangleRod_CheckedChanged);
            //
            // radioBtnRectangleRing (Труба прямоугольная)
            //
            radioBtn_RectangleTube = new RadioButtonChoice(radioBtn_RectangleRod, "Труба прямоугол.", false);
            this.radioBtn_RectangleTube.CheckedChanged += new EventHandler(radioBtn_RectangleTube_CheckedChanged);
            //
            // groupBox1  // GroupBoxChoice
            //
            groupBox1 = new GroupBoxChoice(pict_01, 140, 20 + radioBtn_CircleRod.Height * 4, "Вид профиля");// было 120

            #endregion GroupBox1 и RadioButtons к нему

            #region  PictureBox2
            //
            // pict_02
            //
            pict_02 = new PictureBox();
            pict_02.Top = pict_01.Top;
            pict_02.Left = pict_01.Right + 8 * gap;
            pict_02.BorderStyle = pict_01.BorderStyle;
            pict_02.Height = pict_01.Height;
            pict_02.Width = pict_01.Width;
            pict_02.Image = CalcStress_003.Properties.Resources.ForceStretch;
            pict_02.TabStop = false;
            pict_02.MouseClick += new MouseEventHandler(pict_02_MouseClick);    // = Button RUN
            #endregion  PictureBox2

            // Теперь по порядку установки компонентов на форму - GroupBox2 и RadioButtons к нему 

            #region GroupBox2 и RadioButtons к нему
            
            //
            // radioBtn_Stretch (растяжение)
            //
            radioBtn_Stretch = new RadioButtonChoice(null, "Растяжение", true);
            this.radioBtn_Stretch.CheckedChanged += new EventHandler(radioBtnStretch_CheckedChanged);
            //
            // radioBtn_Bend (изгиб)
            //
            radioBtn_Bend = new RadioButtonChoice(radioBtn_Stretch, "Изгиб", false);
            this.radioBtn_Bend.CheckedChanged += new EventHandler(radioBtnBend_CheckedChanged);
            //
            // radioBtn_Twist (кручение)
            //
            radioBtn_Twist = new RadioButtonChoice(radioBtn_Bend, "Кручение", false);
            this.radioBtn_Twist.CheckedChanged += new EventHandler(radioBtnTwist_CheckedChanged);
            //
            // radioBtn_Cut (срез)
            //
            radioBtn_Cut = new RadioButtonChoice(radioBtn_Twist, "Срез", false);
            this.radioBtn_Cut.CheckedChanged += new EventHandler(radioBtnCut_CheckedChanged);
            //
            // GroupBox2
            //
            groupBox2 = new GroupBoxChoice(pict_02, 130, 20 + radioBtn_Stretch.Height * 4, "Вид нагрузки");

            #endregion GroupBox2 и RadioButtons к нему

            #region TxtBoxDbls and their's labels
            //
            // TBox_1
            //
            TBox_1 = new TxtBoxDbl(groupBox1, Place.right, 10); // т.е. ставится к групбоксу справа с зазором 10 пикс
            TBox_1.name1 = "D, mm";                             // MessageBox.Show("TabIndex = " + TBox_1.TabIndex);
            TBox_1.TxtChanged += new EventHandler(TBox_1_TxtChanged);
            //TBox_1.showErr = Result_1; - нельзя т.к. пока еще Result_1 == null 
            //
            // lbl_TBox_1
            //
            lbl_TBox_1 = new LabelR(TBox_1/*,TBox_1.name1*/); // TBox_1.name1 - уже вписывается автоматом
            //
            // TBox_2
            //
            TBox_2 = new TxtBoxDbl(TBox_1); // т.е. ставиться к TBox_1 снизу
            TBox_2.name1 = "";
            TBox_2.TxtChanged += new EventHandler(TBox_1_TxtChanged);
            //
            // lbl_TBox_2
            //
            lbl_TBox_2 = new LabelR(TBox_2);   //(TBox_2, TBox_2.name1);
            //
            // TBox_3
            //
            TBox_3 = new TxtBoxDbl(TBox_2); // т.е. ставиться к TBox_2 снизу
            TBox_3.name1 = "S, mm";
            TBox_3.TxtChanged += new EventHandler(TBox_1_TxtChanged);
            //
            // lbl_TBox_3
            //
            lbl_TBox_3 = new LabelR(TBox_3);
            //
            // TBox_10
            //
            TBox_10 = new TxtBoxDbl(groupBox2, Place.right, 15);
            TBox_10.name1 = "F, kg";
            TBox_10.TxtChanged += new EventHandler(TBox_10_TxtChanged);
            //
            // lbl_TBox_10
            //
            lbl_TBox_10 = new LabelR(TBox_10);
            lbl_TBox_10.BackColor = System.Drawing.Color.Aquamarine;
            lbl_TBox_10.MouseClick += new MouseEventHandler(lbl_TBox_10_MouseClick);
            //
            // TBox_11
            //
            TBox_11 = new TxtBoxDbl(TBox_10);
            TBox_11.name1 = "L, mm";
            TBox_11.TxtChanged += new EventHandler(TBox_10_TxtChanged);
            //
            // lbl_TBox_11
            //
            lbl_TBox_11 = new LabelR(TBox_11);

            #endregion TxtBoxDbls and their's labels
            
            #region aLabel Result
            //
            // Result_1
            //
            int grpHeight = groupBox1.Height > groupBox2.Height ? groupBox1.Height : groupBox2.Height;

            Result_1 = new aLabel(groupBox1.Left,
                pict_01.Bottom + grpHeight + gap * 2, pict_01.Width, 150);
            Result_1.Font = new System.Drawing.Font("Consolas", 10.0F);
            // после new aLabel т.к. иначе ссылка получается на null
            TBox_1.showErr = Result_1;
            TBox_2.showErr = Result_1;
            TBox_3.showErr = Result_1;
            //
            // Result_2
            //
            Result_2 = new aLabel(groupBox2.Left, Result_1.Top, pict_02.Width, Result_1.Height);
            Result_2.Font = Result_1.Font;
            TBox_10.showErr = Result_2;
            TBox_11.showErr = Result_2;

            #endregion aLabel Result

            #region listBoxSteel and labels
            //
            // listBoxSteel
            //
            listBoxSteel = new ListBoxSteelChoice(Result_1, this.Width); // Result_1 - это контрол под которым ставить листбокс 
            listBoxSteel.SteelChanged += new EventHandler(listBoxSteel_SteelChanged);

            #endregion listBoxSteel and labels

            #region ToolTips and HelpProvider
            //
            // Tip1
            //
            Tip1 = new ToolTip();
            Tip1.InitialDelay = 600;
            Tip1.ToolTipIcon = ToolTipIcon.Info;
            Tip1.ToolTipTitle = "Just Do It !";
            Tip1.SetToolTip(this.pict_01, "Click LEFT button\nto calculate data of profile.");
            Tip1.IsBalloon = true;
            //
            // Tip2
            //
            Tip2 = new ToolTip();
            Tip2.InitialDelay = 600;
            Tip2.ToolTipIcon = ToolTipIcon.Info;
            Tip2.ToolTipTitle = "Just Do It !";
            Tip2.SetToolTip(this.pict_02, "Click LEFT button to calculate stress for preset force.\nClick RIGHT button to calculate MAX force.");
            Tip2.IsBalloon = true;
            //
            // HelpProvider
            //
            hlP1 = new HelpProvider();
            hlP1.SetShowHelp(this, true);
            hlpFile = this.Text + ".chm";
            hlP1.HelpNamespace = hlpFile; //"CalcStress.chm";

            #endregion ToolTips and HelpProvider

            #region StatusStrip
            //
            // StatusStrip
            //
            sStrip1 = new StatusStrip();
            sStrip1.Font = new System.Drawing.Font("Tahoma", 12.0F);
            sStrip1.Dock = DockStyle.Bottom;
            //
            // sStrip1Lbl IN StatusStrip
            //
            sStrip1Lbl = new ToolStripStatusLabel();
            sStrip1.Items.AddRange(new ToolStripItem[] { sStrip1Lbl });
            sStrip1Lbl.Text = "F1 - Help";

            #endregion StatusStrip

            #region Add Controls to Form
            //
            // Add Controls to Form1
            //
            this.Controls.Add(pict_01);
            // groupBox1 with radiobuttons
            this.Controls.Add(groupBox1);
            this.groupBox1.Controls.Add(this.radioBtn_CircleRod);       // add obj radioBtnCircle на объект groupBox1
            this.groupBox1.Controls.Add(this.radioBtn_CircleTube);      // add obj radioBtnCircleRing на объект groupBox1
            this.groupBox1.Controls.Add(this.radioBtn_RectangleRod);    // add obj radioBtnRectangle на объект groupBox1
            this.groupBox1.Controls.Add(this.radioBtn_RectangleTube);   // add obj radioBtnRectangle на объект groupBox1

            this.Controls.Add(pict_02);
            // groupBox2 with radiobuttons
            this.Controls.Add(groupBox2);
            this.groupBox2.Controls.Add(this.radioBtn_Stretch);
            this.groupBox2.Controls.Add(this.radioBtn_Bend);
            this.groupBox2.Controls.Add(this.radioBtn_Twist);
            this.groupBox2.Controls.Add(this.radioBtn_Cut);

            // textboxses and labels
            TBox_2.Hide();
            lbl_TBox_2.Hide();
            TBox_3.Hide();
            lbl_TBox_3.Hide();
            TBox_11.Hide();
            lbl_TBox_11.Hide();

            this.Controls.Add(TBox_1);
            this.Controls.Add(lbl_TBox_1);
            this.Controls.Add(TBox_2);
            this.Controls.Add(lbl_TBox_2);
            this.Controls.Add(TBox_3);
            this.Controls.Add(lbl_TBox_3);
            this.Controls.Add(TBox_10);
            this.Controls.Add(lbl_TBox_10);
            this.Controls.Add(TBox_11);
            this.Controls.Add(lbl_TBox_11);

            this.Controls.Add(Result_1);
            this.Controls.Add(Result_2);

            this.Controls.Add(listBoxSteel);
            this.Controls.Add(listBoxSteel.labelDataOfSteel);   // Определение контрола в классе ListBoxSteelChoice : ListBox
            this.Controls.Add(listBoxSteel.LAS);                // Определение контрола в классе ListBoxSteelChoice : ListBox
            this.Controls.Add(sStrip1);
            
            #endregion Add Controls to Form

        }   // end of - InitializeDynamicComponent() 


        #region EVENT HANDLERS !!! 

        void listBoxSteel_SteelChanged(object sender, EventArgs e)
        {   
            if(Result_2.Text != "")
                showResultForce();
        }   // end of - listBoxSteel_SteelChanged(object sender, EventArgs e)


        void pict_01_MouseClick(object sender, MouseEventArgs e)    // = Button RUN
        {
            if (e.Button == MouseButtons.Left) { showResultProfile(); }
        }   // end of - pict_01_MouseClick
        

        void pict_02_MouseClick(object sender, MouseEventArgs e)    // Левая и правая кнопки мыши
        {
            if (showResultProfile())
                {
            if (e.Button == MouseButtons.Left)
            { showResultStress(); }
            else   // MouseButtons.Right
            { showResultForce(); }
                }   // end of - if (showResultProfile())
        }   // end of - pict_02_MouseClick


        void lbl_TBox_10_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Click");
            switch (lbl_TBox_10.Text)
            {
                case "F, kg":
                    lbl_TBox_10.Text = "F, N";
                    if (TBox_10.Text != "")
                    {
                        TBox_10.setText(TBox_10.val * 10.0);
                        showResultStress();
                    }
                    break;
                case "F, N":
                    lbl_TBox_10.Text = "F, kg";
                    if (TBox_10.Text != "")
                    {
                        TBox_10.setText(TBox_10.val / 10.0);
                        showResultStress();
                    }
                    break;
                case "M, kg*cm":
                    lbl_TBox_10.Text = "M, N*M";
                    if (TBox_10.Text != "")
                    {
                        TBox_10.setText(TBox_10.val / 10.0);
                        showResultStress();
                    }
                    break;
                case "M, N*M":
                    lbl_TBox_10.Text = "M, kg*cm";
                    if (TBox_10.Text != "")
                    {
                        TBox_10.setText(TBox_10.val * 10.0);
                        showResultStress();
                    }
                    break;
            }   // end of - switch (lbl_TBox_10.Text)
        }       // end of - InitializeDynamicComponent()


        private void параметрыПрофиляToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showResultProfile();
        }

        private void напряжениеToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showResultProfile();
            showResultStress();
        }

        private void максУсилиеToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            showResultProfile();
            showResultForce();
        }   

        // Профиль
        
        void radioBtn_CircleRod_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_CircleRod.Checked == true)
            {
                profile = Profile.Circle;
                pict_01.Image = CalcStress_003.Properties.Resources.CircleRod;
                TBox_1.name1 = "D, mm";
                lbl_TBox_1.Text = TBox_1.name1;
                TBox_2.Hide();
                lbl_TBox_2.Hide();
                TBox_3.Hide();
                lbl_TBox_3.Hide();
                radioBtn_Twist.Enabled = true;
                radioBtn_Cut.Enabled = true;
                radioBtn_CircleRod.TabStop = false;
                TBox_10.Text = "";
                TBox_11.Text = "";
                Result_1_Clear();
                Result_2_Clear();
                TBox_1.Focus();
            }   // if (radioBtn_CircleRod.Checked == true)
        }       // radioBtn_CircleRod_CheckedChanged


        void radioBtn_CircleTube_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_CircleTube.Checked == true)
            {
                profile = Profile.CircleRing;
                pict_01.Image = CalcStress_003.Properties.Resources.CircleTube;
                TBox_1.name1 = "D, mm";
                TBox_2.name1 = "S, mm";
                lbl_TBox_1.Text = TBox_1.name1;
                lbl_TBox_2.Text = TBox_2.name1;
                TBox_2.Show();
                lbl_TBox_2.Show();
                TBox_3.Hide();
                lbl_TBox_3.Hide();
                if (radioBtn_Cut.Checked == true)
                    radioBtn_Stretch.Checked = true;
                radioBtn_Twist.Enabled = true;
                radioBtn_Cut.Enabled = false;
                radioBtn_CircleTube.TabStop = false;
                TBox_10.Text = "";
                TBox_11.Text = "";
                Result_1_Clear();
                Result_2_Clear();
                TBox_1.Focus();
            }   // if (radioBtn_CircleRod.Checked == true)
        }       // radioBtn_CircleTube_CheckedChanged


        void radioBtn_RectangleRod_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_RectangleRod.Checked == true)
            {
                profile = Profile.Rectangle;
                pict_01.Image = CalcStress_003.Properties.Resources.RectangleRod;
                TBox_1.name1 = "B, mm";
                TBox_2.name1 = "H, mm";
                lbl_TBox_1.Text = TBox_1.name1;
                lbl_TBox_2.Text = TBox_2.name1;
                TBox_2.Show();
                lbl_TBox_2.Show();
                TBox_3.Hide();
                lbl_TBox_3.Hide();
                radioBtn_Twist.Enabled = true;
                radioBtn_Cut.Enabled = true;
                radioBtn_RectangleRod.TabStop = false;
                TBox_10.Text = "";
                TBox_11.Text = "";
                Result_1_Clear();
                Result_2_Clear();
                TBox_1.Focus();
            }   // if (radioBtn_RectangleRod.Checked == true)
        }       // radioBtn_RectangleRod_CheckedChanged


        void radioBtn_RectangleTube_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_RectangleTube.Checked == true)
            {
                profile = Profile.RectangleRing;
                //pict_01.Image = CalcStress_001.Properties.Resources.RectangleTube;
                pict_01.Image = CalcStress_003.Properties.Resources.rect_rad;
                TBox_1.name1 = "B, mm";
                TBox_2.name1 = "H, mm";
                lbl_TBox_1.Text = TBox_1.name1;
                lbl_TBox_2.Text = TBox_2.name1;
                TBox_2.Show();
                lbl_TBox_2.Show();
                TBox_3.Show();
                lbl_TBox_3.Show();
                if ((radioBtn_Twist.Checked == true) || (radioBtn_Cut.Checked == true))
                    radioBtn_Stretch.Checked = true;
                radioBtn_Twist.Enabled = false;
                radioBtn_Cut.Enabled = false;
                radioBtn_RectangleTube.TabStop = false;
                TBox_10.Text = "";
                TBox_11.Text = "";
                Result_1_Clear();
                Result_2_Clear();
                TBox_1.Focus();
            }   // if (radioBtn_RectangleRod.Checked == true)
        }       // radioBtn_RectangleTube_CheckedChanged

        // Сила

        void radioBtnStretch_CheckedChanged(object sender, EventArgs e)
        {   //(0)Stretch - растяжение//(1)Bend - изгиб//(2)Twist - кручение//(3)Cut - срез//(4)Crush - смятие
            if (radioBtn_Stretch.Checked == true)
            {
                typeload = TypeLoad.Stretch;
                pict_02.Image = CalcStress_003.Properties.Resources.ForceStretch;
                TBox_10.name1 = "F, kg";
                lbl_TBox_10.Text = TBox_10.name1;
                if (TBox_11.Visible)
                {
                    TBox_11.Hide();
                    lbl_TBox_11.Hide();
                }
                radioBtn_Stretch.TabStop = false;
                listBoxSteel.set_actual_Stress_Max();
                listBoxSteel.show_Data_Of_Steel();
                TBox_10.Text = "";
                TBox_11.Text = "";
                Result_2_Clear();
                TBox_10.Focus();
            }   // if (radioBtn_RectangleTube.Checked == true)
        }       // radioBtnStretch_CheckedChanged
        

        void radioBtnBend_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_Bend.Checked == true)
            {
                typeload = TypeLoad.Bend;
                pict_02.Image = CalcStress_003.Properties.Resources.ForceBend;
                TBox_10.name1 = "F, kg";
                lbl_TBox_10.Text = TBox_10.name1;
                TBox_11.Show();
                lbl_TBox_11.Show();
                radioBtn_Bend.TabStop = false;
                listBoxSteel.set_actual_Stress_Max();
                listBoxSteel.show_Data_Of_Steel();
                TBox_10.Text = "";
                TBox_11.Text = "";
                Result_2_Clear();
                TBox_10.Focus();
            }   // if (radioBtn_Bend.Checked == true)
        }       // radioBtnBend_CheckedChanged


        void radioBtnTwist_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_Twist.Checked == true)
            {
                typeload = TypeLoad.Twist;
                pict_02.Image = CalcStress_003.Properties.Resources.ForceTwist;
                TBox_10.name1 = "M, kg*cm";
                lbl_TBox_10.Text = TBox_10.name1;
                if (TBox_11.Visible)
                {
                    TBox_11.Hide();
                    lbl_TBox_11.Hide();
                }
                radioBtn_Twist.TabStop = false;
                listBoxSteel.set_actual_Stress_Max();
                listBoxSteel.show_Data_Of_Steel();
                TBox_10.Text = "";
                TBox_11.Text = "";
                Result_2_Clear();
                TBox_10.Focus();
            }   // if (radioBtn_Twist.Checked == true)
        }       // radioBtnTwist_CheckedChanged


        void radioBtnCut_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_Cut.Checked == true)
            {
                typeload = TypeLoad.Cut;
                pict_02.Image = CalcStress_003.Properties.Resources.ForceCut;
                TBox_10.name1 = "F, kg";
                lbl_TBox_10.Text = TBox_10.name1;
                if (TBox_11.Visible)
                {
                    TBox_11.Hide();
                    lbl_TBox_11.Hide();
                }
                radioBtn_Cut.TabStop = false;
                listBoxSteel.set_actual_Stress_Max();
                listBoxSteel.show_Data_Of_Steel();
                TBox_10.Text = "";
                TBox_11.Text = "";
                Result_2_Clear();
                TBox_10.Focus();
            }   // if (radioBtn_Cut.Checked == true)
        }       // radioBtnCut_CheckedChanged

        //

        // TBox_1_TxtChanged - !!!  это не стандартное TextChanged  !!!
        void TBox_1_TxtChanged(object sender, EventArgs e) // работает для TBox_1-3 а не только TBox_1 !!!!
        {
            //TxtBoxDbl a = (TxtBoxDbl)sender;
            Result_1_Clear();
        }   // end of - TBox_1_TxtChanged


        void TBox_10_TxtChanged(object sender, EventArgs e) // работает для TBox_10-11 а не только TBox_10 !!!!
        {
            //TxtBoxDbl a = (TxtBoxDbl)sender;
            Result_2_Clear();
        }   // end of - TBox_1_TxtChanged
        
        #endregion EVENT HANDLERS !!!

    }       // end of - class Form_CalcStress : aForm
}           // end of - namespace CalcStress_001