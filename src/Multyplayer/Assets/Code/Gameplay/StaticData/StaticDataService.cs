using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features;
using Code.Infrastructure.AssetManagement;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Code.Gameplay.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string BuildingConfigLabel = "BuildingConfig";
		private const string WindowConfigLabel = "WindowConfig";

		private Dictionary<WindowId, WindowConfig> _windowById;
		private Dictionary<BuildingTypeId, BuildingConfig> _buildingById;

		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) =>
			_assetProvider = assetProvider;

		public async UniTask Load()
		{
			await LoadBuildings();
			await LoadWindows();
		}

		public BuildingConfig GetBuildingConfig(BuildingTypeId typeId)
		{
			if (_buildingById.TryGetValue(typeId, out BuildingConfig config))
				return config;

			throw new Exception($"Building config for {typeId} was not found");
		}

		public WindowConfig GetWindowConfig(WindowId typeId)
		{
			if (_windowById.TryGetValue(typeId, out WindowConfig config))
				return config;

			throw new Exception($"Window config for {typeId} was not found");
		}

		private async UniTask LoadBuildings() =>
			_buildingById = (await _assetProvider.LoadAll<BuildingConfig>(BuildingConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);


		private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

	}
}