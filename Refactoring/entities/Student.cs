namespace Refactoring.entities
{
    public class Student : Human
    {
        #region Properties

        public string University { get; set; }

        #endregion

        #region Methods

        public void DoStudy()
        {
        }

        public override string ToString()
        {
            return
                $"Class Student:\n FullName: {FullName}, Height: {Height}, Width: {Weight}, University: {University}";
        }

        #endregion
    }
}