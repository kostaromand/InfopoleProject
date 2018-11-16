namespace InfopoleProject.Tests
{
    public partial class ProgramTests
    {
        class TestConsoleReader : IConsoleReader
        {
            public string[] inputStrings;
            private int index=0;
            public TestConsoleReader(string[] inputStrings)
            {
                this.inputStrings = inputStrings;
            }

            public string ReadLine()
            {
                return inputStrings[index++];
            }
        }
    }
}