using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Abstract
{
    public interface ISubjectDapper
    {
        List<Models.Subject> GetListSubject();
        Models.Subject GetOneSubject(int Id);   
    }
}
