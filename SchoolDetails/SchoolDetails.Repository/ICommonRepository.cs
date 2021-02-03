using SchoolDetails.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDetails.Repository
{
    public interface ICommonRepository
    {
        IEnumerable<SchoolDetail> GetSchoolDbSet();
        SchoolDetail GetSchoolDetail(int id);
        SchoolDetail PutSchoolDetail(int id, SchoolDetail schoolDetail);
        SchoolDetail PostSchoolDetail(SchoolDetail schoolDetail);
        bool DeleteSchoolDetail(int id);
        bool SchoolDetailExists(int id);
    }
}
