namespace LiskovSubstitutionPrinciple
{
    class Plane
    {
        protected virtual int MaxFuel => 1000;
        protected virtual int RemainingFuel => 100;

        public virtual float PercentOfRemainingFuel()
        {
            return ((float)RemainingFuel / MaxFuel) * 100;
        }
    }

    class ToyPlane : Plane
    {
        protected override int MaxFuel => 0;
        protected override int RemainingFuel => 0;
    }
}

