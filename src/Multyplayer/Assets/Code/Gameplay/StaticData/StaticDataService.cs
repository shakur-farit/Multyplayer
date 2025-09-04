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
		private const string BuildConfigLabel = "BuildConfig";
		private const string WindowConfigLabel = "WindowConfig";

		private Dictionary<WindowId, WindowConfig> _windowById;
		private Dictionary<BuildTypeId, BuildConfig> _buildById;

		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) =>
			_assetProvider = assetProvider;

		public async UniTask Load()
		{
			await LoadBuilds();
			await LoadWindows();
		}

		public BuildConfig GetBuildConfig(BuildTypeId typeId)
		{
			if (_buildById.TryGetValue(typeId, out BuildConfig config))
				return config;

			throw new Exception($"Window config for {typeId} was not found");
		}

		public WindowConfig GetWindowConfig(WindowId typeId)
		{
			if (_windowById.TryGetValue(typeId, out WindowConfig config))
				return config;

			throw new Exception($"Window config for {typeId} was not found");
		}

		private async UniTask LoadBuilds() =>
			_buildById = (await _assetProvider.LoadAll<BuildConfig>(BuildConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);


		private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

	}
}