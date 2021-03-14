using System.Collections.Generic;
using System.Reflection;
using Godot;

namespace ResourceEvents.Scripts
{
    public class GameEventResource : Resource
    {
        [Export] public string EventName { get; set; }

        private IEnumerable<string> _methods;
        private string _eventPropertyName;

        public void Raise(params object[] args)
        {
            this.EmitSignal(EventName, args);
        }

        public void StartListen(Node node, string eventPropertyName)
        {           
            _eventPropertyName = eventPropertyName;
            
            if (!this.HasUserSignal(EventName))
                this.AddUserSignal(EventName);

            _methods = GetMethodNames(node);

            foreach (var method in _methods)
                this.Connect(EventName, node, method);
        }

        public void StopListen(Node node)
        {
            foreach (var method in _methods)
                if (this.IsConnected(EventName, node, method))
                    this.Disconnect(EventName, node, method);
        }

        private IEnumerable<string> GetMethodNames(Node node)
        {
            var methods = new List<string>();
            var declaredMethods = node
                .GetType()
                .GetTypeInfo()
                .DeclaredMethods;

            foreach (var declaredMethod in declaredMethods)
            {
                var attr = declaredMethod.GetCustomAttribute<GameEventAttribute>();
                if (attr != null && attr.EventPropertyName == _eventPropertyName)
                    methods.Add(attr.MethodName);
            }

            return methods;
        }
    }
}