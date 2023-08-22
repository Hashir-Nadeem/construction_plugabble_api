using ApiBase;
using System.Reflection;

namespace DynamicContext
{
    public interface IContext
    {
        Assembly GetObj(string token);
        IApiBase createObj();
    }
}