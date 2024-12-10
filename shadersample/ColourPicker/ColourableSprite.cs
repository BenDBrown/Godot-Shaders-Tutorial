using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class ColourableSprite : Sprite2D
{
    private const uint MAX_AMOUNT_OF_TARGET_COLOURS = 10;

    [Export]
    public Color Colour {get;private set;} = new(1,1,1,1);

    [Export]
    private Color[] targetColours = new Color[MAX_AMOUNT_OF_TARGET_COLOURS];

    private ShaderMaterial shaderMat;

    public override void _Ready()
    {
        if (this.Material is ShaderMaterial shaderMaterial) shaderMat = shaderMaterial;
        else GD.PrintErr("material on colourable sprite was null or not a shader material");
        SetColour(Colour);
        shaderMat.SetShaderParameter("shades", targetColours);
    }

    public void SetColour(Color colour)
    {
        this.Colour = colour;
        shaderMat.SetShaderParameter("color", colour);
    }

    public void SetTargetColours(Color[] targetColours)
    {
        if(targetColours.Length > MAX_AMOUNT_OF_TARGET_COLOURS)
        {
            List<Color> newTargets = new();
            for (int i = 0; i < MAX_AMOUNT_OF_TARGET_COLOURS; i++)
            {
                newTargets.Add(targetColours[i]);
            }
            this.targetColours = newTargets.ToArray();
            shaderMat.SetShaderParameter("shades", this.targetColours);
        }
        shaderMat.SetShaderParameter("shades", targetColours);
    }
}
