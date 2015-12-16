namespace CookAdvisor.Services
{
    using CookAdvisor.Data;

    public abstract class BaseService
    {
        protected ICookAdvisorDbContext Data { get; private set; }
        
        public BaseService(ICookAdvisorDbContext data)
        {
            this.Data = data;
        }

        public BaseService() :
            this(new CookAdvisorDbContext())
        {

        }
    }
}
