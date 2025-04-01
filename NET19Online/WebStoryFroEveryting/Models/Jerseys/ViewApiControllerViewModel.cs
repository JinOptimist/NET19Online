namespace WebStoryFroEveryting.Models.Jerseys
{
    public class ViewApiControllerViewModel
    {
    }
    public class MethodInformation
    {
        public string Name { get; set; }
        public string Signature { get; set; }
        public List<MethodParameters> Parameters { get; set; }
        public string ReturnType { get; set; }
    }
    public class MethodParameters
    {
        public string Name { get; set; }
        public bool HasDefaultValue { get; set; }
        public string? DefaultValue { get; set; }
        public Type ParameterType { get; set; }
    }
}
