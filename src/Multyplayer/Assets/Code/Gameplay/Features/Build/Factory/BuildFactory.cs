using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using Unity.Collections;
using UnityEngine;

namespace Code.Gameplay.Features
{
	public class BuildFactory : IBuildFactory
	{
		private readonly IIdentifierService _identifier;
		private readonly IStaticDataService _staticDataService;

		public BuildFactory(IIdentifierService identifier, IStaticDataService staticDataService)
		{
			_identifier = identifier;
			_staticDataService = staticDataService;
		}

		public GameEntity CreateBuild(BuildTypeId typeId, Vector3 at)
		{
			switch (typeId)
			{
				case BuildTypeId.Throne:
					return CreateThrone(typeId, at);
			}

			throw new Exception($"There is no build for {typeId}");
		}

		private GameEntity CreateThrone(BuildTypeId typeId, Vector3 at)
		{
			return CreateBuildEntity(typeId, at)
				.With(x => x.isThrone = true);
		}

		private GameEntity CreateBuildEntity(BuildTypeId typeId, Vector3 at)
		{
			BuildConfig config = _staticDataService.GetBuildConfig(typeId);

			return CreateEntity.Empty()
					.AddId(_identifier.Next())
					.AddWorldPosition(at)
					.AddViewPrefab(config.ViewPrefab)
					.AddCurrentHp(config.CurrentHp)
					.AddMaxHp(config.MaxHp)
					.AddBuildRadius(config.BuildRadius)
					.With(x => x.isBuild = true);
				;
		}
	}
}