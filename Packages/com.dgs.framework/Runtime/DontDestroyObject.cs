using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.Framework
{
    public class DontDestroyObject : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(gameObject);   
        }
    }
}