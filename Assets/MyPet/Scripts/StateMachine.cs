using System.Collections.Generic;
using UnityEngine;

namespace Mypet.AI
{
    /// <summary>
    /// <T>�� ���¸� �����ϴ� Ŭ����
    /// </summary>
    [System.Serializable]
    public abstract class State<T>
    {
        protected StateMachine<T> stateMachine; //�� state�� ��� �Ǿ��ִ� Machine
        protected T context;                    //stateMachine�� ������ �ִ� ��ü

        //������
        public State() { }                      //������

        public void SetMachineAndContext(StateMachine<T> stateMachine, T context)
        {
            this.stateMachine = stateMachine;
            this.context = context;

            OnInitialized();
        }

        public virtual void OnInitialized() {}  //������ 1ȸ ����, �ʱⰪ ����
        public virtual void OnEnter() { }       //���� ��ȯ�� ���·� ���ö� 1ȸ ����

        public abstract void Update(float deltaTime);   //���� ������

        public virtual void OnExit() { }        //���� ��ȯ�� ���¸� ������ 1ȸ ����
    }

    /// <summary>
    /// <T>�� State���� �����ϴ� Ŭ����
    /// </summary>
    public class StateMachine<T>
    {
        private T context;                      //stateMachine�� ������ �ִ� ��ü

        private State<T> currentState;          //���� ����
        public State<T> CurrentState => currentState;

        private State<T> previousState;         //���� ����
        public State<T> PreviousState => previousState;

        private float elapsedTimeInstate = 0.0f;    //���� ���� ���� �ð�
        public float ElapsedTimeInstate => elapsedTimeInstate;

        //��ϵ� ���¸� ������ Ÿ���� Ű������ �����Ѵ�
        private Dictionary<System.Type, State<T>> states = new Dictionary<System.Type, State<T>>();

        public StateMachine(T context, State<T> initialState)
        {
            this.context = context;

            AddState(initialState);
            currentState = initialState;
            currentState.OnEnter();

        }

        //StateMachine�� State ���
        public void AddState(State<T> state)
        {
            state.SetMachineAndContext(this, this.context);
            states[state.GetType()] = state;
        }

        //StateMachine���� State�� ������Ʈ ����

        public void Update(float deltaTime)
        {
            elapsedTimeInstate += deltaTime;

            currentState.Update(deltaTime);
        }


        //currentState�� ���� �ٲٱ�
        public R ChangeState<R>() where R : State<T>
        {
            //�����¿� ���ο� ���� ��
            var newType = typeof(R);
            if(currentState.GetType() == newType)
            {
                return currentState as R;
            }

            //���� ��������
            if(currentState != null)
            {
                currentState.OnExit();
            }
            previousState = currentState;
            
            //���� ����
            currentState = states[newType];
            currentState.OnEnter();
            elapsedTimeInstate = 0.0f;

            return currentState as R;
        }
    }
}
