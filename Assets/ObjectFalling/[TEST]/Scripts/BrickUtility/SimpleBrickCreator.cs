using DiaGna.ObjectFalling.CraneManaging;
using DiaGna.ObjectFalling.Gameplay;
using DiaGna.ObjectFalling.GroundUtility;
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
        private bool m_CanCreate;

        private void OnEnable()
        {
            GlobalEvent.OnStartGame += StartCreating;
            GlobalEvent.OnFinishGame += StopCreating;
            Ground.Instance.OnRotated += CheckCrating;
        }


        private void OnDisable()
        {
            GlobalEvent.OnStartGame -= Creating;
            GlobalEvent.OnFinishGame -= StopCreating;
            if (Ground.IsAlive)
            {
                Ground.Instance.OnRotated -= CheckCrating;
            }
        }

        private void StartCreating()
        {
            m_CanCreate = true;
            Creating();
        }

        private void StopCreating(bool isWin)
        {
            m_CanCreate = false;
        }

        private void CheckCrating(Brick brick)
        {
            if (!m_CanCreate) return;

            Creating();
        }

        private void Creating()
        {
            m_CanCreate = true;
            StartCoroutine(WaitToCreate());
        }

        private IEnumerator WaitToCreate()
        {
            yield return new WaitForSeconds(m_Delay);

            Brick brick = GetBrick();
            Crane.Instance.Component.Hook.AssignObject(brick);
        }

        private Brick GetBrick()
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

            var objectRenderer = obj.GetComponent<Renderer>();
            Material material = new Material(objectRenderer.sharedMaterial);
            material.color = Random.ColorHSV();
            objectRenderer.sharedMaterial = material;

            return obj.AddComponent<Brick>();
        }
    }
}
