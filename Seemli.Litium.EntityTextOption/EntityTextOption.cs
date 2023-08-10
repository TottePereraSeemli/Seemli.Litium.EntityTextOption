using Litium.ComponentModel.Internal;
using Litium.Runtime;

namespace Seemli.Litium.EntityTextOption;

public class EntityTextOption<T, TArea> : IEntityTextOption<T, TArea>
    where T : IEntityKey
    where TArea : IArea
{
    public string FieldId { get; set; }
    public Type AreaType { get; set; }
    public Type EntityType { get; set; }
    public bool MultiSelect { get; set; }
}