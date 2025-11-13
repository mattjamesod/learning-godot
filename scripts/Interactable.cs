using Godot;
using System;

public partial class Interactable: Area2D {
	[Export] public double Radius = 500.0;
	[Export] public string LabelText = "Interact";
	public Action Interact;
	
	private void OnBodyEntered(Node2D body) {
		GD.Print("Body Entered!");
	}
	
	private void OnBodyExited(Node2D body) {
		GD.Print("Body Exited!");
	}
}
