namespace Model;

public class TestModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TestModel(string InputName)
    {
        this.Id = new Random().Next(1, 1000);
        this.Name = InputName;
    }
}
