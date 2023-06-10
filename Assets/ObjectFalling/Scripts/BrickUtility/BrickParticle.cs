using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    public class BrickParticle : MonoBehaviour
    {
        [SerializeField] private Brick brick;
        [SerializeField] private GameObject ParticlePrefab;

        private void OnEnable()
        {
            brick.OnCollision += PlayParticle;
        }
        private void OnDisable()
        {
            brick.OnCollision -= PlayParticle;
        }

        private void PlayParticle(Brick brick, Collision collision)
        {
            var particle = InstantiateParticle();
            particle.Play();
        }

        private ParticleSystem InstantiateParticle()
        {
            var obj = Instantiate(ParticlePrefab, transform);
            obj.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            var particle = obj.GetComponent<ParticleSystem>();

            return particle;
        }
    }
}
