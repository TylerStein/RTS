using UnityEngine;
using System.Collections.Generic;
using RTS2.SerializedTypes;
using System;

namespace RTS2.Assets
{
    [CreateAssetMenu(fileName = "New Entity Orders Manifest", menuName = "Manifest/Entity Orders Manifest")]
    public class EntityOrdersManifest : ScriptableObject
    {
        [SerializeField] protected SerializedStringListDictionary entityOrdersDictionary;

        internal ICollection<string> GetEntityOrders(string entityIdentifier) {
            return entityOrdersDictionary.Keys;
        }
    }
}