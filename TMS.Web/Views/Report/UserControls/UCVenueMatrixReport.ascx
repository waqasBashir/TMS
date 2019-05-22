﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCVenueMatrixReport.ascx.cs" Inherits="TMS.Web.Views.Report.UserControls.UCVenueMatrixReport" %>


<asp:updatepanel runat="server" id="upEvents">
    <ContentTemplate>
        <fieldset>
            <div class="row">
      
            <div class="col-md-1">
                <strong>Year/Month</strong> 
              </div>
            <div class="col-md-2">
               
                    <asp:DropDownList runat="server" ID="ddlYear" class="dropdown form-control"  AutoPostBack="True"
                        OnSelectedIndexChanged="ddlVenues_SelectedIndexChanged" />
                </div>
                 <div class="col-md-3">
                    <asp:DropDownList runat="server" ID="ddlMonth" class="dropdown form-control"  AutoPostBack="True"
                        OnSelectedIndexChanged="ddlVenues_SelectedIndexChanged" />
                   </div>
            
        </div>
       
               <div class="row" style="margin-top: 10px">
      
            <div class="col-md-1">
        
                 <strong>Venue</strong>  
        
                </div>
                    <div class="col-md-5" id="classd">
                    <asp:DropDownList runat="server" ID="ddlVenues" class="dropdown form-control"  AutoPostBack="True"
                        OnSelectedIndexChanged="ddlVenues_SelectedIndexChanged" />
                  
               </div></div>
            <asp:Panel runat="server" ID="pnlReport" Visible="False">
               <%-- <a href='<%= UtilityFunctions.GetPageUrl("Page_Dashboard").Replace("~",string.Empty) %>'
                    id="BtnBack" class="btn btn-small btn-custom"><i class="icon-white icon-circle-arrow-left"
                        title="Back"></i>&nbsp;Back</a> 
               <a id="btnPrint" onclick="PrintReport();" class="btn btn-small btn-custom  AlignToRight">
                            <i class="icon-white icon-print" title="Print"></i>&nbsp;
                            <%=TrainingResourceManager.GetButtonText("Common_Button_Print") %>--%>
               </a>
               <br />
                <div style="clear: both">
                </div>
                <div class="PrintingArea" style="margin-bottom: 5px; overflow: hidden;">
                    <div style="float: left">
                        <asp:GridView runat="server" ID="gvEvents" GridLines="Both" Width="100%" OnRowDataBound="gvEvents_RowDataBound" />
                    </div>
                    <div style="width: 90%; margin-top: 5px; display: inline-block">
                        <asp:Repeater runat="server" ID="rptColors">
                            <ItemTemplate>
                                <div style="float: left; width: 100%; margin-bottom: 3px;">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style='<%# "border:1px solid #dcdcdc; width: 5%; background:"+Eval("Color")+";" %>'>
                                            </td>
                                            <td style="width: 95%">
                                                <%#Eval("Name") %>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlNoData" Visible="False">
                <table width="100%" cellspacing="0" cellpadding="0" border="0" class="gridpage">
                    <tbody>
                        <tr>
                            <%--<td class="nodatafound">
                                <asp:Label ID="lblNoDataFound" runat="server"><%=TrainingResourceManager.GetTableFooter("Footer_Common_NoDataFound") %></asp:Label>
                            </td>--%>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </fieldset>
    </ContentTemplate>
</asp:updatepanel>