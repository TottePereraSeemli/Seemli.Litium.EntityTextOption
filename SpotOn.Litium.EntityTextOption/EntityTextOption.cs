﻿using Litium.ComponentModel.Internal;
using Litium.Runtime;

namespace SpotOn.Litium.EntityTextOption;

public class EntityTextOption<T, TArea> : IEntityTextOption<T, TArea>
    where T : IEntityKey
    where TArea : IArea
{
    public string FieldId { get; set; }
    public Type AreaType { get; set; }
    public Type EntityType { get; set; }
    public bool MultiSelect { get; set; } // Support for multi select for fetching multiple entities
}