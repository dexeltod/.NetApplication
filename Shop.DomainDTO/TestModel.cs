namespace WebApplication2.Models;

public class TestModel
{
	public readonly string TestText;

	public TestModel(string testText = "Hello World") =>
		TestText = testText;
}