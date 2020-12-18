using UnityEngine;

namespace genaralskar.Actor
{
    [RequireComponent(typeof(Actor))]
    public class ActorAnimator : MonoBehaviour
    {
        private Actor actor;

        private void Awake()
        {
            actor = GetComponent<Actor>();

        }
        public void UpdateAnimatorFloat(string param, float value)
        {

        }

        public void UpdateAnimatorBool(string param, bool value)
        {

        }
    }
}