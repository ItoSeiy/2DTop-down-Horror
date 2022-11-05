using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
/// <summary>
/// MVRP��M
/// </summary>
public class PlayerData : MonoBehaviour
{
    public IntReactiveProperty Life => _life;

    [SerializeField]
    IntReactiveProperty _life = new IntReactiveProperty(100);

    public void Damage(int value) => Life.Value -= value;

    void OnDestroy()
    {
        Life.Dispose();
    }
}
