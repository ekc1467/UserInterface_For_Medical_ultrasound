using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace WpfApp3
{
    /// <summary>
    /// MousePointer.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class MousePointer : Page
    {
        private bool check = true;
        private bool start = false;
        private int Rotation_angle2;
        private System.Windows.Vector pY;
        private System.Windows.Vector pY2;

        public MousePointer()
        {
            InitializeComponent();
            ViewModel v = new ViewModel();
            DataContext = v;
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e2)
        {
            ViewModel v = DataContext as ViewModel;


            if (!check)
            {
                if (start)
                {
                    System.Windows.Point position = e2.GetPosition(this);
                    pY = new System.Windows.Vector((float)position.X - 500, (float)position.Y - 500);

                    v.RotationAngle = (int)System.Windows.Vector.AngleBetween(pY2, pY);

                    v.Res = v.Num + v.RotationAngle;
                    v.Res = v.Res % 360;
                    offAngle.Angle = v.Res;
                    onAngle.Angle = v.Res;

                    if (v.RotationAngle > Rotation_angle2)
                    {
                        if (v.RotationAngle < 0 && Rotation_angle2 > 0)
                        {

                            if (!(v.Volume <= 0))
                            {
                                if (v.RotationAngle % v.ReferencAangle == 0)
                                {
                                    v.Volume -= v.StepSize;

                                }
                            }
                        }
                        else
                        {
                            if (!(v.Volume >= v.MaxValue))
                            {
                                if (v.RotationAngle % v.ReferencAangle == 0)
                                {
                                    v.Volume += v.StepSize;
                                }
                            }

                        }
                    }
                    else if (Rotation_angle2 > v.RotationAngle)
                    {


                        if (v.RotationAngle >= 0 && Rotation_angle2 < 0)
                        {

                            if (!(v.Volume >= v.MaxValue))
                            {
                                if (v.RotationAngle % v.ReferencAangle == 0)
                                {
                                    v.Volume += v.StepSize;
                                }
                            }

                        }
                        else
                        {
                            if (!(v.Volume <= 0))
                            {
                                if (v.RotationAngle % v.ReferencAangle == 0)
                                {

                                    v.Volume -= v.StepSize;


                                }
                            }


                        }
                    }

                    Rotation_angle2 = v.RotationAngle;


                }
            }
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel v = DataContext as ViewModel;

            if (!check)
            {
                System.Windows.Point position = e.GetPosition(this);

                pY2 = new System.Windows.Vector((float)position.X - 500, (float)position.Y - 500);
                start = true;
            }
        }

        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel v = DataContext as ViewModel;
            start = false;
            v.Num = v.Res;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (check)
            {
                on.Visibility = Visibility.Visible;
                off.Visibility = Visibility.Hidden;
                check = false;
            }
            else
            {
                on.Visibility = Visibility.Hidden;
                off.Visibility = Visibility.Visible;
                check = true;
            }
        }


    }



}


















































//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Windows.Media.Media3D;

//namespace WpfApp3
//{
//    /// <summary>
//    /// MousePointer.xaml에 대한 상호 작용 논리
//    /// </summary>
//    public partial class MousePointer : Page
//    {
//        bool check = true;
//        bool start = false;
//        double num = 0;
//        double pY = 0;
//        double pY2 = 0;
//        double result = 0;
//        double res = 0;
//        public MousePointer()
//        {
//            InitializeComponent();
//        }
//        private void MouseMoveHandler(object sender, MouseEventArgs e2)
//        {
//            e2.Handled = true;

//            // Get the x and y coordinates of the mouse pointer.
//            if (!check)
//            {

//                if (start)
//                {
//                    System.Windows.Point position = e2.GetPosition(this);
//                    pY2 = position.Y;

//                    if (pY2 > pY)
//                    {
//                        result = pY2 - pY;
//                        double res = num - result;
//                        off.LayoutTransform = new RotateTransform(res);
//                        on.LayoutTransform = new RotateTransform(res);
//                    }
//                    else
//                    {
//                        result = pY - pY2;
//                        res = num + result;
//                        off.LayoutTransform = new RotateTransform(res);
//                        on.LayoutTransform = new RotateTransform(res);
//                    }
//                }
//            }
//            // Sets the Height/Width of the circle to the mouse coordinates.

