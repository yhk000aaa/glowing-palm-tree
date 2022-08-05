using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroup
{
    public const int None = 0;
    public const int BoatUnit = 1;
    public const int Max = 2;

    private static Dictionary<int, string> UnitClassNames = new Dictionary<int, string>()
    {
        {BoatUnit, "BoatUnit"},
    };

    public static string getUnitClassName(int unitGroup)
    {
        return UnitClassNames.objectValue(unitGroup);
    }
}

public partial class UnitManager
{
    private List<Unit>[] units;

    public UnitManager()
    {
        UnitIgnoreLayer.IgnoreLayer();
    }

    public void start()
    {
        this.units = new List<Unit>[UnitGroup.Max];
        for (int i = 0; i < UnitGroup.Max; i++) {
            this.units[i] = new List<Unit>();
        }
    }

    public void update(float dt)
    {
        foreach (var list in this.units) {
            bool exist = false;
            foreach (var unit in list) {
                unit.update(dt);
                if (unit.deleteLater) {
                    unit.stop();
                    exist = true;
                }
            }

            if (exist) {
                list.RemoveAll(x => x.isOver);
            }
        }
    }

    public void stop()
    {
    }

    public Unit creatUnit(int unitGroup, Dictionary<string, object> para)
    {
        var unit = DataUtils.Instance.getActivator<Unit>(UnitGroup.getUnitClassName(unitGroup));
        this.units[unitGroup].Add(unit);
        unit.start(para);
        return unit;
    }

    public BoatUnit createBoatUnit(BattleUI battleUI, BoatConfig boatConfig)
    {
        var dic = DataUtils.Instance.popDict();
        dic["config"] = boatConfig;
        dic["battleUI"] = battleUI;
        return this.creatUnit(UnitGroup.BoatUnit, dic) as BoatUnit;
    }
}
