namespace Refactoring.entities
{
    public class Worker : Human
    {
        #region Properties

        public double Salary { get; set; }

        #endregion

        #region Methods

        public void DoWork()
        {
        }

        public override string ToString()
        {
            return $"Class Worker: \n FullName: {FullName}, Height: {Height}, Width: {Weight}, Salary: {Salary}";
        }

        #endregion
    }
}