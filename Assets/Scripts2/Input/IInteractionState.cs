﻿namespace RTS2.Input
{
    public enum EInputType
    {
        PRIMARY = 0,
        SECONDARY = 1
    }

    public enum EInputModifier
    {
        NONE = 0,
        MULTI = 1
    }

    public interface IInteractionState
    {
        EInputType GetInputType();
        EInputModifier GetInputModifier();
    }
}