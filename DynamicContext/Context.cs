
using ApiBase;
using Dataverse;
using Dataverse.Interfaces;
using FO;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DynamicContext
{
    public class Context : IContext
    {
        private readonly IConfiguration _configuration;
        private readonly IOrganization _organization;
        private readonly IUserSetup _userSetup;
        private readonly IUserActivity _userActivity;
        private readonly ILocation _jobLocation;
        private readonly IJob _job;

        public Context(IConfiguration configuration,IOrganization organization, IUserSetup userSetup,IUserActivity userActivity,ILocation jobLocation,IJob job)
        {
            _configuration = configuration;
            _organization = organization;
            _userSetup = userSetup;
            _userActivity = userActivity;
            _jobLocation = jobLocation;
            _job = job;
        }

        public IApiBase createObj()
        {
            if (_configuration["Platform:Connection"] == "Dataverse")
            {
                 
                return new DataverseConnection(_configuration,_organization,_userSetup,_userActivity,_jobLocation,_job); 
            }
            
            else
            {
                return new FoConnection();
            }
        }
    
        public Assembly GetObj(string integrationPlatform)
        {
            
            Assembly pluginAssembly = LoadPlugin(_configuration[String.Format("Platform:{0}", integrationPlatform)]);
            return pluginAssembly;
        }
        static Assembly LoadPlugin(string relativePath)
        {
            
            /*BY DEFAULT CODE FROM DOCUMENTATION
             * string root = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(typeof(Context).Assembly.Location)))))));
            string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));*/


            //UPDATED CODE TO GET DLL
            var root = Path.GetFullPath(Path.GetDirectoryName(typeof(Context).Assembly.Location));
            string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));

            PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));

        }
        static IEnumerable<IApiBase> CreateCommands(Assembly assembly)
        {
            int count = 0;
            var g = assembly.GetTypes();
            foreach (Type type in assembly.GetTypes())
            {
                
                if (typeof(IApiBase).IsAssignableFrom(type))
                {
                    IApiBase result = Activator.CreateInstance(type) as IApiBase;
                    if (result != null)
                    {
                        count++;
                        yield return result;
                    }
                }
            }

            if (count == 0)
            {
                //return null
            }
        }


    }
}