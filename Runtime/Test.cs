using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Runtime
{
    public class Test : MonoBehaviour
    {
        public static GameObject Load()
        {
            var result = Resources.Load("Test");
            return Object.Instantiate(result) as GameObject;
        }

        private void Start()
        {
            Load();
        }
    }
}