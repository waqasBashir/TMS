﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS.Exams;
using TMS.Library.TMS.CourseRelatedExam;

using TMS.Library.Common.Address;
using TMS.Library.TMS.Organization;
using TMS.Library.TMS.Organization.POC;

namespace TMS.DataObjects.TMS.Exams
{
    public class ExamsDAL : DBGenerics,IExamsDAL
    {
        public IList<CourseRelatedExamModel> GetAllOrganizationDAL()
        {
            return ExecuteListSp<CourseRelatedExamModel>("TMS_CourseRelatedExams_GetAll");
        }




        ///// <summary>
        ///// Organization the allby culture dal.
        ///// </summary>
        ///// <param name="culture">The culture.</param>
        ///// <returns>IList&lt;DDlList&gt;.</returns>
        //public IList<DDlList> OrganizationAllbyCultureDAL(string culture)
        //{
        //    return ExecuteListSp<DDlList>("Organizations_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        //}


        ///// <summary>
        ///// Gets the organization by identifier dal.
        ///// </summary>
        ///// <param name="Id">The identifier.</param>
        ///// <returns>OrganizationModel.</returns>
        //public OrganizationModel GetOrganizationByIdDAL(long Id)
        //{
        //    return ExecuteSinglewithSP<OrganizationModel>("TMS_Organizations_GetbyId", ParamBuilder.Par("ID", Id));
        //}

        ///// <summary>
        ///// Organization the create dal.
        ///// </summary>
        ///// <param name="_Organization">The organization.</param>
        ///// <returns>System.Int64.</returns>
        //public long Organizations_CreateDAL(OrganizationModel _Organization)
        //{
        //    var parameters = new[] { ParamBuilder.Par("ID", 0) };
        //    return ExecuteInt64withOutPutparameterSp("TMS_Organizations_Create", parameters,
        //                        ParamBuilder.Par("P_Name", _Organization.P_Name),
        //                        ParamBuilder.Par("S_Name", _Organization.S_Name),
        //                        ParamBuilder.Par("CompanyID", _Organization.CompanyID),
        //                        ParamBuilder.Par("PhoneNumber", _Organization.PhoneNumber),
        //                        ParamBuilder.Par("Website", _Organization.Website),
        //                        ParamBuilder.Par("Email", _Organization.Email),
        //                        ParamBuilder.Par("FaxNumber", _Organization.FaxNumber),
        //                        ParamBuilder.Par("Type", _Organization.Type),
        //                        ParamBuilder.Par("PointofContactName", _Organization.PointofContactName),
        //                        ParamBuilder.Par("PointofContactTitle", _Organization.PointofContactTitle),
        //                        ParamBuilder.Par("PointofContactEmail", _Organization.PointofContactEmail),
        //                        ParamBuilder.Par("PointofContactFax", _Organization.PointofContactFax),
        //                        ParamBuilder.Par("PointofContactPhoneNumber", _Organization.PointofContactPhoneNumber),
        //                        ParamBuilder.Par("BusinessType", _Organization.BusinessType),
        //                        ParamBuilder.Par("BusinessScope", _Organization.BusinessScope),
        //                        ParamBuilder.Par("Description", _Organization.Description),
        //                        ParamBuilder.Par("AttachmentID", _Organization.AttachmentID),
        //                        ParamBuilder.Par("FullName", _Organization.FullName),
        //                        ParamBuilder.Par("ShortName", _Organization.ShortName),
        //                        ParamBuilder.Par("Logo", _Organization.Logo),
        //                        ParamBuilder.Par("HandledBy", _Organization.HandledBy),
        //                        ParamBuilder.Par("Alias", _Organization.Alias),
        //                        ParamBuilder.Par("CreatedBy", _Organization.CreatedBy),
        //                        ParamBuilder.Par("CreatedDate", _Organization.CreatedDate),
        //                         ParamBuilder.Par("Country", _Organization.Country));
        //}

