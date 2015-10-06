using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Repository
{
    public class FileUpRepository : Base
    {
        const string SP_FileUpViewModelInsert = "sps_FileUpViewModelInsert";


        const string PARAM_Id = "Id";

        const string PARAM_FileName = "FileName";

        const string PARAM_Result = "Result";


        public FileUpViewModel Insert(FileUpViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_FileUpViewModelInsert))
                {




                    objDB.AddInParameter(sprocCmd, PARAM_FileName, DbType.String, objEntity.FileName);



                    objDB.AddOutParameter(sprocCmd, PARAM_Id, DbType.Int16, objEntity.Id);

                    objDB.AddOutParameter(sprocCmd, PARAM_Result, DbType.Int32, objEntity.Result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.Id = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_Id));
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_Result));
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
    }
}
