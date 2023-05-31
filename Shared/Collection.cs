using System.ComponentModel;

namespace Shared;

public class Collection<T> : BindingList<T>
{
    public void AddItems(IEnumerable<T> items)
    {
        foreach (var item in items) Add(item);
    }

    public void RemoveAll(Func<T, bool> predicate)
    {
        Items.Where(predicate).ToList().ForEach(u => Remove(u));
    }
}