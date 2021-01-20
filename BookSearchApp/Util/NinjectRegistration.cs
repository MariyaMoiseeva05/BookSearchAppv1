using BLL.Data;
using BLL.Interfaces;
using Ninject.Modules;

namespace BookSearchApp.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCRUD>().To<DbDataOperation>();
        }
    }
}
