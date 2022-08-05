using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataHandler : SimpleConfigHandler<CardConfigRoot,CardDataHandler>
{
    public override string module => DataModule.Card;
}
