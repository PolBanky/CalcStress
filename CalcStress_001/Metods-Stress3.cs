using System.Diagnostics;
//using System.Windows.Forms;
using WinLib;               // using WinLib !!!!!!!!!!!!!


namespace CalcStress_003
{
    public partial class Form_CalcStress : aForm
    {
        // showResultProfile() !!!!!
        bool showResultProfile()  // при щелчке эскиза с профилем ЛЕВОЙ кнопкой мыши 
        {
            switch (profile)    // profile определен НЕ в comDef ! 
            {
                #region  case Profile.Circle

                case Profile.Circle:
                    //*****  1 
                    // TBox_1.Val - свойство, если ноль, то свойство выводит сообщение об ошибке (в окно Result_1) 
                    if (TBox_1.Val == 0.0) return false;
                    // если ОК 
                    d_ex    = TBox_1.val;              // миллиметры 
                    area    = Trig.AreaCircle  ( d_ex); 
                    axial_w = Trig.AxialWCircle( d_ex); 
                    polar_w = Trig.PolarWCircle( d_ex); 
                    Result_1.BackColor = System.Drawing.Color.SpringGreen;
                    Result_1.setText("Площадь сечения S = ", area, // сантиметры^2 
                                   "\nМомент сопротивления осевой\nWx = ",   axial_w,
                                   "\nМомент сопротивления полярный\nWp = ", polar_w);
                    break;  // end of - case Profile.Circle 

                #endregion  case Profile.Circle

                #region  case Profile.CircleRing

                case Profile.CircleRing:
                    //*****  1 
                    if (TBox_1.Val == 0.0) return false;
                    //*****  2 
                    if (TBox_2.Val == 0.0) return false;
                    // если ОК 
                    d_ex = TBox_1.val;      // миллиметры 
                    thickness = TBox_2.val; // миллиметры 
                    d_in = d_ex - 2.0 * thickness;
                    if (d_in < 0.0)
                    {         // ref TBox_2 - куда ставить курсор 
                        warnShow(ref TBox_2, "Толщина стенки больше допустимой");   // "Error !\nH < 2 * S" 
                        return false;
                    }   // if (d_in < 0.0) 
                    // если и тут ОК 
                    area    = Trig.AreaCircleRing  ( d_ex, d_in);
                    axial_w = Trig.AxialWCircleRing( d_ex, d_in);
                    polar_w = Trig.PolarWCircleRing( d_ex, d_in);
                    Result_1.BackColor = System.Drawing.Color.SpringGreen;
                    Result_1.setText("Внутренний диаметр d = ", d_in.Mm, d_in.wtDim, // т.е. показать d вн. в мм
                                      "\nПлощадь сечения S = ", area,
                        "\nМомент сопротивления осевой\nWx = ", axial_w,
                      "\nМомент сопротивления полярный\nWp = ", polar_w );
                    break;  // end of - case Profile.CircleRing

                #endregion  case Profile.CircleRing

                #region  case Profile.Rectangle

                case Profile.Rectangle:
                    //*****  1 
                    if (TBox_1.Val == 0.0) return false;
                    //*****  2 
                    if (TBox_2.Val == 0.0) return false;
                    // если ОК
                    b_ex    = TBox_1.val; // Наружная ширина в мм 
                    h_ex    = TBox_2.val; // Наружная высота в мм 
                    area    = Trig.AreaRectangle  ( b_ex, h_ex);
                    axial_w = Trig.AxialWRectangle( b_ex, h_ex);
                    polar_w = Trig.PolarWRectangle( b_ex, h_ex);
                    Result_1.BackColor = System.Drawing.Color.SpringGreen;
                    Result_1.setText(  "Площадь сечения S = ", area,
                       "\nМомент сопротивления осевой\nWx = ", axial_w,
                     "\nМомент сопротивления полярный\nWp = ", polar_w );
                    break;  //end of - case Profile.Rectangle

                #endregion  case Profile.Rectangle

                #region  case Profile.RectangleRing

                case Profile.RectangleRing:
                    //*****  1 
                    if (TBox_1.Val == 0.0) return false;
                    //*****  2 
                    if (TBox_2.Val == 0.0) return false;
                    //*****  3 
                    if (TBox_3.Val == 0.0) return false;
                    // если ОК 
                    b_ex = TBox_1.val;      // Наружная ширина в мм 
                    h_ex = TBox_2.val;      // Наружная высота в мм 
                    thickness = TBox_3.val; // Толщина стенки в мм  
                    b_in = b_ex - 2.0 * thickness;
                    h_in = h_ex - 2.0 * thickness;
                    if ((b_in <= 0.0)||(h_in <= 0.0))
                    {
                        warnShow(ref TBox_3, "Толщина стенки больше допустимой");    // "Error !\nH < 2 * S"
                        return false;
                    }   // if ((b_in < 0.0)||(h_in < 0.0)) 
                    //  если и тут ОК 
                    area =    Trig.AreaRectangleRing  ( b_ex, h_ex, b_in, h_in);
                    axial_w = Trig.AxialWRectangleRing( b_ex, h_ex, b_in, h_in);
                    // полярный момент для RectangleRing сосчитать не получается 
                    Result_1.BackColor = System.Drawing.Color.SpringGreen;
                    Result_1.setText("Внутренняя ширина b = ", b_in.Mm, b_in.wtDim,
                                   "\nВнутренняя высота h = ", h_in.Mm, h_in.wtDim,
                                     "\nПлощадь сечения S = ", area,
                       "\nМомент сопротивления осевой\nWx = ", axial_w,
                     "\nМомент сопротивления полярный\nWp = ", "no data" );
                    break;  //end of - case Profile.RectangleRing: 

                #endregion  case Profile.RectangleRing

            }   // end of - switch (profile) 
            return true;
        }       // end of - showResultProfile()
        


