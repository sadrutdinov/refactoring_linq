using System;

namespace Refactoring.entities
{
    public class Human : IHuman, IComparable<Human>
    {
        #region Propeties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        #endregion

        #region Methods

        public int CompareTo(Human other)
        {
            return string.Compare(other.FullName, FullName, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return $"Class Human: \n FullName: {FullName}, Height: {Height}, Width: {Weight}";
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Human h = (Human)obj;
                return (FirstName.Equals(h.FirstName)) && (LastName.Equals(h.LastName)) && (Height.Equals(h.Height))
                       && (Weight.Equals(Weight));
            }
        }

        protected bool Equals(Human other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && Height == other.Height &&
                   Weight.Equals(other.Weight);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Height;
                hashCode = (hashCode * 397) ^ Weight.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}