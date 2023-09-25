using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerParams", menuName = "ScriptableObjects/PlayerParameters/Create Player Params")]
public class PlayerParams : ScriptableObject
{
    [Header("The base movement speed of the player")]
    [Range(1, 50)]
    public int BaseSpeed = 1;
    [Range(1, 50)]
    public int MaxSpeed = 1;

    [Header("Jump parameters")]
    
    [Range(1, 100)]
    public int JumpForce = 1;

    [Range(1, 100)]
    public int DoubleJumpForce = 1;

    [Header("Walljump parameters")]
    [Range(1, 1000)]
    public int WallSlideSpeed = 1;

    [Range(1, 90)]
    public int WallJumpAngle= 35;

    [Range(1, 100)]
    public int WallJumpForce = 1;
}
