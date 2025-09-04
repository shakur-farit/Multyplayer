using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features
{
	[CreateAssetMenu(menuName = "Multyplayer/Build Config", fileName = "BuildConfig")]
	public class BuildConfig : ScriptableObject
	{
		public BuildTypeId TypeId;
		public EntityBehaviour ViewPrefab;
		public float CurrentHp;
		public float MaxHp;
		public float BuildRadius;
	}
}