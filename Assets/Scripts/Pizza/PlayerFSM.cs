using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家状态枚举
public enum PlayerEState
{
    Idle,
    Move,
    Climb,
    Idle2,
    Move2,
    Climb2,
}

//玩家的状态机
public class PlayerFSM
{
    private static PlayerFSM instance;//状态机单例实体
    public static PlayerFSM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerFSM();
            }
            return instance;
        }
    }

    private PlayerFSM() { }//私有构造函数
    private Dictionary<PlayerEState, BaseState> stateDict = new Dictionary<PlayerEState, BaseState>();  //存储状态的字典
    public PlayerEState currentEState;  //当前的状态枚举
    public BaseState currentState;      //当前的状态类
    public PlayerPara playerPara;       //玩家的参数

    /// <summary>
    /// 添加状态的方法
    /// </summary>
    /// <param name="state"></param>
    /// <param name="baseState"></param>
    public void AddState(PlayerEState state, BaseState baseState)
    {
        if (!stateDict.ContainsKey(state))
        {
            stateDict.Add(state, baseState);
        }
    }

    /// <summary>
    /// 切换状态的方法
    /// </summary>
    /// <param name="state"></param>
    public void SwitchState(PlayerEState state)
    {

        //目标状态是否已被添加
        if (!stateDict.ContainsKey(state))
        {
            return;
        }

        //退出当前状态
        if (currentState != null)
        {
            currentState.Exit();
        }

        //切换状态
        currentState = stateDict[state];
        currentEState = state;


        currentState?.Enter();

    }


    /// <summary>
    /// 执行当前状态的Update方法
    /// </summary>
    public void OnUpdate()
    {
        currentState?.Update();
    }


}

//玩家2的状态机
public class Player2FSM
{
    private static Player2FSM instance;//状态机单例实体
    public static Player2FSM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player2FSM();
            }
            return instance;
        }
    }

    private Player2FSM() { }//私有构造函数
    private Dictionary<PlayerEState, BaseState> stateDict = new Dictionary<PlayerEState, BaseState>();  //存储状态的字典
    public PlayerEState currentEState;  //当前的状态枚举
    public BaseState currentState;      //当前的状态类
    public PlayerPara playerPara;       //玩家的参数

    /// <summary>
    /// 添加状态的方法
    /// </summary>
    /// <param name="state"></param>
    /// <param name="baseState"></param>
    public void AddState(PlayerEState state, BaseState baseState)
    {
        if (!stateDict.ContainsKey(state))
        {
            stateDict.Add(state, baseState);
        }
    }

    /// <summary>
    /// 切换状态的方法
    /// </summary>
    /// <param name="state"></param>
    public void SwitchState(PlayerEState state)
    {

        //目标状态是否已被添加
        if (!stateDict.ContainsKey(state))
        {
            return;
        }

        //退出当前状态
        if (currentState != null)
        {
            currentState.Exit();
        }

        //切换状态
        currentState = stateDict[state];
        currentEState = state;


        currentState?.Enter();

    }


    /// <summary>
    /// 执行当前状态的Update方法
    /// </summary>
    public void OnUpdate()
    {
        currentState?.Update();
    }


}