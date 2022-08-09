using System;

namespace POne.Core.Models
{
    public class OptionModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Color { get; set; }
    }

    public class OptionModel<T> : OptionModel
    {
        public T Extra { get; set; }
    }
}
