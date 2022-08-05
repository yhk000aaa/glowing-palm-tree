using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XHFrameWork;

public class AStarLatticeManager : Singleton<AStarLatticeManager>
{
    private Dictionary<LatticeType, List<IAStarLattice>> _latticeListByType;
    List<IAStarLattice> _openList;
    List<IAStarLattice> _closeList;

    public override void Init()
    {
        base.Init();

        this._latticeListByType = new Dictionary<LatticeType, List<IAStarLattice>>();
        this._openList = new List<IAStarLattice>();
        this._closeList = new List<IAStarLattice>();
    }

    public void addLatticeByType(LatticeType type, IAStarLattice lattice)
    {
        var list = this._latticeListByType.objectValue(type);
        if (list == null) {
            list = new List<IAStarLattice>();
            this._latticeListByType[type] = list;
        }
        
        list.Add(lattice);
    }

    public void removeLatticeByType(LatticeType type, IAStarLattice lattice)
    {
        var list = this._latticeListByType.objectValue(type);
        if (list == null) {
            list = new List<IAStarLattice>();
            this._latticeListByType[type] = list;
        }
        
        list.Remove(lattice);
    }

    public void findPath(IAStarLattice originLattice, IAStarLattice finishLattice)
    {
    }
}
