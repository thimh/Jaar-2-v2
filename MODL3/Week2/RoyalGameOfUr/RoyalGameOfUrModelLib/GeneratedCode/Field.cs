﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Field
{
    public Field NextField { get; set; }

    public Pawn Pawn { get; set; }

    public FieldType Type { get; set; }

    public Field Field { get; set; }

    public Field()
    {
        Type = FieldType.Normal;
    }

    public void PlacePawn(Pawn pawn)
    {
        pawn.Field.Pawn = null;
        pawn.Field = this;
        this.Pawn = pawn;
    }
}

