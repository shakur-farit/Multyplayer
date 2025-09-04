using UnityEngine;

namespace Code.Gameplay.Features
{
	public interface IBuildingFactory
	{
		GameEntity CreateBuilding(BuildingTypeId typeId, Vector3 at);
	}
}