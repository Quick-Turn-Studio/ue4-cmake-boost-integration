using UnrealBuildTool;
using System.Collections.Generic;

public class TurnBasedGameEditorTarget : TargetRules
{
	public TurnBasedGameEditorTarget( TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		ExtraModuleNames.AddRange( new string[] { "TurnBasedGame" } );
	}
}
