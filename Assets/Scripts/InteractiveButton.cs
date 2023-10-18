﻿using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Examples;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveButton : MonoBehaviour
{
    public GameObject button;
    public GameObject talkUI;
    private bool isNpc;

    void Update()
    {
        //如果是NPC就显示对话弹窗
        if (button.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            if (isNpc)
            {
                button.SetActive(false);
                talkUI.SetActive(true);
            }
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //判断碰撞是是否是NPC
            isNpc = gameObject.CompareTag("NPC");
            button.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isNpc = false;
        button.SetActive(false);
    }
}