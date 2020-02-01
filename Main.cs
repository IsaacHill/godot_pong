using Godot;
using System;

public class Main : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    // Called when the node enters the scene tree for the first time.
	private int _leftScore = 0;
	private int _rightScore = 0;
	
    public override void _Ready()
    {
        var hud = GetNode<HUD>("HUD");
        hud.SetLeftScore(_leftScore);
		hud.SetRightScore(_rightScore);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
private void OnBallLeftPoint()
{
   _leftScore++;
	var hud = GetNode<HUD>("HUD");
	var ball = GetNode<Ball>("Ball");
	hud.SetLeftScore(_leftScore);
	ball.LeftReset();
}
private void OnBallRightPoint()
{
   _rightScore++;
	var hud = GetNode<HUD>("HUD");
	var ball = GetNode<Ball>("Ball");
	hud.SetRightScore(_rightScore);
	ball.RightReset();
}
}

