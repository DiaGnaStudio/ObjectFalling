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
        private Coroutine m_CreatingCoroutine;

        private void OnEnable()
        {
            GlobalEvent.OnStartGame += Creating;
            GlobalEvent.OnFinishGame += StopCreating;
            Ground.Instance.OnRotated += CheckCrating;
        }

        private void OnDisable()
        {
            GlobalEvent.OnStartGame -= Creating;
            if (Ground.IsAlive)
            {
                Ground.Instance.OnRotated -= CheckCrating;
            }
        }

        private void CheckCrating(Brick brick)
        {
            if (HeightController.Instance.IsWin) return;

            Creating();
        }

        [ContextMenu("Creating")]
        private void Creating()
        {
            m_CreatingCoroutine ??= StartCoroutine(WaitToCreate());
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
        private void StopCreating(bool obj)
        {
            if (m_CreatingCoroutine != null)
            {
                StopCoroutine(m_CreatingCoroutine);

                m_CreatingCoroutine = null;
            }
        }

    }
}
