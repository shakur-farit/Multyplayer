using UnityEngine;

namespace Code.Gameplay.Features
{
	public interface IBuildFactory
	{
		GameEntity CreateBuild(BuildTypeId typeId, Vector3 at);
	}
}