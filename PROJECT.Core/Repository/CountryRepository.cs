using PROJECT.Core.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PROJECT.Core.Utility;


namespace PROJECT.Core.Repository
{
    public class CountryRepository : Base
    {
        const string SP_COUNTRY_MODEL_SELECT = "sps_CountryModelSelect";




        const string PARAM_COUNTRYID = "CountryID";

        const string PARAM_COUNTRYNAME = "CountryName";
        const string PARAM_COUNTRYSTATUS = "CountryStatus";

        public CountryModel Insert(CountryModel objEntity)
        {
            throw new NotImplementedException();
        }

        public CountryModel Update(int flag, CountryModel objEntity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int flag, CountryModel objEntity)
        {
            throw new NotImplementedException();
        }

        public List<CountryModel> Select(int flag, CountryModel objEntity)
        {
            var objEntityList = new List<CountryModel>();
           
            try
            {


                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_COUNTRY_MODEL_SELECT))
                {
                    objDB.AddInParameter(sprocCmd, "Flag", DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, PARAM_COUNTRYID, DbType.Int32, objEntity.CountryID);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {

                        while (reader.Read())
                        {
                            var objEntityViewModel =
                                new CountryModel()
                                {

                                    CountryID =reader.GetColumnValue<int>(PARAM_COUNTRYID),

                                   // reader.GetInt32(reader.GetOrdinal(PARAM_COUNTRYID)),
                                    CountryName = reader.GetString(reader.GetOrdinal(PARAM_COUNTRYNAME)),

                                    CountryStatus = reader.GetInt32(reader.GetOrdinal(PARAM_COUNTRYSTATUS))


                                };
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
