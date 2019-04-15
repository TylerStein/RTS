using UnityEngine;
using RTS2.SerializedTypes;
using System;
using System.Collections.Generic;

namespace RTS2.Assets
{
    [CreateAssetMenu(fileName = "New Orders Manifest", menuName = "Manifest/Orders Manifest")]
    public class OrderManifest : ScriptableObject
    {
        [SerializeField] protected SerializedOrderDefinitionDictionary orderDefinitionDictionary;

        internal OrderDefinition GetOrderDefinition(string orderIdentifier) {
            return orderDefinitionDictionary[orderIdentifier];
        }

        internal ICollection<string> GetOrderNames() {
            return orderDefinitionDictionary.Keys;
        }
    }
}