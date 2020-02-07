﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Playground.SpringSystem;
using UnityEngine;

public class WeightsChain : MonoBehaviour, IHavingMass
{
    public List<JointsContainer> containers = new List<JointsContainer>();

    public WeightsChain CombineChains(WeightsChain anotherChain)
    {
        var combinedJointsContainers = containers.Concat(anotherChain.containers).ToList();
        
        var combinedChain = ChainSpawner.CreateChain(combinedJointsContainers);
        
        Destroy(anotherChain.gameObject);
        Destroy(this.gameObject);
        
        return combinedChain;
    }

    public float GetMass()
    {
        float mass = 0;
        
        foreach (var container in containers)
        {
            mass += container.GetMass();
        }

        return mass;
    }

    public void Add(JointsContainer jointsContainer)
    {
        containers.Add(jointsContainer);
        jointsContainer._weightsChain = this;
        
        jointsContainer.transform.SetParent(transform);
    }

    public void Remove(JointsContainer jointsContainer)
    {
        WeightsChain splittedChain = SplitChain(this, containers.IndexOf(jointsContainer));

        if (containers.Count <= 1)
        {
            RemoveChain(jointsContainer._weightsChain);
            RemoveChain(this);
        }
    }
    
    private WeightsChain SplitChain(WeightsChain chain, int index)
    {
        List<JointsContainer> jointsContainers = new List<JointsContainer>();

        for (int i = index; i >= 0; i--)
        {
            jointsContainers.Add(chain.containers[i]);
        }
        
        chain.containers.RemoveRange(0, index + 1);

        return ChainSpawner.CreateChain(jointsContainers);
    }

    private void RemoveChain(WeightsChain chain)
    {
        foreach (var container in chain.containers)
        {
            container.transform.SetParent(transform.parent);
        }
        
        Destroy(chain.gameObject);
    }
}