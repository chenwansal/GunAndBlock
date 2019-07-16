using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class CuteUDPEvent : MonoBehaviour {
    
    // 接收登录信息 dataString : LoginInfo {stateCode : stateCode, msg : msg }
    // 0 成功 1密码错 2用户名错 3其他
    public static void onLoginRecv(string dataString, string remoteIp) {

        LoginRecvInfo loginRecvInfo = JsonUtility.FromJson<LoginRecvInfo>(dataString);

        if (loginRecvInfo.stateCode == 0) {

            CuteUDPManager.cuteUDP.emitServer("ShowServer", "请求服务器列表");

        } else {

            showAlertWindow(loginRecvInfo.msg);

        }
    }

    // 接收服务器回传
    public static void onShowServerRecv(string dataString, string remoteIp) {

        ServerRecvInfo serverRecvInfo = JsonUtility.FromJson<ServerRecvInfo>(dataString);

        ServerDataScript.serverIdList = serverRecvInfo.serverIdList;

        ServerDataScript.serverUserCountList = serverRecvInfo.serverUserCountList;

        if (ServerDataScript.serverIdList.Length < 0) {

            showAlertWindow("服务器未开放");

        } else {

            SceneManager.LoadScene("chooseServer");

        }
    }

    // 接收角色回传
    public static void onShowRoleRecv(string dataString, string remoteIp) {

        RoleListRecvInfo roleRecvInfo = JsonUtility.FromJson<RoleListRecvInfo>(dataString);

        for (int i = 0; i < roleRecvInfo.roles.Length; i += 1) {

            PlayerDataScript.ROLES.Add(roleRecvInfo.roles[i]);

        }

        SceneManager.LoadScene("RoleList");

    }

    // 删除角色回传
    public static void onDeleteRoleRecv(string dataString, string remoteIp) {

        Debug.Log("删除角色回传");

        PlayerDataScript.ROLES.RemoveAt(PlayerDataScript.ROLE_INDEX);

        SceneManager.LoadScene("RoleList");

    }

    // 进入游戏回传
    public static void onEnterGameRecv(string dataString, string remoteIp) {

        Debug.Log("进入HOME");

        SceneManager.LoadScene("Home");

    }

    // 接收创建角色成功回传
    public static void onCreateRoleRecv(string dataString, string remoteIp) {

        RoleState oneRole = JsonUtility.FromJson<RoleState>(dataString);

        PlayerDataScript.ROLES.Add(oneRole);

        SceneManager.LoadScene("RoleList");

    }

    // 创建角色失败回传
    public static void onCreateRoleFailRecv(string dataString, string remoteIp) {

        showAlertWindow(dataString);

    }

    // 接收服务器房间信息回传
    public static void onShowRoomRecv(string dataString, string remoteIp) {


    }

    // TODO 退出登录
    // public static

    // 弹窗信息
    public static void showAlertWindow(string msg) {

        GameObject HUDPanel = GameObject.Find("HUDPanel");

        if (HUDPanel == null) return;

        GameObject alertWindow = Instantiate(PrefabCollection.instance.alertWindow, HUDPanel.transform);

        Text infoMsg = alertWindow.GetComponentInChildren<Text>();

        infoMsg.text = msg;

        Button infoBtn = alertWindow.GetComponentInChildren<Button>();

        infoBtn.onClick.AddListener(() => {

            alertWindow.SetActive(false);

        });
    }
    
}