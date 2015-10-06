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

    public class StudentSearchRepository : Base
    {

        private const string SPS_STUDENT_VIEWMODEL_SEARCH = "sps_StudentViewModelKeywordSearch";

        private const string SPS_STUDENT_VIEWMODEL_SEARCHWITHOUTPAGING = "sps_StudentViewModelKeywordSearchWithOutPaging";


        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_KEYWORD = "Keyword";

        private const string COLUMN_NAME_AGE = "Age";
        private const string COLUMN_NAME_DOB = "DOB";
        private const string COLUMN_NAME_GENDER = "GENDER";


        private const string COLUMN_NAME_RESULT = "Result";
        private const string COLUMN_NAME_FLAG = "Flag";

        private const string COLUMN_NAME_PAGEINDEX = "pageIndex";
        private const string COLUMN_NAME_PAGESIZE = "pageSize";
        private const string COLUMN_NAME_TOTALCOUNT = "totalCount";


        public List<StudentSearchViewModel> Search(int flag, StudentSearchViewModel entity, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;
            var objEntityList = new List<StudentSearchViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT_VIEWMODEL_SEARCH))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_KEYWORD, DbType.String, entity.Keyword);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PAGEINDEX, DbType.Int32, pageIndex);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PAGESIZE, DbType.Int32, pageSize);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_TOTALCOUNT, DbType.Int32, totalCount);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new StudentSearchViewModel();


                            objEntityViewModel.Id = reader.GetColumnValue<int>(COLUMN_NAME_ID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);

                            objEntityViewModel.Age = reader.GetColumnValue<int>(COLUMN_NAME_AGE);
                            //objEntityViewModel.DOB = reader.GetColumnValue<DateTime>(COLUMN_NAME_DOB);
                            objEntityViewModel.Gender = reader.GetColumnValue<GenderEnum>(COLUMN_NAME_GENDER);


                            if (objEntityViewModel != null)
                            {
                                objEntityList.Add(objEntityViewModel);
                            }
                        }
                    }

                    totalCount = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_TOTALCOUNT));
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


        public List<StudentSearchViewModel> Search(int flag, StudentSearchViewModel objEntity)
        {

            var objEntityList = new List<StudentSearchViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT_VIEWMODEL_SEARCHWITHOUTPAGING))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.String, flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_KEYWORD, DbType.String, objEntity.Keyword);



                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new StudentSearchViewModel();


                            objEntityViewModel.Id = reader.GetColumnValue<int>(COLUMN_NAME_ID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);

                            objEntityViewModel.Age = reader.GetColumnValue<int>(COLUMN_NAME_AGE);

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
