using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Abstract
{
    public interface ISubjectManager
    {
        IEnumerable<Models.Subject> GetListSubject();
        Models.Subject GetOneSubject(int Id);
    }
}
