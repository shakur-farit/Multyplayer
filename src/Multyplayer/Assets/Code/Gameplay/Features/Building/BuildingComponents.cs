using Entitas;

namespace Code.Gameplay.Features
{
	[Game] public class Building : IComponent { }
	[Game] public class BuildingTypeIdComponent : IComponent { public BuildingTypeId Value; }
	[Game] public class BuildingRadius : IComponent { public float Value; }

	[Game] public class Throne : IComponent { }
}