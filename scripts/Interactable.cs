using Godot;
using System;

public partial class Interactable: Area2D {
	[Export] public double Radius = 500.0;
	[Export] public string LabelText = "Interact";
	public Action Interact;
	
	private InteractionManager InteractionManager;
	
	public override void _Ready() {
		this.InteractionManager = (InteractionManager)GetNode("../../InteractionManager");
	}
	
	private void OnBodyEntered(Node2D body) {
		if ((Godot.CharacterBody2D)GetTree().GetFirstNodeInGroup("player") != body) {
			return;
		}
		this.InteractionManager.Register(this);
	}
	
	private void OnBodyExited(Node2D body) {
		this.InteractionManager.Deregister(this);
	}
}
