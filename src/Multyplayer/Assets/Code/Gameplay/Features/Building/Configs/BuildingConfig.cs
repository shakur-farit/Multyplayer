using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features
{
	[CreateAssetMenu(menuName = "Multyplayer/Building Config", fileName = "BuildingConfig")]
	public class BuildingConfig : ScriptableObject
	{
		public BuildingTypeId TypeId;
		public EntityBehaviour ViewPrefab;
		public float CurrentHp;
		public float MaxHp;
		public float BuildRadius;
	}
}