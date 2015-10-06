using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECT.Core.Utility;

namespace PROJECT.Core.Repository
{

    public class StudentSearchReportRepository : Base
    {

        private const string SPS_STUDENT_VIEWMODEL_REPORT = "sps_StudentViewModelReport";

        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_AGE = "Age";
        private const string COLUMN_NAME_DOB = "DOB";
        private const string COLUMN_NAME_GENDER = "GENDER";


        private const string COLUMN_NAME_RESULT = "Result";
        private const string COLUMN_NAME_FLAG = "Flag";

        private const string COLUMN_NAME_STARTDATE = "StartDate";
        private const string COLUMN_NAME_ENDDATE = "EndDate";
        private const string COLUMN_NAME_TOTALCOUNT = "TotalCount";


        public List<StudentSearchReportViewModel> Search(int flag, StudentSearchReportViewModel entity)
        {

            var objEntityList = new List<StudentSearchReportViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT_VIEWMODEL_REPORT))
                {

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.String, flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STARTDATE, DbType.DateTime, entity.StartDate);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ENDDATE, DbType.DateTime, entity.EndDate);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new StudentSearchReportViewModel();


                            objEntityViewModel.Id = reader.GetColumnValue<int>(COLUMN_NAME_ID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);

                            objEntityViewModel.Age = reader.GetColumnValue<int>(COLUMN_NAME_AGE);
                            objEntityViewModel.DOB = reader.GetColumnValue<DateTime>(COLUMN_NAME_DOB);
                            objEntityViewModel.Gender = reader.GetColumnValue<GenderEnum>(COLUMN_NAME_GENDER);


                            if (objEntityViewModel != null)
                            {
                                objEntityList.Add(objEntityViewModel);
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return objEntityList;
        }
    }
}
