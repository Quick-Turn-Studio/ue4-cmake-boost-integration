using UnrealBuildTool;
using System.Collections.Generic;

public class TurnBasedGameTarget : TargetRules
{
	public TurnBasedGameTarget( TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		ExtraModuleNames.AddRange( new string[] { "TurnBasedGame" } );
	}
}
