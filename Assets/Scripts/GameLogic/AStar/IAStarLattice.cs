using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LatticeType
{
    None,
}

public enum LatticeAStarState
{
    None, Close, Open
}

public interface IAStarLattice
{
    int x { get; set; }
    int y { get; set; }
    LatticeAStarState state { get; set; }
    LatticeType latticeType { get; }
    IAStarLattice parentLattice { get; set; }
    List<IAStarLattice> roundLatticeList { get; set; }

    void start();
    void stop();
}
