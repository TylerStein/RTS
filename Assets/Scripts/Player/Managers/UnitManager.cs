using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

public class UnitManager : PlayerManager {
	private List<Unit> _units;

	public UnitManager(Player player) : base(player) {
		_units = new List<Unit>();
	}

    public override void PostInitialize()
    {
        //
    }

    public void AddUnit(Unit unit) {
        if (!_units.Contains(unit)) {
            _units.Add(unit);
            string unitString = "[";
            Unit[] unitArr = _units.ToArray();
            for (int i = 0; i < unitArr.Length; i++) {
                unitString += _units[i].entity.displayName;
                if (i < (unitArr.Length - 1)) {
                    unitString += ",";
                }
            }
            unitString += "]";
            Debug.Log("Units: " + unitString);

           //  _player.UIController.SetValue("G_UNITS", (object)unitArr);
        }
    }

    public bool RemoveUnit(Unit unit) {
        return _units.Remove(unit);
    }

    public bool HasUnit(Unit unit) {
        return _units.Contains(unit);
    }
}