        ///// <summary>
        ///// Organization the update dal.
        ///// </summary>
        ///// <param name="_Organization">The organization.</param>
        ///// <returns>System.Int32.</returns>
        //public int Organizations_UpdateDAL(OrganizationModel _Organization)
        //{
        //    return ExecuteScalarInt32Sp("TMS_Organizations_Update",
        //                ParamBuilder.Par("ID", _Organization.ID),
        //                ParamBuilder.Par("P_Name", _Organization.P_Name),
        //                ParamBuilder.Par("S_Name", _Organization.S_Name),
        //                ParamBuilder.Par("CompanyID", _Organization.CompanyID),
        //                ParamBuilder.Par("PhoneNumber", _Organization.PhoneNumber),
        //                ParamBuilder.Par("Website", _Organization.Website),
        //                ParamBuilder.Par("Email", _Organization.Email),
        //                ParamBuilder.Par("FaxNumber", _Organization.FaxNumber),
        //                ParamBuilder.Par("Type", _Organization.Type),
        //                ParamBuilder.Par("PointofContactName", _Organization.PointofContactName),
        //                ParamBuilder.Par("PointofContactTitle", _Organization.PointofContactTitle),
        //                ParamBuilder.Par("PointofContactEmail", _Organization.PointofContactEmail),
        //                ParamBuilder.Par("PointofContactFax", _Organization.PointofContactFax),
        //                ParamBuilder.Par("PointofContactPhoneNumber", _Organization.PointofContactPhoneNumber),
        //                ParamBuilder.Par("BusinessType", _Organization.BusinessType),
        //                ParamBuilder.Par("BusinessScope", _Organization.BusinessScope),
        //                ParamBuilder.Par("Description", _Organization.Description),
        //                ParamBuilder.Par("AttachmentID", _Organization.AttachmentID),
        //                ParamBuilder.Par("FullName", _Organization.FullName),
        //                ParamBuilder.Par("ShortName", _Organization.ShortName),
        //                ParamBuilder.Par("Logo", _Organization.Logo),
        //                ParamBuilder.Par("HandledBy", _Organization.HandledBy),
        //                ParamBuilder.Par("Alias", _Organization.Alias),
        //                ParamBuilder.Par("UpdatedBy", _Organization.UpdatedBy),
        //                ParamBuilder.Par("UpdatedDate", _Organization.UpdatedDate),
        //                ParamBuilder.Par("Country", _Organization.Country)
        //    );
        //}

        ///// <summary>
        ///// Organization the delete dal.
        ///// </summary>
        ///// <param name="_Organization">The organization.</param>
        ///// <returns>System.Int32.</returns>
        //public int Organizations_DeleteDAL(OrganizationModel _Organization)
        //{
        //    return ExecuteScalarInt32Sp("TMS_Organizations_Delete",
        //                ParamBuilder.Par("ID", _Organization.ID),
        //                ParamBuilder.Par("UpdatedBy", _Organization.UpdatedBy),
        //                ParamBuilder.Par("UpdatedDate", _Organization.UpdatedDate)
        //    );
        //}

        ///// <summary>
        ///// Organizations the attachment mapping create.
        ///// </summary>
        ///// <param name="_Organization">The organization.</param>
        ///// <returns>System.Int64.</returns>
        //public long OrganizationAttachmentMapping_Create(OrganizationModel _Organization)
        //{
        //    return ExecuteScalarInt32Sp("TMS_OrganizationAttachmentMapping_Create",
        //                ParamBuilder.Par("ID", _Organization.ID),
        //                ParamBuilder.Par("UpdatedBy", _Organization.UpdatedBy),
        //                ParamBuilder.Par("UpdatedDate", _Organization.UpdatedDate)
        //    );
        //}

        //#region "Point of Contact"
        ///// <summary>
        ///// Gets the point of contact by organization identifier dal.
        ///// </summary>
        ///// <param name="Id">The identifier.</param>
        ///// <returns>IList&lt;PointsOfContact&gt;.</returns>
        //public IList<PointsOfContact> GetPointOfContactByOrganizationIdDAL(long Id)
        //{
        //    return ExecuteListSp<PointsOfContact>("TMS_OrganizationRelationToPerson_GetbyOrganizationId", ParamBuilder.Par("ID", Id));
        //}

