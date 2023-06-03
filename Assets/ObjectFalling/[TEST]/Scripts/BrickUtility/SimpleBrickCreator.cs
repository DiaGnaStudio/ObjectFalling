using DiaGna.ObjectFalling.CraneManaging;
using System.Collections;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility.Test
{
    /// <summary>
    /// A test class to creates new simple <see cref="Brick"/> by Cude.
    /// </summary>
    public class SimpleBrickCreator : MonoBehaviour
    {
        [SerializeField, Min(0)] private float m_Delay = 1;
        [SerializeField] private GameObject cubePrefab;

        private void OnEnable()
        {
            Crane.Instance.Component.Hook.OnDrop += OnDrop;
        }

        private void OnDisable()
        {
            Crane.Instance.Component.Hook.OnDrop -= OnDrop;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
                OnDrop();
        }

        [ContextMenu("Creating")]
        private void OnDrop()
        {
            StartCoroutine(WaitToCreate());
        }

        private IEnumerator WaitToCreate()
        {
            yield return new WaitForSeconds(m_Delay);

            var brick = Creating();
            Crane.Instance.Component.Hook.AssignObject(brick.Rigidbody);
        }

        private Brick Creating()
        {
            //var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var obj = Instantiate(cubePrefab);

            var objectRenderer = obj.GetComponent<Renderer>();
            Material material = new Material(objectRenderer.sharedMaterial);
            material.color = Random.ColorHSV();
            objectRenderer.sharedMaterial = material;

            return obj.GetComponent<Brick>();
        }
    }
}
