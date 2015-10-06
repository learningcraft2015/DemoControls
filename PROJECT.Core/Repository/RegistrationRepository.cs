using PROJECT.Core.Models.ViewModels;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Repository
{
    public class RegistrationRepository : Base
    {
        const string SP_RegistrationViewModelInsert = "sps_RegistrationViewModelInsert";
        const string SP_RegistrationViewModelSelect = "sps_RegistrationViewModelSelect";
        const string SP_RegistrationViewModelDelete = "sps_RegistrationViewModelDelete";
        const string SP_RegistrationViewModelUpdate = "sps_RegistrationViewModelUpdate";

        const string PARAM_Flag = "Flag";
        const string PARAM_RegistrationId = "RegistrationId";
        const string PARAM_UserId = "UserId";
        const string PARAM_UserTypeID = "UserTypeId";
        const string PARAM_Name = "Name";
        
        const string PARAM_DateOfBirth = "DateOfBirth";
        const string PARAM_Gender = "Gender";
     
        const string PARAM_City = "City";
        const string PARAM_MobileNumber = "MobileNumber";
        const string PARAM_Email = "UserEmail";
        const string PARAM_Password = "Password";
        const string PARAM_Result = "Result";
        const string PARAM_Status = "Status";

        const string PARAM_DepartmentId = "DepartmentId";
        const string PARAM_SemesterId = "SemesterId";
        const string PARAM_StartAcademicYear = "StartAcademicYear";
        const string PARAM_EndAcademicYear = "EndAcademicYear";

      

        public RegistrationViewModel Insert(RegistrationViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();

                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_RegistrationViewModelInsert))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_UserId, DbType.Int32, objEntity.UserId);
                    objDB.AddInParameter(sprocCmd, PARAM_UserTypeID, DbType.Int32, objEntity.UserTypeId);
                    objDB.AddInParameter(sprocCmd, PARAM_Name, DbType.String, objEntity.Name);
                   
                    objDB.AddInParameter(sprocCmd, PARAM_DateOfBirth, DbType.DateTime, objEntity.DateOfBirth);
                    objDB.AddInParameter(sprocCmd, PARAM_Gender, DbType.Int32, objEntity.Gender.GetHashCode());
                 
                    objDB.AddInParameter(sprocCmd, PARAM_City, DbType.String, objEntity.City);
                    objDB.AddInParameter(sprocCmd, PARAM_Email, DbType.String, objEntity.UserEmail);
                    objDB.AddInParameter(sprocCmd, PARAM_Password, DbType.String, objEntity.Password);
                    objDB.AddInParameter(sprocCmd, PARAM_MobileNumber, DbType.String, objEntity.MobileNumber);
                    objDB.AddInParameter(sprocCmd, PARAM_Status, DbType.Int32, objEntity.Status);




                    objDB.AddOutParameter(sprocCmd, PARAM_RegistrationId, DbType.Int32, objEntity.RegistrationId);
                    objDB.AddOutParameter(sprocCmd, PARAM_Result, DbType.Int32, objEntity.Result);


                    objDB.ExecuteNonQuery(sprocCmd);

                    objEntity.RegistrationId = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_RegistrationId));
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_Result));


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntity;
        }

        public List<RegistrationViewModel> Select(int flag, RegistrationViewModel objEntity)
        {
            var objEntityList = new List<RegistrationViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_RegistrationViewModelSelect))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_Flag, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, PARAM_RegistrationId, DbType.Int32, objEntity.RegistrationId);
                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new RegistrationViewModel();


                            objEntityViewModel.RegistrationId = reader.GetInt32(reader.GetOrdinal(PARAM_RegistrationId));
                                 //  objEntityViewModel.UserId = reader.GetInt32(reader.GetOrdinal(PARAM_UserId));
                                   objEntityViewModel.UserId = reader.IsDBNull(reader.GetOrdinal(PARAM_UserId)) ? 0: reader.GetInt32(reader.GetOrdinal(PARAM_UserId));
                                    objEntityViewModel.UserTypeId = reader.GetInt32(reader.GetOrdinal(PARAM_UserTypeID));
                                    objEntityViewModel.Name = reader.GetString(reader.GetOrdinal(PARAM_Name));
                                  
                                    objEntityViewModel.DateOfBirth = reader.GetDateTime(reader.GetOrdinal(PARAM_DateOfBirth));
                                    objEntityViewModel.Gender = (GenderEnum)reader.GetInt32(reader.GetOrdinal(PARAM_Gender));
                                   
                                    objEntityViewModel.City = reader.IsDBNull(reader.GetOrdinal(PARAM_City)) ? string.Empty : reader.GetString(reader.GetOrdinal(PARAM_City));
                                    
                                    objEntityViewModel.MobileNumber = reader.GetString(reader.GetOrdinal(PARAM_MobileNumber));
                                    objEntityViewModel.UserEmail = reader.GetString(reader.GetOrdinal(PARAM_Email));
                                   

                                
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


        public int Delete(int flag, RegistrationViewModel objEntity)
        {
            int result = 0;
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_RegistrationViewModelDelete))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_Flag, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, PARAM_RegistrationId, DbType.Int32, objEntity.RegistrationId);
                    objDB.AddOutParameter(sprocCmd, PARAM_Result, DbType.Int32, result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_Result));
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


        public RegistrationViewModel Update(int flag, RegistrationViewModel objEntity)
        {
            try
            {
                //
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_RegistrationViewModelUpdate))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_Flag, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, PARAM_RegistrationId, DbType.Int32, objEntity.RegistrationId);

                    objDB.AddInParameter(sprocCmd, PARAM_UserId, DbType.Int32, objEntity.UserId);
                    objDB.AddInParameter(sprocCmd, PARAM_Name, DbType.String, objEntity.Name);
                    

                    objDB.AddInParameter(sprocCmd, PARAM_DateOfBirth, DbType.String, objEntity.DateOfBirth);
                    objDB.AddInParameter(sprocCmd, PARAM_Gender, DbType.Int32, objEntity.Gender);
                  
                    objDB.AddInParameter(sprocCmd, PARAM_City, DbType.String, objEntity.City);
                    objDB.AddInParameter(sprocCmd, PARAM_MobileNumber, DbType.String, objEntity.MobileNumber);


                    objDB.AddOutParameter(sprocCmd, PARAM_Result, DbType.Int32, objEntity.Result);

                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_Result));
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
    }
}
