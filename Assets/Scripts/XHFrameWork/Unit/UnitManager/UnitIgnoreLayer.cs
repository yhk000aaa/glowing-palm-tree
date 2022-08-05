using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitLayer
{
    //控制点
    UI = 5,
    ControlBody = 8,
    Room,
    Hero,
    Enemy,
    Max,
};
public static class UnitIgnoreLayer
{
    public static void IgnoreLayer()
    {
        for (UnitLayer l1 = UnitLayer.ControlBody; l1 < UnitLayer.Max; l1++) {
            for (UnitLayer l2 = UnitLayer.ControlBody; l2 < UnitLayer.Max; l2++) {
                Physics.IgnoreLayerCollision((int)l1, (int)l2, true);
            }
        }

        ignoreLayer(UnitLayer.ControlBody, ControlBody);
        ignoreLayer(UnitLayer.Room, Room);
        ignoreLayer(UnitLayer.Hero, Hero);
        ignoreLayer(UnitLayer.Enemy, Enemy);
    }

    static void ignoreLayer(UnitLayer layer, UnitLayer[] ignoreLayers)
    {
        foreach (UnitLayer il in ignoreLayers) {
            Physics.IgnoreLayerCollision((int)layer, (int)il, false);
        }
    }

    public static UnitLayer[] ControlBody = { };
    public static UnitLayer[] Room = {  };
    public static UnitLayer[] Hero = { UnitLayer.Enemy, };
    public static UnitLayer[] Enemy = { UnitLayer.Hero, };
}