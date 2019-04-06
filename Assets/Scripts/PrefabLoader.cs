using UnityEngine;
using UnityEditor;

public class PrefabLoader {
    private readonly static string BasePath = "Prefabs/";
    
    public static GameObject GetFanatic() {
        return (GameObject)GetPrefab("Entities/Units/FANATIC");
    }

    public static GameObject GetMoveArrow()
    {
        return (GameObject)GetPrefab("Indicators/ARROW_MOVE");
    }

    public static Object GetPrefab(string path) {
        return Resources.Load(BasePath + path);
    }
}