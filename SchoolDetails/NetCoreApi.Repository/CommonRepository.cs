using Microsoft.EntityFrameworkCore;
using NetCoreApi.Data;
using NetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApi.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly SchoolDbContext _context;
        public CommonRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public bool DeleteSchoolDetail(int id)
        {
            var schoolDetail = _context.SchoolDbSet.Find(id);
            if (schoolDetail == null)
            {
                return false;
            }
            _context.SchoolDbSet.Remove(schoolDetail);
             _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<SchoolDetail> GetSchoolDbSet()
        {
            return _context.SchoolDbSet.ToList();
        }

        public SchoolDetail GetSchoolDetail(int id)
        {
            var schoolDetail =  _context.SchoolDbSet.Find(id);

            return schoolDetail;
        }

        public SchoolDetail PostSchoolDetail(SchoolDetail schoolDetail)
        {
            _context.SchoolDbSet.Add(schoolDetail);
             _context.SaveChangesAsync();
            return _context.SchoolDbSet.Find(schoolDetail.ID);
        }

        public SchoolDetail PutSchoolDetail(int id, SchoolDetail schoolDetail)
        {
            _context.Entry(schoolDetail).State = EntityState.Modified;
            try
            {
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return _context.SchoolDbSet.Find(schoolDetail.ID);
        }

        public bool SchoolDetailExists(int id)
        {
            return _context.SchoolDbSet.Any(e => e.ID == id);
        }
    }
}
