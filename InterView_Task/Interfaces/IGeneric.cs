namespace InterView_Task.Interfaces
{
    public interface IGeneric<T>
    {
        List<T> GetAll();
        T GetById(int id);

        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);

        void Save();
    }
}
