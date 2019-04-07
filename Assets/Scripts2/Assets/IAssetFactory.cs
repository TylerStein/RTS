using System.Collections.Generic;

namespace RTS2.Assets
{
    public interface IAssetFactory
    {
        UnityEngine.GameObject GetAssetPrefab(EAssetType assetType, string assetIdentifier);
        ICollection<string> GetAssetNamesOfType(EAssetType assetType);
    }
}
