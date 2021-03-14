
### godot-resource-events

So WTH is this repo?
Well is an attempt to create an single source of truth for event (signals) in GODOT.

### How it's work?!
It's use a resource as a single source of truth to emit godot signals, yeah it use the built in signals, with a resource event you can listen for signals or emit they.

### How use?

On you script add an GameEventResource property.

    public class World : Node2D
    {
            [Export]
            public GameEventResource _onMouseClick;
           
           ........

On the editor drag and drop an Event to this property, and you already can Raise the event.
For listen events you will need to use the method `StartListen`.
    
    
    public  class  OtherScene : Node2D  
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

Note: The method OnMouseClick has and GameEvent Attribute with the nameof an avent, thats is for make this method unique for that event, without thats any event on this class will invoke this method.


This is the basic how to use, feel free to make an awsome PR with some magic feature : )
