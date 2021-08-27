using System;

namespace SpaghettiCode
{
    class QuadraticFunctionRoots
    {
        public bool IsNone { get; }
        public bool IsOne { get; }
        public bool AreTwo { get; }

        public double FirstRoot
        {
            get
            {
                if (IsNone)
                {
                    throw new InvalidOperationException(
                        "There is zero quadratic function roots.");
                }
                return _firstRoot;
            }
        }

        public double SecondRoot
        {
            get
            {
                if (IsNone)
                {
                    throw new InvalidOperationException(
                        "There is zero quadratic function roots.");
                }
                if (IsOne)
                {
                    throw new InvalidOperationException(
                        "There is one quadratic function root.");
                }
                return _secondRoot;
            }
        }

        private readonly double _firstRoot;
        private readonly double _secondRoot;

        public QuadraticFunctionRoots()
        {
            IsNone = true;
        }

        public QuadraticFunctionRoots(double onlyRoot)
        {
            IsOne = true;
            _firstRoot = onlyRoot;
        }

        public QuadraticFunctionRoots(double firstRoot, double secondRoot)
        {
            AreTwo = true;
            _firstRoot = firstRoot;
            _secondRoot = secondRoot;
        }
    }
}
