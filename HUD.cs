using Godot;
using System;

public class HUD : CanvasLayer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }
	
	public void SetLeftScore(int score) {
		var messageLabel = GetNode<Label>("LeftScore");
    	messageLabel.Text = score.ToString();
	}
	
	public void SetRightScore(int score) {
		var messageLabel = GetNode<Label>("RightScore");
    	messageLabel.Text = score.ToString();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
