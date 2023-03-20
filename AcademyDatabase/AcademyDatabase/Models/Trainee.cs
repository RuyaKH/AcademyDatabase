using System;
using System.Collections.Generic;

namespace AcademyDatabase.Models;

public partial class Trainee
{
    public string TraineeId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Course { get; set; }

    public string? Location { get; set; }
}
