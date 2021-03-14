using Godot;
using ResourceEvents.Scripts;

namespace ResourceEvents
{
    public class World : Node2D
    {
        [Export]
        public GameEventResource _onMouseClick;
        
        public void _on_Button_pressed()
        {
            _onMouseClick.Raise();
        }
    }
}
