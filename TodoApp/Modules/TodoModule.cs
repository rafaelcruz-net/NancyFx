using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;


namespace TodoApp.Modules 
{
    public class Todo 
    {
        public string TaskName { get; set; }
        public bool IsDone { get; set; }
        public int TaskId { get; set; }

    }

    public class TodoModule : NancyModule 
    {
        private static List<Todo> TodoList = new List<Todo>(); 

        public TodoModule() 
        {
            Get["/"] = _ => {
                return Response.AsJson<List<Todo>>(TodoList, HttpStatusCode.OK);
            };

            Get["/{TaskId:int}"] = args => {
                return TodoList.Where(x => x.TaskId == args.TaskId);
            };

            Post["/"] = args => {
                var todo = this.Bind<Todo>();
                todo.TaskId = new Random().Next();
                TodoList.Add(todo);
                return HttpStatusCode.OK;
            };

            Delete["/{TaskId}"] = args => {
                var todo = TodoList.Find(x => x.TaskId == args.TaskId);
                TodoList.Remove(todo);
                return HttpStatusCode.OK;
            };

            Put["/{TaskId}"] = args => {
                
                var todo = TodoList.Find(x => x.TaskId == args.TaskId);
                this.BindTo(todo);
                return HttpStatusCode.OK;
            };
        }
    }
}