namespace AcademyDatabase.Models;
public partial class Trainee
{
    public override string ToString()
    {
        return $"{TraineeId} {Name} {Course} {Location}";
    }
}
