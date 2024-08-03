using Godot;
using System;
using System.Collections;
using System.Numerics;
using System.Xml.Resolvers;

public partial class RandomGen : Node
{
    private Random _rand;
    private ArrayList _locs;
    private int count;
    [Export]
    public float LevelSize = 1000;

    [Export]
    public Godot.Collections.Array<PackedScene> Spawnable { get; set; }

    [Export]
    private Godot.Collections.Array<float> chances { get; set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        _rand = new Random();
        _locs = new ArrayList();
        count = 0;
        _GenerateOnLvl(10,1);
        _Spawn();

    }

    private void _GenerateOnLvl(int amount, int type)
    {
        //need to adapt it to work with type to, 0 is all random, a set number is specific to that type
        Godot.Vector3 loc;
        float z;

        for(int i = 0; i < amount; i++)
        {
            if (type == 0)
            {
                z = (float) _rand.NextDouble()*(Spawnable.Count-1);          
            }
            else
            {
                z = type-1;
            }

            loc = new Godot.Vector3((float) (_rand.NextDouble()-0.5)*LevelSize*2, (float) (_rand.NextDouble()-0.5)*LevelSize*2, z);
            _locs.Add(loc);
        }
    }

    //needs center obj, is there a way to get the player location in a non-obtrusive way?
    private void _GenerateRadial(float minRadius, int amount, int type)
    {
        double angle = 2*Math.PI*_rand.NextDouble();
        float z;
        if (type == 0)
        {
            z = (float) _rand.NextDouble()*(Spawnable.Count-1);
        }
        else
        {
            z = type-1;
        }
        
        for(int i = 0; i < amount; i++)
        {
            angle = 2*Math.PI*_rand.NextDouble();
            _locs.Add(new Godot.Vector3((float) (Math.Sin(angle)*minRadius*(1+(_rand.NextDouble()-0.5)*2)), (float) (Math.Cos(angle)*minRadius*(1+(_rand.NextDouble()-0.5)*2)), z));
        }
    }

    private void _Pattern(ArrayList locs)
    {
        _locs.AddRange(locs);
    }

    private void _Spawn()
    {

        //instantiate amount
        //fun story: I'm a special kind of dumb, forgot that I had placed the script on another node without defining the packed scene, which caused a nullpointer
        //fun story 2: I have childlike trust, please remember to either set the array entries or not allocate the array space
        if(Spawnable.Count > 0)
        {

            foreach(Godot.Vector3 i in _locs)
            {
                Node myBaby = Spawnable[(int) i.z].Instance<Node2D>(); 
                AddChild(myBaby);

                String name = myBaby.Name;
                Node2D obj = GetNode<Node2D>(name);

                obj.Name += "_" + count;
                obj.Position = new Godot.Vector2(i.x, i.y);
                count++;            
            }

        }       
    }

    private void _Clear(String name)
    {
        GetNode<Node>(name).QueueFree();
    }

    //needs range
    private void _ClearOut(String[] names)
    {
        foreach(String name in names)
        {
            GetNode<Node>(name).QueueFree();
        }
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
