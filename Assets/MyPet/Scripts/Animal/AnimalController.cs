using UnityEngine;


namespace Mypet.AI
{
    public class AnimalController : MonoBehaviour
    {
        /// <summary>
        /// 동물을 제어하는 클래스 (동물들의 부모 클래스)
        /// </summary>

        #region Variables
        protected StateMachine<AnimalController> stateMachine;

        //참조
        protected Animator animator;
        //protected CharacterController characterController;
        //protected NaveMeshAgent agent;
        #endregion

        protected virtual void Start()
        {
            //StateMachine 생성
            stateMachine = new StateMachine<AnimalController>(this, new IdleState());

            //참조
            animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            //현재 상태의 업데이트를 stateMachine의 업데이트를 통해 실행
            stateMachine.Update(Time.deltaTime);
        }

        public R ChangeState<R>() where R : State<AnimalController>
        {
            return stateMachine.ChangeState<R>();
        }
    }
}
