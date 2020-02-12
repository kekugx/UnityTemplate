using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private ISoundController _soundController;
    
    private void Start()
    {
        _soundController = GetComponent<ISoundController>();
        _soundController.UpdateSound();
    }
}
