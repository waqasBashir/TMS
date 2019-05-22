﻿using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.Interfaces.TMS;
using TMS.Web.Controllers;
using Microsoft.Reporting.WebForms;
using Castle.MicroKernel;
using TMS.Business.Common.DDL;
using TMS.Business.TMS;
using System;
using TMS.Business.TMS.Program;
using System.Globalization;

namespace TMS.Web.Views.Report.User_Controls
{
    public partial class UCClassReport : System.Web.UI.UserControl
    {
        public readonly IDDLBAL _objIDDLBAL = null;//For the Resorces Table Interface
                                                   // private readonly IPersonBAL _PersonBAL;
        private static DataTable _GetTrainerDetailsForReports;
        DDLBAL ddl = new DDLBAL();
        PersonBAL _CourseBAL = new PersonBAL();
        long CompanyID = 0;
        public string CurrentCulture
        {
            get
            {
                return CultureInfo.CurrentUICulture.ToString().ToLower();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 CompanyID = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);

                BindDropDowns();
            }
        }
     

               //public UCTrainerDetailsReport(IDDLBAL ObjDDLBAL, IPersonBAL person)
        //{

        //    _objIDDLBAL = ObjDDLBAL;
        //    _PersonBAL = person;

        //}

        private void BindDropDowns()
        {
            try
            {

                DropDownUtil.FillDropDown(DdlCourse, ddl.CourseDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Course");
                DropDownUtil.FillDropDown(DdlClass, ddl.ClassDDLBAL(CurrentCulture, CompanyID), "Text", "Value", "Class");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void DdlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClassesGetByCourseID();
            }
            catch (Exception)
            {
            }
            // AppContext.TimeTableClassID = null;
            // AppContext.TimeTableCourseID = UtilityFunctions.MapValue<Int64>(DdlCourse.SelectedValue, typeof(long)); ;

            // LoadClassDetailReport();

        }
        protected void DdlClass_SelectedIndexChanged(object Sender, EventArgs e)
        {
            //try
            //{
            if (DdlClass.SelectedIndex > 0)
            { LoadTraineeDetailReport(); }
            else
            {
                //ReportViewer1.ClearReport();
            }
            //}
            //catch (Exception)
            //{
            //}

        }


        private void ClassesGetByCourseID()
        {
            try
            {
                if (DdlCourse.SelectedIndex > 0)
                {
                    DropDownUtil.FillDropDown(DdlClass, ddl.Course_ClassDDLBAL(CurrentCulture, CompanyID, Convert.ToInt64(DdlCourse.SelectedValue)), "Text", "Value", "Class");
                }
                else
                {
                    BindDropDowns();
                    // UCReport.ClearReport();
                }
            }
            catch (Exception)
            {

            }
        }
        public DataTable GetTrainerDetailsForReports
        {
            get
            {
                return _GetTrainerDetailsForReports ??
                       (_GetTrainerDetailsForReports = _CourseBAL.GetClassDetailReportData(Convert.ToInt64(DdlClass.SelectedValue),
                               Convert.ToInt64(DdlCourse.SelectedValue)));
            }
            set { _GetTrainerDetailsForReports = value; }
        }
        private void LoadTraineeDetailReport()
        {
            // try
            // {
            //  btnPrint.Visible = true;
            //    DataSet ds = new DataSet();
            DataTable ds = GetTrainerDetailsForReports;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource RDS1 = new ReportDataSource("Tran_Classes_GetClassDetailsForReport", ds);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.ReportEmbeddedResource = "~/Report/Tran_ClassDetailReport.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(RDS1);

            //check for Print option
            //  UCReport.IsPrintable = canPrint;

            //ReportViewer1.DynamicReportDataSource = ds;

            //UCReport.DynamicDataSetName = "Tran_Person_GetTrainerDetailReport";
            //UCReport.DynamicReportPath = "~/Reports/Tran_TrainerDetailReport.rdlc";
            //UCReport.LoadReport();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        /// <summary>
        /// <para>Description:
        /// This Method will get Trainer of Class by ClassID and Rebind Venues DropDown</para> 
        /// <para>Created By: Majid ali </para> 
        /// <para>Created Date: 9/26/2013 </para> 
        /// </summary>
        //private void TrainerGetbyClassID()
        //{
        //    if (DdlClass.SelectedIndex > 0)
        //    {
        //        DropDownUtil.FillDropDown(DdlTrainer, ddl.Class_TrainerDDLBAL(CurrentCulture, CompanyID, Convert.ToInt64(DdlClass.SelectedValue)), "Text", "Value", "Trainer");

        //        // _objIDDLBAL.Class_TrainerDDLBAL(CurrentCulture, CurrentUser.CompanyID, Convert.ToInt64(DdlClass.SelectedValue));
        //        //  LoadTraineeDetailReport();
        //    }
        //    else
        //    {
        //        BindDropDowns();
        //        //UCReport.ClearReport();
        //    }
        //}
    }
}