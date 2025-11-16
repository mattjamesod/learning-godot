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
		var interactable = this.InteractionsInRange.FirstOrDefault();
		ShowOrHideInteractionLabel(interactable);
	}
	
	public override void _Input(InputEvent @event) {
		var interactable = this.InteractionsInRange.FirstOrDefault();
		if (@event.IsActionPressed("interact") && interactable != null) {
			GD.Print("Interacting...");
			interactable.Interact();
		}
	}
	
	public void Register(Interactable interactable) {
		this.InteractionsInRange.Add(interactable);
	}
	
	public void Deregister(Interactable interactable) {
		this.InteractionsInRange.Remove(interactable);
	}
	
	private void ShowOrHideInteractionLabel(Interactable interactable) {
		if (interactable == null) { 
			this.Label.Hide();
			return;
		}
		
		this.BuildLabelForInteractable(interactable);
		this.Label.Show();
	}
	
	private void BuildLabelForInteractable(Interactable interactable) {
		this.Label.Text = "[E] " + interactable.LabelText;
		this.Label.GlobalPosition = new(
			interactable.GlobalPosition.X - (this.Label.Size.X / 2),
			interactable.GlobalPosition.Y + 75
		);
	}
}
