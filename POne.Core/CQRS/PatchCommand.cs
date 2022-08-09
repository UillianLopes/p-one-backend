namespace POne.Core.CQRS
{
    public class PatchOperations
    {
        public const string Add = "Add";
        public const string Copy = "Copy";
        public const string Move = "Move";
        public const string Replace = "Replace";
        public const string Test = "Test";
    }

    public class PatchOption
    {
        public string Op { get; set; }
        public string Patch { get; set; }
        public string From { get; set; }
        public object Value { get; set; }
    }

    public class PatchCommand : ICommand
    {
        public PatchOption[] Patch { get; }
    }
}
