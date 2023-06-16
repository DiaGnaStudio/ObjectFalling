using UnityEngine;

namespace DiaGna.ObjectFalling.BrickUtility
{
    public class BrickParticle : MonoBehaviour
    {
        [SerializeField] private Brick brick;
        [SerializeField] private GameObject ParticlePrefab;

        private void OnEnable()
        {
            brick.OnCollided += PlayParticle;
        }
        private void OnDisable()
        {
            brick.OnCollided -= PlayParticle;
        }

        private void PlayParticle(IBrick brick)
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