        // bool showResultStress()  -  РАСЧЕТ НАПРЯЖЕНИЙ ПО ЗАДАННОМУ УСИЛИЮ !!!!! 
        bool showResultStress() // при щелчке эскиза с усилиями ЛЕВОЙ кнопкой мыши 
        {
            switch (typeload)
            {
                #region  case TypeLoad.Stretch

                case TypeLoad.Stretch:  // РАСТЯЖЕНИЕ 
                    //*****  10 
                    // TBox_10.Val - свойство, если == ноль, то выводит сообщение об ошибке (в окно Result_2) 
                    if (TBox_10.Val == 0.0) return false;
                    // если ОК 
                    switch (lbl_TBox_10.Text)
                    {
                        case "F, kg":
                            force.Kg = TBox_10.val; // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "F, N":
                            force.N = TBox_10.val; // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 
                    stress = force / area;
                    // MPa = N / mm^2, а если усилие дано в кг (и площадь в cm^2) то => 
                    // MPa = 0.1 * kg / cm^2  // т.к. ньютонов в 10 раз больше а площадь в 100 раз меньше 
                    // MPa =  10 * kg / mm^2  // т.к. ньютонов в 10 раз больше 
                    Result_2.setText("\u03C3 = ", force, " / ", area, " = ", stress,
                                        "\n  = ", stress.MPa, stress.wtDim, "\n",
                                        makeString());
                    break;

                #endregion  case TypeLoad.Stretch

                #region  case TypeLoad.Bend

                case TypeLoad.Bend: // ИЗГИБ ОТ ПОПЕРЕЧНОЙ СИЛЫ
                    //*****  10 
                    if (TBox_10.Val == 0.0) return false;   // Val - свойство, если ноль, то выводит сообщение об ошибке 
                    //*****  11 
                    if (TBox_11.Val == 0.0) return false;   // Val - свойство, если ноль, то выводит сообщение об ошибке 
                    // если ОК
                    switch (lbl_TBox_10.Text)
                    {
                        case "F, kg":
                            force.Kg = TBox_10.val; // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "F, N":
                            force.N = TBox_10.val; // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 
                    length = TBox_11.val;    // длина в миллиметрах !!! - и ввод в текстбокс в миллиметрах !!! 
                    // изгибающий момент 
                    torque = force * length; // момент - кг * см ( сила в килограммах а длина в сантиметрах ) 
                    // напряжение 
                    stress = torque / axial_w;  // MPa = 0.1*кг*см / см^3 
                    //Result_2.setText("M = ", force.Kg, " kg x ", length.Cm, " cm = ",torque.KgxCm," kg*cm\n  = ",
                    //    r(torque.NxM), " N*metr \n",
                    //    "\u03C3 = ", torque.KgxCm, " kg*cm / ", axial_w.Cm_Cub, " cm^3 = ", stress.Kg_CmSq, " kg/cm^2\n  = ",
                    //             stress.MPa, " MPa\n", makeString());
                    Result_2.setText("M = ", force, " x ", length, " = ", torque, "\n  = ",
                        r(torque.NxM), " N*Metr \n",
                        "\u03C3 = ", torque, " / ", axial_w, " = ", stress, "\n  = ",
                                 stress.MPa, " MPa\n",
                                 makeString());
                    break;

                #endregion  case TypeLoad.Bend

                #region  case TypeLoad.Twist

                case TypeLoad.Twist:    // КРУЧЕНИЕ ОТ КРУТЯЩЕГО МОМЕНТА
                    //*****  10 
                    if (TBox_10.Val == 0.0) return false;
                    // если ОК
                    switch (lbl_TBox_10.Text)
                    {
                        case "M, kg*cm":
                            torque.KgxCm = TBox_10.val; // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "M, N*M":
                            torque.NxM = TBox_10.val; // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 
                    //torque.KgxCm = TBox_10.val;// Крутящий момент в килограммах умножить на сантиметр 
                    stress = torque / polar_w;
                    Result_2.setText("M = ", torque, " = ", r(torque.NxM), " N*Metr\n",
                        "\u03C4 = ", torque, " / ", polar_w, "\n= ", stress, " = ",
                                     stress.MPa, " MPa\n",
                                     makeString());
                    break;

                #endregion  case TypeLoad.Twist

                #region  case TypeLoad.Cut
                    
                case TypeLoad.Cut:      // СРЕЗ
                    //*****  10 
                    if (TBox_10.Val == 0.0) return false;
                    // если ОК
                    switch (lbl_TBox_10.Text)
                    {
                        case "F, kg":
                            force.Kg = TBox_10.val; // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "F, N":
                            force.N = TBox_10.val; // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 
                    //force.Kg = TBox_10.val;         // сила в килограммах !!!
                    stress = force / area;    // 0.1 т.к. stress в MPa 
                    Result_2.setText("\u03C4 = ", force, " / ", area, "\n= ", stress, " = ",
                                   stress.MPa, stress.wtDim, "\n",
                                   makeString());
                    break;

                #endregion  case TypeLoad.Cut

            }   // end of - switch (typeload)
            return true;
        }       // end of - bool showResultStress()
        


        // bool showResultForce  -  РАСЧЕТ МАКСИМАЛЬНОГО УСИЛИЯ ПО ДОПУСТИМОМУ НАПРЯЖЕНИЮ  !!!!! 
        bool showResultForce()  // при щелчке эскиза с усилиями ПРАВОЙ кнопкой мыши 
        {
            switch (typeload)
            {
                #region  case TypeLoad.Stretch

                case TypeLoad.Stretch:  // РАСТЯЖЕНИЕ 
                    if ( TBox_1.Val     == 0.0) return false;
                    if ((TBox_2.Visible == true) && (TBox_2.Val == 0.0)) return false;
                    if ((TBox_3.Visible == true) && (TBox_3.Val == 0.0)) return false;
                    //    MPa = 0.1 * kg / cm^2     
                    // stress = force / area; 
                    //  force = stress * area 
                    force = listBoxSteel.actual_Stress_Max * area;
                    switch (lbl_TBox_10.Text)
                    {
                        case "F, kg":
                            TBox_10.setText(force.Kg); // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "F, N":
                            TBox_10.setText(force.N); // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 
                    //TBox_10.setText(force.Kg);
                    showResultStress();
                    break;

                #endregion  case TypeLoad.Stretch

                #region  case TypeLoad.Bend

                case TypeLoad.Bend: // ИЗГИБ ОТ ПОПЕРЕЧНОЙ СИЛЫ 
                    if (TBox_11.Text == "")
                    {
                        if (System.Windows.Forms.MessageBox.Show("Принимаем длину L = 1000 мм\nКнопка Нет для ввода другой длины", "Info",
                        System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)
                        == System.Windows.Forms.DialogResult.Yes)
                            TBox_11.setText(1000.0);    // миллиметров 
                        else
                        {
                            TBox_11.Focus();
                            return false;
                        }
                    }   // end of - if (TBox_11.Text == "") 
                    length = TBox_11.val;       // ввод в текстбокс в миллиметрах 
                    //   изгибающий момент 
                    // torque = force * length;  // кг*см ( сила в килограммах а длина в сантиметрах )
                    //   напряжение 
                    // stress = torque / axial_w;  // MPa = 0.1 * кг*см / см^3 
                    // stress = (force * length) / axial_w;  // MPa = 0.1 * кг * см / см^3 
                    // force = (stress * axial_w) / length 
                    force = (listBoxSteel.actual_Stress_Max * axial_w) / length;
                    switch (lbl_TBox_10.Text)
                    {
                        case "F, kg":
                            TBox_10.setText(force.Kg); // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "F, N":
                            TBox_10.setText(force.N); // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 
                    // TBox_10.setText(force.Kg);
                    showResultStress();
                    break;

                #endregion  case TypeLoad.Bend

                #region  case TypeLoad.Twist

                case TypeLoad.Twist:    // КРУЧЕНИЕ ОТ КРУТЯЩЕГО МОМЕНТА 
                //torque = TBox_10.val;// Крутящий момент в килограммах умножить на сантиметр 
                // MPa = 0.1 * кг*см / см^3 
                // stress = torque / polar_w;   
                // torque = stress * polar_w 
                    torque = listBoxSteel.actual_Stress_Max * polar_w;
                    switch (lbl_TBox_10.Text)
                    {
                        case "M, kg*cm":
                            torque.KgxCm = TBox_10.val; // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "M, N*M":
                            torque.NxM = TBox_10.val; // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 
                    // TBox_10.setText(torque.KgxCm);
                    showResultStress();
                    break;

                #endregion  case TypeLoad.Twist

                #region  case TypeLoad.Cut

                case TypeLoad.Cut:      // СРЕЗ 
                    //    MPa = 0.1 * кг / cm^2 
                    // stress = force / area 
                    //  force = stress * area 
                    force = listBoxSteel.actual_Stress_Max * area;
                    switch (lbl_TBox_10.Text)
                    {
                        case "F, kg":
                            TBox_10.setText(force.Kg); // сила в ньютонах ! - а ввод в текстбокс в килограммах !!! 
                            break;
                        case "F, N":
                            TBox_10.setText(force.N); // сила в ньютонах ! - и ввод в текстбокс в ньютонах !!! 
                            break;
                    }   // end of - switch (lbl_TBox_10.Text) 
                    // TBox_10.setText(force.Kg);
                    showResultStress();
                    break;

                #endregion  case TypeLoad.Cut

            }   // end of - switch (typeload) 
            return true;
        }       // end of - bool showResultStress() 
        

        // string makeString() 
        public string makeString()
        {
            stress1 difference = 0.0;
            stress1 tmp_Stress_Max = listBoxSteel.actual_Stress_Max;
            double percent = 0.0;

            if (stress > listBoxSteel.actual_Stress_Max) // если напряжение больше допустимого 
            {
                difference = stress - listBoxSteel.actual_Stress_Max;
                percent = stress * 100.0 / listBoxSteel.actual_Stress_Max;
                Result_2.BackColor = System.Drawing.Color.Pink;
                return setText("Напряжение ", stress.MPa, stress.wtDim, " больше\nдопустимого значения ",
                        tmp_Stress_Max.MPa, tmp_Stress_Max.wtDim, "\nна ",
                        difference.MPa, difference.wtDim, " (т.е.= ", percent, " % допустимого)");
            }    // end of - if 
            else // если напряжение меньше допустимого 
            {
                difference = listBoxSteel.actual_Stress_Max - stress;
                percent = stress * 100.0 / listBoxSteel.actual_Stress_Max; // SpringGreen 
                Result_2.BackColor = System.Drawing.Color.SpringGreen;
                return setText("Напряжение ", stress.MPa, stress.wtDim, " меньше\nдопустимого значения ",
                        tmp_Stress_Max.MPa, tmp_Stress_Max.wtDim, "\nна ",
                        difference.MPa, difference.wtDim, " (т.е.= ", percent, " % допустимого)");
            }   // end of - if   // завершение if...else 
                //return resume; 
        }       // end of - string makeString() 
        

        // warnShow(ref TxtBoxDbl a, string msg)
        void warnShow(ref TxtBoxDbl a, string msg)
        {
            Result_1.BackColor = System.Drawing.Color.LightPink;
            Result_1.Text = msg;
            a.Focus();
        }   // end of - warnShow()


        // Result_1_Clear()
        void Result_1_Clear()
        {
            if (Result_1.BackColor != System.Drawing.SystemColors.Info)
            {
                Result_1.BackColor = System.Drawing.SystemColors.Info;
            }   // end of - if
            if (Result_2.BackColor != System.Drawing.SystemColors.Info) // System.Drawing.SystemColors.Info
            {
                Result_2.BackColor = System.Drawing.SystemColors.Info;  // System.Drawing.Color.LightPink
            }   // end of - if
            if (Result_1.Text != "")
                Result_1.Text = "";
            if (Result_2.Text != "")
                Result_2.Text = "";
        }   // end of - Result_1_Clear()


        // Result_2_Clear()
        void Result_2_Clear()
        {
            if (Result_2.BackColor != System.Drawing.SystemColors.Info) // System.Drawing.SystemColors.Info
            {
                Result_2.BackColor = System.Drawing.SystemColors.Info;  // System.Drawing.Color.LightPink
            }   // end of - if
            if (Result_2.Text != "")
                Result_2.Text = "";
        }   // end of - Result_2_Clear()

    }       // end of - class Form_CalcStress : aForm
}           // end of - namespace CalcStress_001