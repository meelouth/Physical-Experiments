﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Serializable] 
    private struct Experiment
    {
         public GameObject prefab;
        [HideInInspector] public bool exist;
    }

    [SerializeField] private Experiment[] prefabs;
    
    [SerializeField] private Vector3 position;
    
    [SerializeField] private Transform optionalRoot;
    
    private Experiment currentPrefab;

    [HideInInspector] public int currentIndex;

    public void SpawnPrefab(int index)
    {
        if (currentPrefab.exist)
            DestroyPrefab();

        if (prefabs[index].prefab)
            currentPrefab.prefab = Instantiate(prefabs[index].prefab, position, Quaternion.identity);


        currentPrefab.exist = true;
        currentIndex = index;
        
        if (optionalRoot)
            currentPrefab.prefab.transform.SetParent(optionalRoot);
    }

    public void DestroyPrefab()
    {
        Destroy(currentPrefab.prefab);

        currentPrefab.exist = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(position,0.7f);
    }
}
