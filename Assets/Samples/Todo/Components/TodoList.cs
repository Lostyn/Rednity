﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using React;
using System.Linq;

public class TodoList : RComposant<TodoList.defaultState> {

    public struct defaultState { }
    [SerializeField] GameObject m_itemPrefab;
    [SerializeField] Transform m_grid;

    protected override void ComponentDidMount()
    {
        base.ComponentDidMount();
    }

    protected override bool ShouldComponentSubscribe()
    {
        return true;
    }

    private void ProcessTask(Task t)
    {
        Transform child = m_grid.Find(t.Id.ToString());
        if(child == null)
        {
            child = Instantiate(m_itemPrefab, m_grid, false).transform;
            child.name = t.Id.ToString();
        }
        child.GetComponentInChildren<RComposant<TodoItem.defaultState>>().SetState(new TodoItem.defaultState
        {
            task = t
        });
    }

    public override void Render()
    {
        List<Task> list = props.Get<List<Task>>("Tasks");
        list.ForEach(ProcessTask);
    }
}