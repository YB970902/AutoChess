using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Util
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<T>();
                    if (instance == null)
                    {
                        var obj = new GameObject(typeof(T).Name);
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 싱글톤이 실행될때 최초로 1회 실행되는 함수
        /// </summary>
        public abstract void OnStart();
    }
}