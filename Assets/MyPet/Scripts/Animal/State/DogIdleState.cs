using UnityEngine;

namespace Mypet.AI
{
    [System.Serializable]
    public class DogIdleState : State<AnimalController>
    {
        private Animator animator;

        //animator parameter
        protected int iSitHash = Animator.StringToHash("IsSit");

        public override void OnInitialized()
        {
            //ÂüÁ¶
            animator = context.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            animator.SetBool(iSitHash, true);
        }

        public override void Update(float deltaTime)
        {

        }

        public override void OnExit()
        {
            animator.SetBool(iSitHash, false);
        }
    }
}
