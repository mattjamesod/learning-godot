using Godot;
using System;

public partial class Npc : CharacterBody2D {
	public override void _PhysicsProcess(double delta) {
		MoveAndSlide();
	}
}
