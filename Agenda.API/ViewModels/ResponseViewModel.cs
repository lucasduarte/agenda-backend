namespace Agenda.API.ViewModels
{
    public class ResponseViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}