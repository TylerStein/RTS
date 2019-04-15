using UnityEngine;

namespace RTS2.Orders
{
    [CreateAssetMenu(fileName = "New MetaOrder", menuName = "Orders/New MetaOrder", order = 1)]
    public class MetaOrder : ScriptableObject
    {
        [SerializeField] string orderName;
        [SerializeField] Sprite orderImage;
    }
}