//        }
//        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
//        {
//            e.Handled = true;
//            if (!check)
//            {
//                System.Windows.Point position = e.GetPosition(this);

//                pY = position.Y;
//                start = true;
//            }
//        }

//        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
//        {
//            e.Handled = true;
//            start = false;
//            num = res;
//        }

//        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
//        {
//            e.Handled = true;
//            if (check)
//            {
//                on.Visibility = Visibility.Visible;
//                off.Visibility = Visibility.Hidden;
//                check = false;
//            }
//            else
//            {
//                on.Visibility = Visibility.Hidden;
//                off.Visibility = Visibility.Visible;
//                check = true;
//            }

//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Windows.Media.Media3D;
//using System.Numerics;

//namespace WpfApp3
//{
//    /// <summary>
//    /// MousePointer.xaml에 대한 상호 작용 논리
//    /// </summary>
//    public partial class MousePointer : Page
//    {
//        bool check = true;
//        bool start = false;
//        float num = 0;
//        Vector2 pY;
//        Vector2 pY2;
//        float res = 0;




//        public MousePointer()
//        {
//            InitializeComponent();
//        }
//        private void MouseMoveHandler(object sender, MouseEventArgs e2)
//        {        
//            if (!check)
//            {

//                if (start)
//                {




//                    System.Windows.Point position = e2.GetPosition(this);
//                    pY = new Vector2((float)position.X-500,(float)position.Y-500);

//                    float cosAng1 = Vector2.Dot(pY2, pY);

//                    float Rotation_angle =  (pY2.Y * pY.X + pY2.X * pY.Y > 0.0f) ? (float)(Math.Acos(cosAng1 / pY.Length() / pY2.Length())) * (float)(180 / Math.PI) : -((float)(Math.Acos(cosAng1 / pY.Length() / pY2.Length())) * (float)(180 / Math.PI));


//                    ValueText.Text = Convert.ToString(-Rotation_angle);    

//                    res = num - Rotation_angle;
//                    off.LayoutTransform = new RotateTransform(res);
//                    on.LayoutTransform = new RotateTransform(res);
//                }
//            }
//        }
//        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
//        {
//            if (!check)
//            {
//                System.Windows.Point position = e.GetPosition(this);

//                pY2 = new Vector2((float)position.X-500,(float)position.Y-500);
//                start = true;
//            }
//        }

//        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
//        {

//            start = false;
//            num = res;
//        }

//        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
//        {

//            if (check)
//            {
//                on.Visibility = Visibility.Visible;
//                off.Visibility = Visibility.Hidden;
//                check = false;
//            }
//            else
//            {
//                on.Visibility = Visibility.Hidden;
//                off.Visibility = Visibility.Visible;
//                check = true;
//            }

//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Windows.Media.Media3D;
//using System.Numerics;

//namespace WpfApp3
//{
//    /// <summary>
//    /// MousePointer.xaml에 대한 상호 작용 논리
//    /// </summary>
//    /// 

//    public partial class MousePointer : Page
//    {
//        bool check = true;
//        bool start = false;
//        float num = 0;
//        System.Windows.Vector pY;
//        System.Windows.Vector pY2;
//        float res = 0;
//        int Rotation_angle2;




//        public MousePointer()
//        {
//            InitializeComponent();
//            ViewModel v = new ViewModel();
//            this.DataContext = v;
//        }

//        private void MouseMoveHandler(object sender, MouseEventArgs e2)
//        {
//            ViewModel v = this.DataContext as ViewModel;


//            if (!check)
//            {
//                if (start)
//                {
//                    System.Windows.Point position = e2.GetPosition(this);
//                    pY = new System.Windows.Vector((float)position.X - 500, (float)position.Y - 500);

//                    int Rotation_angle = (int)System.Windows.Vector.AngleBetween(pY2, pY);