        ///// <summary>
        ///// Points the of contact create dal.
        ///// </summary>
        ///// <param name="_OrganizationRelation">The organization relation.</param>
        ///// <returns>System.Int64.</returns>
        //public long PointOfContact_CreateDAL(PointsOfContact _OrganizationRelation)
        //{
        //    var parameters = new[] { ParamBuilder.Par("ID", 0) };
        //    return ExecuteInt64withOutPutparameterSp("TMS_OrganizationRelationToPerson_Create", parameters,
        //                        ParamBuilder.Par("OrganizationID", _OrganizationRelation.OrganizationID),
        //                        ParamBuilder.Par("PersonID", _OrganizationRelation.PersonID),
        //                        ParamBuilder.Par("RelationID", _OrganizationRelation.RelationID),
        //                        ParamBuilder.Par("IsPrimary", _OrganizationRelation.IsPrimary),
        //                        ParamBuilder.Par("CreatedDate", _OrganizationRelation.CreatedDate),
        //                        ParamBuilder.Par("CreatedBy", _OrganizationRelation.CreatedBy)
        //                        );
        //}

        ///// <summary>
        ///// Points the of contact update dal.
        ///// </summary>
        ///// <param name="_OrganizationRelation">The organization relation.</param>
        ///// <returns>System.Int32.</returns>
        //public int PointOfContact_UpdateDAL(PointsOfContact _OrganizationRelation)
        //{
        //    return ExecuteScalarInt32Sp("TMS_OrganizationRelationToPerson_Update",
        //                        ParamBuilder.Par("ID", _OrganizationRelation.ID),
        //                        ParamBuilder.Par("OrganizationID", _OrganizationRelation.OrganizationID),
        //                        ParamBuilder.Par("PersonID", _OrganizationRelation.PersonID),
        //                        ParamBuilder.Par("RelationID", _OrganizationRelation.RelationID),
        //                        ParamBuilder.Par("IsPrimary", _OrganizationRelation.IsPrimary),
        //                        ParamBuilder.Par("UpdatedBy", _OrganizationRelation.UpdatedBy),
        //                        ParamBuilder.Par("UpdatedDate", _OrganizationRelation.UpdatedDate)
        //    );
        //}

        ///// <summary>
        ///// Points the of contact delete dal.
        ///// </summary>
        ///// <param name="_OrganizationRelation">The organization relation.</param>
        ///// <returns>System.Int32.</returns>
        //public int PointOfContact_DeleteDAL(PointsOfContact _OrganizationRelation)
        //{
        //    return ExecuteScalarInt32Sp("TMS_OrganizationRelationToPerson_Delete",
        //                        ParamBuilder.Par("ID", _OrganizationRelation.ID),
        //                        ParamBuilder.Par("OrganizationID", _OrganizationRelation.OrganizationID),
        //                        ParamBuilder.Par("UpdatedBy", _OrganizationRelation.UpdatedBy),
        //                        ParamBuilder.Par("UpdatedDate", _OrganizationRelation.UpdatedDate)
        //    );
        //}
        ///// <summary>
        ///// Points the of contact duplication check dal.
        ///// </summary>
        ///// <param name="_OrganizationRelation">The organization relation.</param>
        ///// <returns>System.Int32.</returns>
        //public int PointOfContact_DuplicationCheckDAL(PointsOfContact _OrganizationRelation)
        //{
        //    return ExecuteScalarSPInt32("TMS_OrganizationRelationToPerson_DuplicationCheck",
        //                        ParamBuilder.Par("PersonID", _OrganizationRelation.PersonID),
        //                        ParamBuilder.Par("OrganizationId", _OrganizationRelation.OrganizationID)
        //    );
        //}

        //#endregion "Point of Contact"

