using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtility
{
    public static GameObject[] ReturnClone(this GameObject[] obj, bool setActive = true) 
    {
        GameObject[] array = new GameObject[obj.Length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = GameObject.Instantiate(obj[i], obj[i].transform.position, obj[i].transform.rotation);
            array[i].GetComponent<MeshRenderer>().material
                .CopyPropertiesFromMaterial(obj[i].GetComponent<MeshRenderer>().material);
        }
        return array;
    }

    public static void Destroy(this GameObject[] obj)
    {
        foreach (var gameObject in obj)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public static void SetActive(this GameObject[] obj, bool status)
    {
        foreach (var gameObject in obj)
        {
            gameObject.SetActive(status);
        }
    }
}
