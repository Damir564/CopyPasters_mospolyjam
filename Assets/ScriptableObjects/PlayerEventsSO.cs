using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerEventsSO", order = 1)]
public class PlayerEventsSO : ScriptableObject
{
    public event UnityAction<int> HealthChangedEvent;
    public event UnityAction<string> AmmoChangedEvent;
    public event UnityAction ShootingEvent;
    // public event UnityAction<int, float> ScopeChangedEvent;
    // public event UnityAction<Color, Transform> WeaponImageAndCameraFollowChangeEvent; // change Color to Image when sprites are ready

    public void RaiseHealthChangedEvent(in int value)
    {
        HealthChangedEvent?.Invoke(value);
    }
    public void RaiseAmmoChangedEvent(in string value)
    {
        AmmoChangedEvent?.Invoke(value);
    }
    public void RaiseShootingEvent()
    {
        ShootingEvent?.Invoke();
    }
    // public void RaiseScopeChangedEvent(in int value, in float valueMultiplier)
    // {
    //     ScopeChangedEvent?.Invoke(value, valueMultiplier);
    // }
    // public void RaiseWeaponImageAndCameraFollowChangeEvent(in Color image, in Transform cameraFollowTransform)
    // {
    //     WeaponImageAndCameraFollowChangeEvent?.Invoke(image, cameraFollowTransform);
    // }
}