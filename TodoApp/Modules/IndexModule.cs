using Nancy;
namespace TodoApp.Modules 
{
    public class IndexModule : NancyModule 
    {
        public IndexModule() 
        {
            Get["/"] = parameters => {
                return View["index"];
            };
        }
    }
}