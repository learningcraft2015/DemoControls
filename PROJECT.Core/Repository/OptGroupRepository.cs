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


    public class OptGroupRepository : Base
    {
        const string SP_StateOptionSelectViewModelSelect = "sps_StateOptionSelectViewModelSelect";


        const string PARAM_Flag = "Flag";
        const string PARAM_CountryId = "CountryId";
        const string PARAM_CountryName = "CountryName";
        const string PARAM_StateId = "StateId";
        const string PARAM_Name = "Name";

        public List<OptGroupViewModel> OptGroupSelect(int flag)
        {

            var objEntityList = new List<OptGroupViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_StateOptionSelectViewModelSelect))
                {

                    objDB.AddInParameter(sprocCmd, PARAM_Flag, DbType.Int32, flag);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new OptGroupViewModel();


                            objEntityViewModel.CountryId = reader.GetColumnValue<int>(PARAM_CountryId);
                            objEntityViewModel.CountryName = reader.GetColumnValue<string>(PARAM_CountryName);
                            objEntityViewModel.StateId = reader.GetColumnValue<int>(PARAM_StateId);
                            objEntityViewModel.StateName = reader.GetColumnValue<string>(PARAM_Name);




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
