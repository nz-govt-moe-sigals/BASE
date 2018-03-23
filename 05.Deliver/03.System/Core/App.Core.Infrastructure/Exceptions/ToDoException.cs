using System;

namespace App
{
    public class ToDoException : Exception
    {
        public ToDoException(string message) : base(message) { }
    }
}
