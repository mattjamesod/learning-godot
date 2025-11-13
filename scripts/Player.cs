using Godot;
using System;

public partial class Player: CharacterBody2D {
	private const float MoveSpeed = 400.0f;
	
	public override void _PhysicsProcess(double delta) {
		this.Velocity = new Vector2(
			MoveSpeed * (Input.GetActionStrength("right") - Input.GetActionStrength("left")),
			MoveSpeed * (Input.GetActionStrength("down") - Input.GetActionStrength("up"))
		);
		
		this.MoveAndSlide();
	}
}
