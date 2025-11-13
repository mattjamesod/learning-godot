using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class InteractionManager : Node {
	private Godot.CharacterBody2D Player;
	private Godot.Label Label;
	
	private List<Interactable> InteractionsInRange = new List<Interactable>();
	
	public override void _Ready() {
		this.Player = (Godot.CharacterBody2D)GetTree().GetFirstNodeInGroup("player");
		this.Label = (Godot.Label)GetNode("Label");
	}
	
	public override void _Process(double delta) {
		if (this.InteractionsInRange.Count <= 0) { 
			this.Label.Hide();
			return;
		}
		
		var interactable = this.InteractionsInRange.First();
		
		this.Label.Text = "[E] " + interactable.LabelText;
		this.Label.GlobalPosition = interactable.GlobalPosition;
		this.Label.Show();
	}
	
	public void Register(Interactable interactable) {
		this.InteractionsInRange.Add(interactable);
	}
	
	public void Deregister(Interactable interactable) {
		this.InteractionsInRange.Remove(interactable);
	}
}
