using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace WpfApp3
{
    public class ValueClass : INotifyPropertyChanged
    {

        private int volume;
        private int stepSize;
        private int referencAangle;
        private int maxValue;
        private int Rotation_angle;
        private float num;
        private float res;

        public float Res
        {
            get => res;
            set
            {
                res = value;

                RaisePropertyChange();
            }
        }

        public float Num
        {
            get => num;
            set
            {
                num = value;

                RaisePropertyChange();
            }
        }

        public int RotationAngle
        {
            get => Rotation_angle;
            set
            {
                Rotation_angle = value;

                RaisePropertyChange();
            }
        }

        public int MaxValue
        {
            get => maxValue;
            set
            {
                maxValue = value;

                RaisePropertyChange();
            }
        }


        public int Volume
        {
            get => volume;
            set
            {
                volume = value;

                RaisePropertyChange();
            }
        }




        public int StepSize
        {
            get => stepSize;
            set
            {
                stepSize = value;

                RaisePropertyChange();
            }
        }

        public int ReferencAangle
        {
            get => referencAangle;
            set
            {
                referencAangle = value;

                RaisePropertyChange();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));

        }
    }
}
