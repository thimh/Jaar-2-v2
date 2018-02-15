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

public class Board
{
    public Field StartWhite { get; set; }
    public Field StartBlack { get; set; }

    public Board()
    {
        StartWhite = new Field();
        var field = StartWhite;

        Dictionary<int, FieldType> exceptions = new Dictionary<int, FieldType>();
        exceptions.Add(4, FieldType.Roset);
        exceptions.Add(8, FieldType.Roset);
        exceptions.Add(12, FieldType.Split);
        exceptions.Add(14, FieldType.Roset);

        FieldType type;

        for (int i = 1; i < 13; i++)
        {
            StartWhite.NextField = new Field();
            if(exceptions.TryGetValue(i, out type))
            {
                field.Type = type;
            }
            field = field.NextField;
        }

        //Black fields matter

    }
}

