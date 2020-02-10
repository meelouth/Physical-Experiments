﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseFluidAction : IFluidAction
{
    private FluidContainer _container;
    private Fluid _fluid;
    private float _count;
    
    public DecreaseFluidAction(FluidContainer container, Fluid fluid, float count)
    {
        _container = container;
        _fluid = fluid;
        _count = count;
    }
    
    public void Execute()
    {
        Fluid fluid = _fluid;
        
        if (_count >= fluid.GetCount())
        {
            fluid.SetCount(0);
            _container.UnsubscribeToFluid(fluid);
            List<Fluid> list = _container.GetFluids();
            list.Remove(fluid);
            _container.SetFluids(list);
            _container.OnDeletedFluid();
            return;
        }
        
        fluid.SetCount(fluid.GetCount() - _count);
    }
}