//                    //else
//                    //{
//                    //    v.Volume += (pY2.Y * pY.X + pY2.X * pY.Y > 0.0f) ? -1 : +1;
//                    //}




//                    //if(Rotation_angle>0)
//                    //if (res < num)
//                    //{
//                    //    v.Volume += (Rotation_angle > 0.0f) ? +1 : -1;
//                    //}


//                    //if (Math.Sign(Rotation_angle)!=Math.Sign(Rotation_angle2)) {
//                    //    v.Volume += (Math.Sign(Rotation_angle)==1) ? +1 : -1;
//                    //}
//                    //else
//                    //{
//                    //    //if (Math.Sign(Rotation_angle) > 0)
//                    //    //{
//                    //    //    v.Volume += (Rotation_angle > Rotation_angle2) ? +1 : -1;
//                    //    //}
//                    //    //else
//                    //    //{
//                    //    //    v.Volume += (Rotation_angle > Rotation_angle2) ? -1 : +1;
//                    //    //}

//                    //    v.Volume += (Rotation_angle > Rotation_angle2) ? +1 : -1;
//                    //}

//                    //v.Volume += (Rotation_angle >= Rotation_angle2) ? +1 : -1;

//                    //밑에 부분 case로 해서 pass 갈겨야할 듯. 아니다 그냥 else if 하면 되겠네.

//                    //현재 잠시 199됐다가 200으로 다시가는 찰나의 순간에 각도는 그것보다 저 변해 있느니 차라리 마우스 움직이는 순간에 맞춰서 1씩 늘어나는 식으로 만드는 것이..
//                    if(Rotation_angle > Rotation_angle2)
//                    {

//                        if (Rotation_angle2 == -1)
//                        {
//                            if (!(v.Volume <= 0))
//                            {
//                                v.Volume -= 1;
//                                res = num + Rotation_angle;
//                                off.LayoutTransform = new RotateTransform(res);
//                                on.LayoutTransform = new RotateTransform(res);

//                            }

//                        }
//                        else
//                        {
//                            if(!(v.Volume >= 200))
//                            { 
//                                v.Volume += 1;
//                                res = num + Rotation_angle;
//                                off.LayoutTransform = new RotateTransform(res);
//                                on.LayoutTransform = new RotateTransform(res);
//                            }



//                        }
//                    }
//                    else if (Rotation_angle2 > Rotation_angle)
//                    {

//                        if (Rotation_angle2 == 179)
//                        {
//                            if (!(v.Volume >= 200))
//                            {
//                                v.Volume += 1;
//                                res = num + Rotation_angle;
//                                off.LayoutTransform = new RotateTransform(res);
//                                on.LayoutTransform = new RotateTransform(res);
//                            }


//                        }
//                        else
//                        {
//                            if (!(v.Volume <= 0))
//                            {
//                                v.Volume -= 1;
//                                res = num + Rotation_angle;
//                                off.LayoutTransform = new RotateTransform(res);
//                                on.LayoutTransform = new RotateTransform(res);
//                            }
//                        }
//                    }
//                    //정지 상태를 포함 하느냐 안하느냐가 엄청난 .. 그리고 부호가 바뀔 때만 생각하면 되는 구나 -1부터가 아니라 -180부터 시작이기 때문에
//                    ValueText.Text = Convert.ToString(v.Volume);
//                    Rotation_angle2 = Rotation_angle;

//                }
//            }
//        }
//        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
//        {


//            if (!check)
//            {
//                System.Windows.Point position = e.GetPosition(this);

//                pY2 = new System.Windows.Vector((float)position.X - 500, (float)position.Y - 500);
//                start = true;
//            }
//        }

//        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
//        {

//            start = false;
//            num = res;
//        }

//        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
//        {
//            if (check)
//            {
//                on.Visibility = Visibility.Visible;
//                off.Visibility = Visibility.Hidden;
//                check = false;
//            }
//            else
//            {
//                on.Visibility = Visibility.Hidden;
//                off.Visibility = Visibility.Visible;
//                check = true;
//            }
//        }
//    }
//}

