using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase
{
    public abstract void ReturnToPool(Component component);
}
public class Pool<T> : PoolBase where T : Component
{
    private T _prefab;

    private List<T> active = new List<T>();
    private Stack<T> inactive = new Stack<T>();

    public void Initialize(T prefab)
    {
        _prefab = prefab;
    }

    public T Spawn()
    {
        if (inactive.Count > 0)
        {
            var item = inactive.Pop();
            active.Add(item);
            
            if (item.TryGetComponent(out ISpawn iSpawn))
            {
                iSpawn.OnSpawn();
            }
            
            return item;
        }
        T clone = UnityEngine.Object.Instantiate(_prefab);
        
        if (clone.TryGetComponent(out ISpawn iSpawned))
        {
            iSpawned.OnSpawn();
        }
        
        active.Add(clone);
        return clone;
    }

    public override void ReturnToPool(Component obj)
    {
        active.Remove(obj as T);
        inactive.Push(obj as T);
        
        if (obj.TryGetComponent(out IDespawn iDeSpawn))
        {
            iDeSpawn.OnDespawn();
        }
        
        
        obj.gameObject.SetActive(false);
    }

}