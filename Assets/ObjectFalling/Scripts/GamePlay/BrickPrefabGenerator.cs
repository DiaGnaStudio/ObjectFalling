using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DiaGna.ObjectFalling
{
    public class BrickPrefabGenerator : MonoBehaviour
    {
        public int brickCount;
        public List<GameObject> prefabs = new List<GameObject>();

        public bool autoPos;
        public List<Vector3> posList = new List<Vector3>();
        public List<GameObject> instantiatedObjects = new List<GameObject>();


        [ContextMenu(nameof(Generate))]
        private void Generate()
        {
            ResetInstantiatedList();

            //int x = Random.Range(-1, 1);
            //int y = Random.Range(-1, 1);

            int x = -1;
            int y = -1;

            Debug.Log("X =" + x + "Y =" + y);

            if(autoPos)
                SetPosList();

            foreach (var item in prefabs)
            {
                var parentObj = new GameObject();
                parentObj.name = item.name + "_" + brickCount.ToString();
                instantiatedObjects.Add(parentObj);

                for (int i = 0; i < brickCount; i++)
                {
                    //var obj = Instantiate(item, parentObj.transform);
                    var go = PrefabUtility.InstantiatePrefab(item as GameObject);
                    GameObject obj = go as GameObject;
                    obj.transform.parent = parentObj.transform;

                    obj.transform.position = posList[i];
                }
            }
        }


        private void SetPosList()
        {
            posList.Clear();

            var currentPos = Vector3.zero;

            for (int i = 0; i < brickCount; i++)
            {
                var rand = Random.RandomRange(0, 2);

                if (i == 0)
                    currentPos = Vector3.zero;
                else
                {
                    if (rand == 0)
                    {
                        currentPos += new Vector3(0, -1, 0);
                    }
                    else
                    {
                        currentPos += new Vector3(-1, 0, 0);
                    }
                }

                posList.Add(currentPos);
            }
        }

        private void ResetInstantiatedList()
        {
            if (instantiatedObjects.Count <= 0) return;

            for (int i = instantiatedObjects.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(instantiatedObjects[i]);
                instantiatedObjects.RemoveAt(i);
            }
            instantiatedObjects.Clear();
        }
    }
}
