namespace Facq
{
    public interface IDependencyInjectionProvider 
    { 
        T GetResolve<T>() where T : notnull;
        T GetRequiredResolve<T>() where T : notnull; 
    }
}