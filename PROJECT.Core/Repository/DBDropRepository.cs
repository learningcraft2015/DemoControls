using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PROJECT.Core.Utility;
using PROJECT.Core.Model.ViewModel;



namespace PROJECT.Core.Repository
{
    public class DBDroupRepository : Base
    {
        private const string SPS_STUDENT_VIEWMODEL_SELECT = "sps_StudentViewModelSelect";


        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_FLAG = "Flag";

        public List<DBDropViewModel> FillDBDrop(int Flag, DBDropViewModel objEntity)
        {
            var objEntityList = new List<DBDropViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT_VIEWMODEL_SELECT))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ID, DbType.Int32, objEntity.Id);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new DBDropViewModel();


                            objEntityViewModel.Id = reader.GetColumnValue<int>(COLUMN_NAME_ID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);





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
