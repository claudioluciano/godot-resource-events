using System;

namespace ResourceEvents.Scripts
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GameEventAttribute : Attribute
    {
        public string MethodName { get; }
        public string EventPropertyName { get; }
        public GameEventAttribute(string eventPropertyName, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
        {
            this.MethodName = methodName;
            this.EventPropertyName = eventPropertyName;
        }
    }
}