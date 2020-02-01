using Godot;
using System;

public class Player : StaticBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
	[Signal]
	public delegate void Hit();

	[Export]
    public int Speed = 400; // How fast the player will move (pixels/sec).
	public int ShapeOffSet = 80;
	[Export]
	public string up = "ui_up";
	[Export]
	public string down = "ui_down";
	private Vector2 _screenSize; // Size of the game window.
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
          _screenSize = GetViewport().GetSize();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
    var velocity = new Vector2(); // The player's movement vector.
	
    if (Input.IsActionPressed(down))
    {
        velocity.y += 1;
    }

    if (Input.IsActionPressed(up))
    {
        velocity.y -= 1;
    }


    if (velocity.Length() > 0)
    {
        velocity = velocity.Normalized() * Speed;
    }    
	Position += velocity * delta;
	Position = new Vector2(
	    x: Mathf.Clamp(Position.x, 0, _screenSize.x),
	    y: Mathf.Clamp(Position.y, ShapeOffSet, _screenSize.y-ShapeOffSet)
	);
  }
	private void OnPlayerBodyEntered(object body)
	{
	    EmitSignal("Hit");
	    GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
}
}

