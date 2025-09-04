using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features
{
	public class BuildingFactory : IBuildingFactory
	{
		private readonly IIdentifierService _identifier;
		private readonly IStaticDataService _staticDataService;

		public BuildingFactory(IIdentifierService identifier, IStaticDataService staticDataService)
		{
			_identifier = identifier;
			_staticDataService = staticDataService;
		}

		public GameEntity CreateBuilding(BuildingTypeId typeId, Vector3 at)
		{
			switch (typeId)
			{
				case BuildingTypeId.Throne:
					return CreateThrone(typeId, at);
			}

			throw new Exception($"There is no build for {typeId}");
		}

		private GameEntity CreateThrone(BuildingTypeId typeId, Vector3 at)
		{
			return CreateBuildEntity(typeId, at)
				.With(x => x.isThrone = true);
		}

		private GameEntity CreateBuildEntity(BuildingTypeId typeId, Vector3 at)
		{
			BuildingConfig config = _staticDataService.GetBuildingConfig(typeId);

			return CreateEntity.Empty()
					.AddId(_identifier.Next())
					.AddWorldPosition(at)
					.AddViewPrefab(config.ViewPrefab)
					.AddCurrentHp(config.CurrentHp)
					.AddMaxHp(config.MaxHp)
					.AddBuildingRadius(config.BuildRadius)
					.With(x => x.isBuilding = true);
				;
		}
	}
}