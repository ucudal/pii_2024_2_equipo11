namespace DefaultNamespace;
using System;
using System.Collections.Generic;

public interface ITipo
{
    string name;
    Dictionary<ITipo> dic_efectivos;

    public float DarEfectividad(ITipo rival);
}