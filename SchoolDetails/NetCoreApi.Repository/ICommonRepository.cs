using NetCoreApi.Models;
using System.Collections.Generic;

namespace NetCoreApi.Repository
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