        //#region"Link"
        ///// <summary>
        ///// Organizations the links getby organization identifier.
        ///// </summary>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns>IList&lt;Links&gt;.</returns>
        //public IList<Links> OrganizationLinks_GetbyOrganizationId(long OrganizationId)
        //{
        //    return ExecuteListSp<Links>("TMS_OrganizationLinks_GetbyOrganizationID", ParamBuilder.Par("OrganizationID", OrganizationId));
        //}

        ///// <summary>
        ///// Organizations the links create dal.
        ///// </summary>
        ///// <param name="_objLinks">The object links.</param>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns>System.Int64.</returns>
        //public long OrganizationLinks_CreateDAL(Links _objLinks, long OrganizationId)
        //{
        //    var parameters = new[] { ParamBuilder.Par("ID", 0) };
        //    return ExecuteInt64withOutPutparameterSp("TMS_OrganizationLinks_Create", parameters,
        //                ParamBuilder.Par("OrganizationID", OrganizationId),
        //                ParamBuilder.Par("Link", _objLinks.Link),
        //                ParamBuilder.Par("Description", _objLinks.Description),
        //                ParamBuilder.Par("LinkType", _objLinks.LinkType),
        //                ParamBuilder.Par("CreatedBy", _objLinks.CreatedBy),
        //                ParamBuilder.Par("CreatedDate", _objLinks.CreatedDate));
        //}

        ///// <summary>
        ///// Organizations the links update dal.
        ///// </summary>
        ///// <param name="_objLinks">The object links.</param>
        ///// <returns>System.Int32.</returns>
        //public int OrganizationLinks_UpdateDAL(Links _objLinks)
        //{
        //    return ExecuteScalarInt32Sp("TMS_Links_Update",
        //                ParamBuilder.Par("ID", _objLinks.ID),
        //                ParamBuilder.Par("Link", _objLinks.Link),
        //                ParamBuilder.Par("Description", _objLinks.Description),
        //                ParamBuilder.Par("LinkType", _objLinks.LinkType),
        //                ParamBuilder.Par("UpdatedBy", _objLinks.UpdatedBy),
        //                ParamBuilder.Par("UpdatedDate", _objLinks.UpdatedDate));
        //}

        ///// <summary>
        ///// Organizations the links delete dal.
        ///// </summary>
        ///// <param name="_objLinks">The object links.</param>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        //public bool OrganizationLinks_DeleteDAL(Links _objLinks, long OrganizationId)
        //{
        //    var parameters = new[] { ParamBuilder.Par("IsDeleted", false) };
        //    return ExecuteBoolwithOutPutparameterSp("TMS_OrganizationLinks_Delete", parameters,
        //            ParamBuilder.Par("LinkID", _objLinks.ID),
        //            ParamBuilder.Par("OrganizationID", OrganizationId),
        //            ParamBuilder.Par("UpdatedBy", _objLinks.UpdatedBy),
        //            ParamBuilder.Par("UpdatedDate", _objLinks.UpdatedDate));
        //}
        ///// <summary>
        ///// Organizations the links duplication check dal.
        ///// </summary>
        ///// <param name="_objLinks">The object links.</param>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns>System.Int32.</returns>
        //public int OrganizationLinks_DuplicationCheckDAL(Links _objLinks, long OrganizationId)
        //{
        //    return ExecuteScalarSPInt32("TMS_OrganizationLinks_DuplicationCheck",
        //            ParamBuilder.Par("Link", _objLinks.Link),
        //            ParamBuilder.Par("LinkType", _objLinks.LinkType),
        //            ParamBuilder.Par("OrganizationID", OrganizationId));
        //}
        ///// <summary>
        ///// Organizations the links get count by organization iddal.
        ///// </summary>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns>System.Int32.</returns>
        //public int OrganizationLinks_GetCountByOrganizationIDDAL(long OrganizationId)
        //{
        //    return ExecuteScalarSPInt32("TMS_OrganizationLinks_GetCountByOrganizationID",
        //            ParamBuilder.Par("OrganizationID", OrganizationId));
        //}
        //#endregion
    }
}
