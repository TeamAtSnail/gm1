using System;
using System.Linq;
using Sandbox;
using SandboxEditor;

namespace gm1.Battle.Area;

public abstract partial class PartySpot : Entity
{
	public override void Spawn()
	{
		// Confirm properties
		if ( BattleAreaName == null )
			throw new ArgumentNullException( "BattleAreaName", "PartySpot not linked to a BattleArea!" );
	}

	/// <summary>
	/// Battle area
	/// </summary>
	[Net]
	[Property( Title = "Battle Area" ), FGDType( "target_destination" )]
	public string BattleAreaName { get; set; } = null;
	public BattleArea BattleArea
		=> All.OfType<BattleArea>().FirstOrDefault( cfg => cfg.Name == BattleAreaName );

	/// <summary>
	/// Spacing (in units) between actors.
	/// </summary>
	[Net]
	[Property( Title = "Actor Spacing" )]
	public int ActorSpacing { get; set; } = 32;

	[Net]
	[Property( Title = "Invert Direction" )]
	public bool InvertDirection { get; set; } = true;

	[Net]
	[Property( Title = "Invert Order" )]
	public bool InvertOrder { get; set; } = false;
}

[Library( "gm1_battlearea_partyone" ), HammerEntity]
[Title( "Battle Area Party One Spot" ), Category( "Gameplay" ), Icon( "place" ), EditorModel( "models/light_arrow.vmdl" )]
[Description( "Battle area spot for Party One players" )]
public class PartySpotOne : PartySpot
{ }

[Library( "gm1_battlearea_partytwo" ), HammerEntity]
[Title( "Battle Area Party Two Spot" ), Category( "Gameplay" ), Icon( "place" ), EditorModel( "models/light_arrow.vmdl" )]
[Description( "Battle area spot for Party Two players" )]
public class PartySpotTwo : PartySpot
{ }
