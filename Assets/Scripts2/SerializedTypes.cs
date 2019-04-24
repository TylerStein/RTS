using RotaryHeart.Lib.SerializableDictionary;
using System.Collections.Generic;

using UnityEngine;
using RTS2.Entities;
using RTS2.Orders;
using RTS2.Assets;
namespace RTS2.SerializedTypes
{
    [System.Serializable]
    public class SerializedEntityDictionary : SerializableDictionaryBase<string, Entity> { }

    [System.Serializable]
    public class SerializedGameObjectDictionary : SerializableDictionaryBase<string, GameObject> { }

    [System.Serializable]
    public class SerializedOrderDictionary : SerializableDictionaryBase<string, OrderBehaviour> { }

    [System.Serializable]
    public class SerializedOrderDefinitionDictionary : SerializableDictionaryBase<string, OrderBehaviour> { }

    [System.Serializable]
    public struct StringList
    {
        [SerializeField] public List<string> values;
    }

    [System.Serializable]
    public class SerializedStringListDictionary : SerializableDictionaryBase<string, StringList> { }
}
