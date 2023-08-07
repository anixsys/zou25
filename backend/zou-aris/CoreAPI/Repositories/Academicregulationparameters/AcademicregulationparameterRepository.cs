using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Academicregulationparameters
{
    public class AcademicregulationparameterRepository:GenericRepository<Academicregulationparameter>,IAcademicregulationparameterRepository
    {
        public AcademicregulationparameterRepository(CoreDbContext context):base(context) { }
        
    }
}
