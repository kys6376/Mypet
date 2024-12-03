using UnityEngine;


namespace Mypet.AI
{
    public class AnimalController : MonoBehaviour
    {
        /// <summary>
        /// ������ �����ϴ� Ŭ���� (�������� �θ� Ŭ����)
        /// </summary>

        #region Variables
        protected StateMachine<AnimalController> stateMachine;

        //����
        protected Animator animator;
        //protected CharacterController characterController;
        //protected NaveMeshAgent agent;
        #endregion

        protected virtual void Start()
        {
            //StateMachine ����
            stateMachine = new StateMachine<AnimalController>(this, new IdleState());

            //����
            animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            //���� ������ ������Ʈ�� stateMachine�� ������Ʈ�� ���� ����
            stateMachine.Update(Time.deltaTime);
        }

        public R ChangeState<R>() where R : State<AnimalController>
        {
            return stateMachine.ChangeState<R>();
        }
    }
}
