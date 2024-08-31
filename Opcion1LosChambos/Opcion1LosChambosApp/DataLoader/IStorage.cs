namespace LosChambos.DataLoader;
public interface IStorage<T>
{
    List<T> Load();
    void Save(List<T> list);
}