using Godot;
using System;

public class Ball : RigidBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
	[Signal]
	public delegate void LeftPoint();
	[Signal]
	public delegate void RightPoint();
	
	public int Speed = 400; 
	private Vector2 _velocity; // Size of the game window.
	private Vector2 _startingPosition;
	private Vector2 _screenSize; // Size of the game window.
	private Vector2 _leftVelocity = new Vector2((float)-1,(float)0.5);	
	private Vector2 _rightVelocity = new Vector2((float)1,(float)-0.5);	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
		  _screenSize = GetViewport().GetSize();
		_startingPosition = new Vector2(_screenSize.x/2, _screenSize.y/2);
		_velocity = _leftVelocity;
		Position = _startingPosition;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
	{
	if (Position.y > _screenSize.y) 
	{
		_velocity = _velocity.Bounce(new Vector2(0, -1));
	} else if (Position.y < 0)
	{
		_velocity = _velocity.Bounce(new Vector2(0, 1));
	}
	_velocity = _velocity.Normalized() * Speed;
	Position += _velocity * delta;   
}

private void OnBallBodyEntered(object body)
{
		_velocity = _velocity.Bounce(new Vector2(1, 0));
}

private void OnVisibilityNotifier2DScreenExited()
{
	if (Position.x < 0)	
	{
		 EmitSignal("LeftPoint");
	} else 
	{
		EmitSignal("RightPoint");
	}
}

public void RightReset() {
	 Position = _startingPosition;
	_velocity = _rightVelocity;
}

public void LeftReset() {
	 Position = _startingPosition;
	_velocity = _leftVelocity;
}
}



