using Godot;
using ResourceEvents.Scripts;

namespace ResourceEvents
{
    public class OtherScene : Node2D
    {
        [Export]
        public GameEventResource _onMouseClick;

        public override void _Ready()
        {
            _onMouseClick.StartListen(this, nameof(_onMouseClick));
        }

        public override void _ExitTree()
        {
            _onMouseClick.StopListen(this);
        }

        [GameEvent(nameof(_onMouseClick))]
        public void OnMouseClick()
        {
            GD.Print("Heyy from the OtherScene.cs");
        }
    }
}
