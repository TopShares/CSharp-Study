namespace Ruanmou.Web.Core.Models
{
    public class AjaxResult
    {
        public AjaxResult()
        { }

        public string DebugMessage { get; set; }
        public string PromptMsg { get; set; }
        public DoResult Result { get; set; }
        public object RetValue { get; set; }
        public object Tag { get; set; }
    }

    public enum DoResult
    {
        Failed = 0,
        Success = 1,
        OverTime = 2,
        Other = 255
    }
}