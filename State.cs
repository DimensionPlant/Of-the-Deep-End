using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class State : Node
{
	public StateMachine fms;
	public virtual void Enter(){}
	public virtual void Exit(){}

	// Called when the node enters the scene tree for the first time.
	new public virtual void Ready(){}
	// Called every frame
	public virtual void Update(float delta){}
	// Called every frame that the physics engine computes
	public virtual void PhysicsUpdate(float delta){}
	public virtual void HandleInput(InputEvent @event){}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
	}
}
