// Цель программы - расчет напряжений при растяжении, изгибе, кручении, срезе
// для стержня и трубы - круглого и прямоугольного сечений

using WinLib;   // using WinLib !!!!!!!!!!!!!

namespace CalcStress_003
{

    //  !!!!!!!!!!!!!!!!!!!!!!!!!!!  Form_CalcStress : aForm  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public partial class Form_CalcStress : aForm
    {

        #region  DATA (for this class) !!!

            // geometry
        dim1 d_ex = 0.0;      // Диаметр наружный, мм
        dim1 thickness = 0.0; // Толщина стенки, мм
        dim1 d_in = 0.0;      // Диаметр внутренний, мм
        dim1 b_ex = 0.0;      // Ширина наружная, мм
        dim1 b_in = 0.0;      // Ширина внутренняя, мм
        dim1 h_ex = 0.0;      // Высота наружная, мм
        dim1 h_in = 0.0;      // Высота внутренняя, мм
        dim2 area = 0.0;      // Площадь, мм^2
        dim3 axial_w = 0.0;   // Момент сопротивления осевой, мм^3
        dim3 polar_w = 0.0;   // Момент сопротивления полярный, мм^3
            // force
        force1   force = 0.0; // Сила, кг
        stress1 stress = 0.0; // Напряжение, MPa
        dim1    length = 0.0; // Длина консоли, мм
        moment1 torque = 0.0; // Крутящий момент, кг*мм

        #endregion  DATA (for this class) !!!


            #region  КОНСТРУКТОР !!!
        public Form_CalcStress()
        {
            InitializeComponent();
            InitializeDynamicComponent();
        }   // end of - Form_CalcStress()
            #endregion  КОНСТРУКТОР !!!

    }       // end of - class Form_CalcStress : aForm
}           // end of - namespace Bends_001
