namespace GradeTracker.Models;

public class Models
{

}
public class Grade
{
    public int Mark { get; set; }
    public double Weight { get; set; }
}

public class Midterm : Grade
{
    public string Name { get; set; }
}

public class Final : Grade
{
    public string Name { get; set; }
}

public class Assignment : Grade
{
    public string Name { get; set; }
}
    
public class Bonus: Grade
{
    public string Name { get; set; }
}
    
public class Course
{
    public string Name { get; set; }
    public List<Midterm> Midterms { get; set; }
    public Final Final { get; set; }
    public List<Assignment> Assignments { get; set; }
}
