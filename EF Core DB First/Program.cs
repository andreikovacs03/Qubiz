using System;
using EF_Core_DB_First.Models;

namespace EF_Core_DB_First
{
    class Program
    {
        //Scaffold-DbContext "Server=DESKTOP-SA5JHSJ;Database=EFCore;Trusted_Connection=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context "AppTestContext"
        static void Main(string[] args)
        {
            using (var context = new AppTestContext())
            {

            }
        }
    }
}
