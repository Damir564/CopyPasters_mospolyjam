using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerEventsSO", order = 1)]
public class PlayerEventsSO : ScriptableObject
{
    public event UnityAction<string> HealthChangedEvent;
    public event UnityAction<string> AmmoChangedEvent;
    public event UnityAction<GameObject> WeaponChangedEvent;
    public event UnityAction<int> ChangeSceneEvent;
    public event UnityAction TimeSnapEvent;
    //public event UnityAction ShootingEvent;
    // public event UnityAction<int, float> ScopeChangedEvent;
    // public event UnityAction<Color, Transform> WeaponImageAndCameraFollowChangeEvent; // change Color to Image when sprites are ready

    public void RaiseHealthChangedEvent(in string value)
    {
        HealthChangedEvent?.Invoke(value);
    }
    public void RaiseAmmoChangedEvent(in string value)
    {
        AmmoChangedEvent?.Invoke(value);
    }
    public void RaiseTimeSnapEvent()
    {
        TimeSnapEvent?.Invoke();
    }
    public void RaiseChangeSceneEvent(int sceneNumber)
    {
        ChangeSceneEvent?.Invoke(sceneNumber);
    }
    public void RaiseWeaponChangedEvent(GameObject weaponObj)
    {
        WeaponChangedEvent?.Invoke(weaponObj);
    }
    // public void RaiseShootingEvent()
    // {
    //     ShootingEvent?.Invoke();
    // }
    // public void RaiseScopeChangedEvent(in int value, in float valueMultiplier)
    // {
    //     ScopeChangedEvent?.Invoke(value, valueMultiplier);
    // }
    // public void RaiseWeaponImageAndCameraFollowChangeEvent(in Color image, in Transform cameraFollowTransform)
    // {
    //     WeaponImageAndCameraFollowChangeEvent?.Invoke(image, cameraFollowTransform);
    // }
}