using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Web_10._27DZ.Interfaces;

namespace Web_10._27DZ.PersonEnv
{
    internal class PesonSameDimensions : EqualityComparer<IPerson>
    {
        public PesonSameDimensions()
        {

        }
        public override bool Equals(IPerson p1, IPerson p2)
        {
            if (p1.Name == p2.Name && p1.Age == p2.Age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode([DisallowNull] IPerson obj)
        {
            throw new System.NotImplementedException();
        }
    }
}