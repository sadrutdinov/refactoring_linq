namespace Refactoring.entities
{
    public interface IHuman
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Height { get; set; }
        double Weight { get; set; }
    }
}