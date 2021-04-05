using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> studentsArray = new List<GameObject>();
    [SerializeField] private GameObject studentPrefab;
    private GameObject player;

    void Start()
    {
        foreach (GameObject student in studentsArray)
        {
            var newStudent = Instantiate(studentPrefab, student.gameObject.transform.position, Quaternion.identity, student.transform);
            //newStudent.AddComponent<NPC>();
        }

        var level = SceneManager.GetActiveScene().name;

        switch (level) 
        {
            case "Level-01":
                player = studentsArray[18].transform.GetChild(0).gameObject;
                studentsArray.RemoveAt(18);
                break;
        }

        player.AddComponent<Player>();
        foreach (var npc in studentsArray)
        {
            npc.transform.GetChild(0).gameObject.AddComponent<NPC>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}