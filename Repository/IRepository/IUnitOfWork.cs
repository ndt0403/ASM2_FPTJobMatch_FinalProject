namespace  FPT_JOBPORTAL.Repository.IRepository
{

    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUserRepository { get; }
        void Save();
    }
}
