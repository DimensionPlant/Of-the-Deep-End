using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{

	[Export] public NodePath initialState;

	private Dictionary<string, State> _states;
	private State _currentState;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_states = new Dictionary<string, State>();
		foreach (Node node in GetChildren())
		{
			if (node is State s)
			{
				_states[node.Name] = s;
				s.fms = this;
				s.Ready();
				s.Exit(); //be sure it resets

			}
		}
		_currentState = GetNode<State>(initialState);
		_currentState.Enter();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		_currentState.Update((float) delta);
	}
	public override void _PhysicsProcess(float delta)
	{
		_currentState.PhysicsUpdate((float) delta);
	}

	public override void _Input(InputEvent @event)
	{
		_currentState.HandleInput(@event);
	}
	public override void _UnhandledInput(InputEvent @event)
	{
		_currentState.HandleInput(@event);
	}

	public void TransitionTo(string key)
	{
		if(!_states.ContainsKey(key) || _currentState == _states[key])
		{
			return;
		}
		_currentState.Exit();
		_currentState = _states[key];
		_currentState.Enter();

	}
}
