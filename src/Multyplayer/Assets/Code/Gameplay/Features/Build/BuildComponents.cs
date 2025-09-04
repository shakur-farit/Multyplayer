using Entitas;

namespace Code.Gameplay.Features
{
	[Game] public class Build : IComponent { }
	[Game] public class BuildTypeIdComponent : IComponent { public BuildTypeId Value; }
	[Game] public class BuildRadius : IComponent { public float Value; }

	[Game] public class Throne : IComponent { }
}