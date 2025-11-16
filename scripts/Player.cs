using Godot;
using System;

public partial class Player: CharacterBody2D {
	private const float MoveSpeed = 400.0f;
	
	public override void _PhysicsProcess(double delta) {
		this.Velocity = this.InputVelocity();
		this.MoveAndSlide();
	}
	
	private Vector2 InputVelocity() {
		return MoveSpeed * this.InputDirection();
	}
	
	private Vector2 InputDirection() {
		return new Vector2(
			Input.GetActionStrength("right") - Input.GetActionStrength("left"),
			Input.GetActionStrength("down") - Input.GetActionStrength("up")
		).Normalized();
	}
}
