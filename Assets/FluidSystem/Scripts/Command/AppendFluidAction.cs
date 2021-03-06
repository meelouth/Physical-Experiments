﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppendFluidAction : IFluidAction
{
    private FluidContainer _container;
    private Fluid _fluid;

    public AppendFluidAction(FluidContainer container, Fluid fluid)
    {
        _container = container;
        _fluid = fluid;
    }
    
    public void Execute()
    {
        _container.AppendFluid(_fluid);
        _fluid.SetFluidContainer(_container);
    }
}
