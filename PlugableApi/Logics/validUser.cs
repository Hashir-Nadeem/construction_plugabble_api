using Dataverse;
using PlugableApi.Models;

namespace PlugableApi.Logics
{
    public static class validUser
    {
        public static Employee isValid(List<Employee> employees,string email,string password)
        {
            foreach(var emp in employees)
            {
                if(emp.Email==email && encryptDecrypt.decode(emp.new_password) == password && emp.Active==true & emp.Approved==true)
                {
                    return emp;
                }
                
            }
            return null;
        }
    }
}
