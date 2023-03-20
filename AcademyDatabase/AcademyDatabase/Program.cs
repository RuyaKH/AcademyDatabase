using AcademyDatabase.Models;
using System.Threading.Channels;

using (var db = new AcademyContext())
{
    HandleInput(db);

}

void HandleInput(AcademyContext db)
{
    Console.WriteLine();
    Console.WriteLine("Welcome to the Academy Database");
    Console.WriteLine("Please choose your option: 1. Read, 2. Add, 3. Update, 4. Delete, Other: END");
    bool succeed = Int32.TryParse(Console.ReadLine(), out int input);
    Console.WriteLine();
    switch (input)
    {
        case 1:
            Read(db);
            break;
        case 2:
            InputParamsAdd(db);
            break;
        case 3:
            InputParamsUpdate(db);
            break;
        case 4:
            InputParamsDelete(db);
            break;
        default:
            break;
    }
}

string InputtingID()
{
    Console.WriteLine("Please input ID");
    string id = Console.ReadLine();
    if (id.Length != 5)
    {
        Console.WriteLine("ID has to be 5 characters");
        id = InputtingID();
    }
    return id;
}
void InputParamsAdd(AcademyContext db)
{
    string id = InputtingID();

    Console.WriteLine("Please input Name");
    string name = Console.ReadLine();

    Console.WriteLine("Please input Course");
    string course = Console.ReadLine();

    Console.WriteLine("Please input Location");
    string location = Console.ReadLine();

    AddTrainee(db, id, name, course, location);
}

void InputParamsUpdate(AcademyContext db)
{
    string id = InputtingID();

    Console.WriteLine("Please input Column you are changing");
    string column = Console.ReadLine();

    Console.WriteLine("Please input the new value");
    string newValue = Console.ReadLine();

    Update(db, id, column, newValue);
}

void InputParamsDelete(AcademyContext db)
{
    string id = InputtingID();
    Delete(db, id);
}

void Read(AcademyContext db)
{
    foreach(var trainee in db.Trainees)
    {
        Console.WriteLine(trainee);
    }
    HandleInput(db);
}

void AddTrainee(AcademyContext db, string ID, string name, string course, string location )
{
    var trainee = new Trainee
    {
        TraineeId = ID,
        Name = name,
        Course = course,
        Location = location
    };
    
    db.Trainees.Add(trainee);
    db.SaveChanges();
    Console.WriteLine(trainee);
    HandleInput(db);
}

void Update(AcademyContext db, string ID, string column, string newValue)
{
    var trainee = db.Trainees.Find(ID);
    switch(column.ToLower())
    {
        case "traineeid":
            trainee.TraineeId = newValue;
            break;
        case "name":
            trainee.Name = newValue;
            break;
        case "course":
            trainee.Course = newValue;
            break;
        case "location":
            trainee.Location = newValue;
            break;
        default:
            Console.WriteLine("Invalid Input");
            break;
    }
    db.SaveChanges();
    Console.WriteLine(trainee);
    HandleInput(db);
}

void Delete(AcademyContext db, string ID)
{
    var trainee = db.Trainees.Find(ID);
    db.Trainees.Remove(trainee);
    db.SaveChanges();
    HandleInput(db);
}
