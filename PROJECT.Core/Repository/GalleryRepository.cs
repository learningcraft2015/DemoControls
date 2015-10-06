using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Models.ViewModels;
using System;
using PROJECT.Core.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PROJECT.Core.Utility;

namespace PROJECT.Core.Repository
{
    public class GalleryRepository : Base
    {
        const string SP_GalleryViewModelInsert = "sps_GalleryViewModelInsert";
        const string SP_GalleryViewModelSelect = "sps_GalleryViewModelSelect";
        const string SP_GalleryViewModelUpdate = "sps_GalleryViewModelUpdate";

        private const string COLUMN_NAME_FLAG = "Flag";

        private const string COLUMN_NAME_PAGEINDEX = "pageIndex";
        private const string COLUMN_NAME_PAGESIZE = "pageSize";
        private const string COLUMN_NAME_TOTALCOUNT = "totalCount";

        const string PARAM_Id = "Id";
        const string PARAM_GalleryId = "GalleryId";

        const string PARAM_FileName = "FileName";
        const string PARAM_Flag = "flag";

        const string PARAM_Title = "Title";

        const string PARAM_Result = "Result";



        public GalleryViewModel Insert(GalleryViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_GalleryViewModelInsert))
                {




                    objDB.AddInParameter(sprocCmd, PARAM_FileName, DbType.String, objEntity.FileName);


                    objDB.AddInParameter(sprocCmd, PARAM_Title, DbType.String, objEntity.Title);


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
        public GalleryViewModel Edit(int Flag, GalleryViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_GalleryViewModelUpdate))
                {

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int16, Flag);


                    objDB.AddInParameter(sprocCmd, PARAM_GalleryId, DbType.Int16, objEntity.Id);

                    objDB.AddInParameter(sprocCmd, PARAM_FileName, DbType.String, objEntity.FileName);


                    objDB.AddInParameter(sprocCmd, PARAM_Title, DbType.String, objEntity.Title);




                    objDB.AddOutParameter(sprocCmd, PARAM_Result, DbType.Int32, objEntity.Result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.Id = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_GalleryId));
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


        public List<GalleryViewModel> Search(int flag, GalleryViewModel entity)
        {

            var objEntityList = new List<GalleryViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_GalleryViewModelSelect))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_Flag, DbType.Int32, flag);

                    objDB.AddInParameter(sprocCmd, PARAM_Id, DbType.Int32, entity.Id);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new GalleryViewModel();


                            objEntityViewModel.Id = reader.GetColumnValue<int>(PARAM_GalleryId);
                            objEntityViewModel.FileName = (reader.GetColumnValue<string>(PARAM_FileName));
                            objEntityViewModel.Title = reader.GetColumnValue<string>(PARAM_Title);


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
        public List<GalleryViewModel> Select(int Flag, GalleryViewModel objEntity)
        {

            var objEntityList = new List<GalleryViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_GalleryViewModelSelect))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_Flag, DbType.Int32, Flag);

                    objDB.AddInParameter(sprocCmd, PARAM_Id, DbType.Int32, objEntity.Id);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new GalleryViewModel();


                            objEntityViewModel.Id = reader.GetColumnValue<int>(PARAM_GalleryId);
                            objEntityViewModel.FileName = (reader.GetColumnValue<string>(PARAM_FileName));
                            objEntityViewModel.Title = reader.GetColumnValue<string>(PARAM_Title);


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
