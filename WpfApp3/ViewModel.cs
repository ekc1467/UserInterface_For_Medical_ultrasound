namespace WpfApp3
{
    internal class ViewModel : ValueClass
    {
        public ViewModel()

        {
            Volume = 0;
            StepSize = 3;
            ReferencAangle = 10;
            MaxValue = 360;

            RotationAngle = 0;
            Num = 0;
            Res = 0;
        }
    }
}
