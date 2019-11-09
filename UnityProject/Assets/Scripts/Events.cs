using ExtraTools;
using UnityEngine.Events;

public class BoolEvent : UnityEvent<bool>
{ }

public class IntEvent : UnityEvent<int>
{ }

public class FloatEvent : UnityEvent<float>
{ }

public class Events : Singleton<Events>
{
    public UnityEvent gameOver = new UnityEvent();
    public FloatEvent energyUpdated = new FloatEvent();
    public IntEvent enemyEnergyUpdated = new IntEvent();
}
