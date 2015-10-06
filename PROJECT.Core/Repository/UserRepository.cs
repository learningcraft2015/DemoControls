using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PROJECT.Core.Repository;
using PROJECT.Core.Models.ViewModels;



namespace PROJECT.Core.Repository
{
    public class UserRepository : Base
    {

        const string sp_UserViewModelSelect = "sps_UserViewModelSelect";
        const string sp_UserViewModelUpdate = "sps_UserViewModelUpdate";

        const string PARAM_UserId = "UserId";
        const string PARAM_UserEmail = "UserEmail";
        const string PARAM_Password = "Password";
        const string PARAM_OldPassword = "OldPassword";

        const string PARAM_UserStatus = "UserStatus";

        const string PARAM_UserTypeId = "UserTypeId";

        const string PARAM_Result = "Result";
        const string PARAM_Flag = "Flag";
        public List<UserViewModel> Select(int flag, UserViewModel entity)
        {
            var objEntityList = new List<UserViewModel>();

            try
            {


                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(sp_UserViewModelSelect))
                {
                    objDB.AddInParameter(sprocCmd, "Flag", DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, "UserId", DbType.Int32, entity.UserId);
                    objDB.AddInParameter(sprocCmd, "UserEmail", DbType.String, entity.UserEmail);
                    objDB.AddInParameter(sprocCmd, "Password", DbType.String, entity.Password);
                    objDB.AddInParameter(sprocCmd, "UserTypeId", DbType.Int32, entity.UserTypeId);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {

                        while (reader.Read())
                        {
                            var objEntity =
                                new UserViewModel()
                                {
                                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                    UserTypeId = reader.GetInt32(reader.GetOrdinal("UserTypeId")),
                                    UserEmail = reader.GetString(reader.GetOrdinal("UserEmail")),
                                    UserCreatedDate = reader.GetDateTime(reader.GetOrdinal("UserCreatedDate")),
                                    UserStatus = reader.GetInt32(reader.GetOrdinal("UserStatus")),
                                };
                            if (objEntity != null)
                            {
                                objEntityList.Add(objEntity);
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


        public UserViewModel Update(int flag, UserViewModel objEntity)
        {
            try
            {
                //
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(sp_UserViewModelUpdate))
                {

                    objDB.AddInParameter(sprocCmd, PARAM_Flag, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, PARAM_UserId, DbType.Int32, objEntity.UserId);
                    objDB.AddInParameter(sprocCmd, PARAM_UserEmail, DbType.String, objEntity.UserEmail);
                    objDB.AddInParameter(sprocCmd, PARAM_OldPassword, DbType.String, objEntity.OldPassword);
                    objDB.AddInParameter(sprocCmd, PARAM_Password, DbType.String, objEntity.Password);
                    objDB.AddInParameter(sprocCmd, PARAM_UserTypeId, DbType.Int32, objEntity.UserTypeId);
                    objDB.AddInParameter(sprocCmd, PARAM_UserStatus, DbType.Int32, objEntity.UserStatus);
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
    



    



