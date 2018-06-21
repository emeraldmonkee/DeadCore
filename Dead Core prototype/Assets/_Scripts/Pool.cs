using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public string Name { get { return _name; } }

    private static List<Pool> _instances = new List<Pool>();
    private GameObject[] _items;

    [SerializeField] private string _name;
    [SerializeField, Space] private int _maxSize;
    [SerializeField] private GameObject _prefab;


    private void Awake()
    {
        // Adds a reference to this pool.
        _instances.Add(this);

        // Creates the pool.
        _items = new GameObject[_maxSize];
        for (int i = 0; i < _maxSize / 2f; i++)
        {
            if (!AddNewObject())
                break;
        }
    }

    private void OnDestroy()
    {
        // Removes the reference to this pool.
        _instances.Remove(this);
    }

    /// <summary>
    /// Returns an object stored within the pool.
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject()
    {
        for (int i = 0; i < _maxSize; i++)
        {
            if (_items[i] != null && !_items[i].activeInHierarchy)
            {
                return _items[i];
            }
        }

        if (AddNewObject())
        {
            return GetObject();
        }

        Debug.Log("Could not retrieve an item from pool:" + _name);
        return null;
    }

    /// <summary>
    /// Adds a new object to the pool, if it has space.
    /// </summary>
    /// <returns></returns>
    private bool AddNewObject()
    {
        for (int i = 0; i < _maxSize; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = Instantiate(_prefab, transform);
                _items[i].SetActive(false);
                return true;
            }
        }

        return true;
    }

    /// <summary>
    /// Returns the instance of a pool with the specified name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Pool GetInstance(string name)
    {
        for (int i = 0; i < _instances.Count; i++)
        {
            if (_instances[i].Name.Equals(name))
            {
                return _instances[i];
            }
        }

        return null;
    }
}
