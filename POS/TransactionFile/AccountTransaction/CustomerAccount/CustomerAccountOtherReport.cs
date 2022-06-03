﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using POS.TransactionFile.AccountTransaction.CustomerAccount;
using System;
using System.Data;
using System.Drawing.Printing;

namespace POS.Item
{
    class CustomerAccountOtherReport
    {
        private string FilePath = @"C:\users\" + Environment.UserName.ToString() + @"\documents\CustomerAccount.doc";
        private string FilePathEmail = @"C:\users\" + Environment.UserName.ToString() + @"\documents\CustomerAccount.pdf";
        private string FilePathExcel = @"C:\users\" + Environment.UserName.ToString() + @"\documents\CustomerAccount.xls";
        DataSet1 ds;
        public CustomerAccountOtherReport(string p,DataSet s)
        {
            ds = (DataSet1)s;
            ReportClass rp;
            if(POS.Properties.Settings.Default.Language==1)
                rp = new CustomerAccountOrderReportsPashtu();
            else
                rp = new CustomerAccountOrderReports();

            rp.SetDataSource(ds.Tables["tbl_Account"]);
            rp.SetParameterValue("@Header", POS.Properties.Settings.Default.TopTitle);
            rp.SetParameterValue("@OwnerPhone", POS.Properties.Settings.Default.Phone);
            rp.SetParameterValue("@OwnerAddress", POS.Properties.Settings.Default.Address);
            rp.SetParameterValue("@user", POS.Properties.Settings.Default.username);
            rp.SetParameterValue("@Email", POS.Properties.Settings.Default.Email);



            try
            {

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();

                switch (p)
                {

                    case "Print":
                        //rp.PrintOptions.PrinterName = "printername";

                        PrinterSettings getprinterName = new PrinterSettings();
                        rp.PrintOptions.PrinterName = getprinterName.PrinterName;
                        rp.PrintToPrinter(1, true, 1, 1);

                        break;
                    case "Word":




                        CrDiskFileDestinationOptions.DiskFileName = FilePath;
                        CrExportOptions = rp.ExportOptions;
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.WordForWindows;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                        rp.Export();
                        System.Diagnostics.Process.Start(FilePath);

                        break;







                    case "Excel":
                        //For Execel
                        ExcelFormatOptions excel = new ExcelFormatOptions();
                        CrDiskFileDestinationOptions.DiskFileName = FilePathExcel;
                        CrExportOptions = rp.ExportOptions;
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.Excel;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = excel;
                        rp.Export();
                        System.Diagnostics.Process.Start(FilePathExcel);
                        break;
                }
                rp.Close();
            }
            catch (Exception)
            {

                
            }
        }
    }
}
