using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PROJECT.Core.Utility;



namespace PROJECT.Core.Repository
{
    public class StudentRepository : Base
    {
        private const string SPS_STUDENT_VIEWMODEL_SELECT = "sps_StudentViewModelSelect";
        private const string SPS_STUDENT_VIEWMODEL_INSERT = "sps_StudentViewModelInsert";
        private const string SPS_STUDENT_VIEWMODEL_UPDATE = "sps_StudentViewModelUpdate";
        private const string SPS_STUDENT_VIEWMODEL_DELETE = "sps_StudentViewModelDelete";
        private const string SPS_STUDENT_VIEWMODEL_SEARCH = "sps_StudentViewModelSearch";

        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_AGE = "Age";

        private const string COLUMN_NAME_RESULT = "Result";
        private const string COLUMN_NAME_FLAG = "Flag";

        private const string COLUMN_NAME_PAGEINDEX = "pageIndex";
        private const string COLUMN_NAME_PAGESIZE = "pageSize";
        private const string COLUMN_NAME_TOTALCOUNT = "totalCount";

        public List<StudentViewModel> Select(int Flag, StudentViewModel objEntity)
        {
            var objEntityList = new List<StudentViewModel>();
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
                            var objEntityViewModel = new StudentViewModel();


                            objEntityViewModel.Id = reader.GetColumnValue<int>(COLUMN_NAME_ID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);
                            objEntityViewModel.Age = reader.GetColumnValue<int>(COLUMN_NAME_AGE);




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
        public StudentViewModel Edit(int Flag, StudentViewModel objEntity)
        {
            try
            {

                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT_VIEWMODEL_UPDATE))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ID, DbType.Int32, objEntity.Id);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_NAME, DbType.String, objEntity.Name);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_AGE, DbType.Int32, objEntity.Age);



                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
                }
                //
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return objEntity;
        }
        public StudentViewModel Insert(StudentViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT_VIEWMODEL_INSERT))
                {

                    
                  
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_NAME, DbType.String, objEntity.Name);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_AGE, DbType.Int32, objEntity.Age);



                   objDB.AddOutParameter(sprocCmd, COLUMN_NAME_ID, DbType.Int16, objEntity.Id);
                    
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.Id = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_ID));
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return objEntity;
        }
        public int Delete(int Flag, StudentViewModel objEntity)
        {
            int result = 0;
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT_VIEWMODEL_DELETE))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ID, DbType.Int32, objEntity.Id);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return result;
        }

        public List<StudentViewModel> Search(int flag, StudentViewModel entity, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;
            var objEntityList = new List<StudentViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT_VIEWMODEL_SEARCH))
                {

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PAGEINDEX, DbType.Int32, pageIndex);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PAGESIZE, DbType.Int32, pageSize);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_TOTALCOUNT, DbType.Int32, totalCount);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new StudentViewModel();


                            objEntityViewModel.Id = reader.GetColumnValue<int>(COLUMN_NAME_ID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);                           
                            objEntityViewModel.Age = reader.GetColumnValue<int>(COLUMN_NAME_AGE);
                            

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


    }
}
