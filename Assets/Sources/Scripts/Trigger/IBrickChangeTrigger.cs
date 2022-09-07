using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IBrickCountChangerTrigger
{
    public event UnityAction<int> ChangeBrickCount;
}
