using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;

namespace Common
{
   [Serializable]
    public class FileParser
    {
        String wholeDoc;
        DataTable dtClosingPrice;
        /// <summary>
        /// constructor
        /// </summary>
        public FileParser() 
        {
        }

        /// <summary>
        /// split each line into array of string then populate each line into array list and returned
        /// </summary>
        /// <param name="fullPath">full path of the file</param>
        /// <param name="splitBy">split character like(~,|) for each line</param>
        /// <returns></returns>
        public ArrayList PopulateListFromFile(string fullPath,char splitBy)
        {
            //string FileLocation = HostingEnvironment.MapPath(System.Configuration.ConfigurationManager.AppSettings["TempLocation"]) + "\\";
            string[] fields={};
            ArrayList list = new ArrayList();

            try
            {
                StreamReader reader = new StreamReader(fullPath);

                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    fields = line.Split(splitBy);
                    //not considering the first line(invalid data)
                    if(fields.Length==1)
                    {
                        continue;
                    }
                    list.Add(fields);
                }

                return list;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

        public DataTable PopulateClosingPriceFile(string fullPath)
        {
            //string FileLocation = HostingEnvironment.MapPath(System.Configuration.ConfigurationManager.AppSettings["TempLocation"]) + "\\";
            string[] fields={};
            ArrayList list = new ArrayList();

            dtClosingPrice = new DataTable(); 
            dtClosingPrice.Columns.Add("Group", typeof(string));
            dtClosingPrice.Columns.Add("Instrument", typeof(string));
            dtClosingPrice.Columns.Add("Open", typeof(double));
            dtClosingPrice.Columns.Add("High", typeof(double));
            dtClosingPrice.Columns.Add("Low", typeof(double));
            dtClosingPrice.Columns.Add("Close", typeof(double));
            dtClosingPrice.Columns.Add("Change", typeof(double));
            dtClosingPrice.Columns.Add("Trade", typeof(double));
            dtClosingPrice.Columns.Add("Volume", typeof(double));
            dtClosingPrice.Columns.Add("Value", typeof(double));

            try
            {
                StreamReader reader = new StreamReader(fullPath);
                
                String strResponse = reader.ReadToEnd();
                String str = strResponse.Substring(102, strResponse.Length - 102);

                String delt = str.Replace("\n", " ");
                String deln = delt.Replace("\t", " ");
                deln = delt.Replace("\r", " ");
                wholeDoc = deln;

                String ACat = GetGroupValues("A Group (Equity)");
                PopulateDataTable(ACat, "A");
                //InsertUpdateData(ACat);
                ACat = GetGroupValues("B Group (Equity)");
                PopulateDataTable(ACat, "B");
                //InsertUpdateData(ACat);
                ACat = GetGroupValues("G Group (Equity)");
                PopulateDataTable(ACat, "G");
                //InsertUpdateData(ACat);
                ACat = GetGroupValues("N Group (Equity)");
                PopulateDataTable(ACat, "N");
                //InsertUpdateData(ACat);
                ACat = GetGroupValues("Z Group (Equity)");
                PopulateDataTable(ACat, "Z");
                //InsertUpdateData(ACat);
                ACat = GetGroupValues("MUTUAL FUNDs");
                PopulateDataTable(ACat,"MUTUAL FUND");
                //InsertUpdateData(ACat);
                ACat = GetGroupValues("CORPORATE BONDs");
                PopulateDataTable(ACat, "BOND");
                //InsertUpdateData(ACat);
                ACat = GetGroupValuesForSpot("PRICES IN SPOT TRANSACTIONS");
                PopulateDataTable(ACat, "SPOT");
                //InsertUpdateData(ACat);
                ACat = GetGroupValuesForSpot("PRICES IN SPOT TRANSACTIONS (Treasury BONDs)");
                PopulateDataTable(ACat, "BOND IN SPOT");
                //InsertUpdateData(ACat);
                
                return dtClosingPrice;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

        private String GetGroupValues(String GrpName)
        {
            char quat = '"';
            string strCheckGroupItems="";
            Int32 strCount=0;
            if(GrpName == "MUTUAL FUNDs")
            {
                strCheckGroupItems = quat + GrpName + quat + " traded in Public Market =";
            }
            else if(GrpName == "CORPORATE BONDs")
            {
                strCheckGroupItems = quat + GrpName + quat + " traded in Public Market =";
            }
            else if(GrpName == "PRICES IN SPOT TRANSACTIONS")
            {
                strCheckGroupItems = "Total number of scrips traded in Spot Market =";
            }
            else
            {
                strCheckGroupItems = quat + GrpName + quat + " Scrips traded in Public Market =";
            }
             
            Int32 indexGroupItems = wholeDoc.IndexOf(strCheckGroupItems);
            
            if(GrpName == "MUTUAL FUNDs")
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 42, 3));
            }
            else if(GrpName == "CORPORATE BONDs")
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 45, 3));
            }
            else if(GrpName == "PRICES IN SPOT TRANSACTIONS")
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 47, 3));
            }
            else
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 53, 3));
            }
            if (strCount == 0)
            {
                return "";
            }
            String str = "";
            Int32 stindex = wholeDoc.IndexOf(GrpName);
            str = wholeDoc.Substring(stindex + 32, wholeDoc.Length - stindex - 32);
            stindex = str.IndexOf("Value(Mn)");
            str = str.Substring(stindex + 10, str.Length - stindex - 10);
            stindex = str.IndexOf("------");
            str = str.Substring(0, stindex);
            str = str.Replace("      ", " ");
            str = str.Replace("    ", " ");
            str = str.Replace("   ", " ");
            str = str.Replace("  ", " ");
            return str;
        }

        private String GetGroupValuesForSpot(String GrpName)
        {
            char quat = '"';
            string strCheckGroupItems="";
            Int32 strCount=0;
            if(GrpName == "MUTUAL FUNDs")
            {
                strCheckGroupItems = quat + GrpName + quat + " traded in Public Market =";
            }
            else if(GrpName == "CORPORATE BONDs")
            {
                strCheckGroupItems = quat + GrpName + quat + " traded in Public Market =";
            }
            else if(GrpName == "PRICES IN SPOT TRANSACTIONS")
            {
                strCheckGroupItems = "Total number of scrips traded in Spot Market =";
            }
            else if(GrpName == "PRICES IN SPOT TRANSACTIONS (Treasury BONDs)")
            {
                strCheckGroupItems = "Total number of BONDs traded in Spot Market =";
            }
            else
            {
                strCheckGroupItems = quat + GrpName + quat + " Scrips traded in Public Market =";
            }
             
            Int32 indexGroupItems = wholeDoc.IndexOf(strCheckGroupItems);
            
            if(GrpName == "MUTUAL FUNDs")
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 42, 3));
            }
            else if(GrpName == "CORPORATE BONDs")
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 45, 3));
            }
            else if(GrpName == "PRICES IN SPOT TRANSACTIONS")
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 47, 3));
            }
            else if(GrpName == "PRICES IN SPOT TRANSACTIONS (Treasury BONDs)")
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 46, 3));
            }
            else
            {
                strCount = Convert.ToInt32(wholeDoc.Substring(indexGroupItems + 53, 3));
            }
            if (strCount == 0)
            {
                return "";
            }
            String str = "";
            Int32 stindex = wholeDoc.IndexOf(GrpName);
            str = wholeDoc.Substring(stindex + 108, wholeDoc.Length - stindex - 108);
            stindex = str.IndexOf("Value(Mn)");
            str = str.Substring(stindex + 10, str.Length - stindex - 10);
            stindex = str.IndexOf("------");
            str = str.Substring(0, stindex);
            str = str.Replace("      ", " ");
            str = str.Replace("    ", " ");
            str = str.Replace("   ", " ");
            str = str.Replace("  ", " ");
            return str;
        }

        public DataTable GetDatatableFromArrayList(ArrayList oList)
        {
            DataTable oDataTable = new DataTable();
            String[] oFirstRow = (String[])oList[0];
            
            //Create column
            for (int i=0;i<oFirstRow.Length;i++)
            {
                oDataTable.Columns.Add("col"+i.ToString(),typeof(String));
            }
            
            //create datatable
            foreach (String[] oRow in oList)
            {
                DataRow dtRow = oDataTable.NewRow();
                for (int i = 0; i < oRow.Length; i++)
                {
                    dtRow[i]=oRow[i].ToString();
                }
                oDataTable.Rows.Add(dtRow);
            }
            return oDataTable;
        }

        private void PopulateDataTable(string modifiedStr, string groupName)
        {
            String tmpres = "";
            Int32 j = 0;
            Decimal Open = 0, High = 0, Low = 0, Close = 0, Change = 0, Trade = 0, Volume = 0, Value = 0;
            Int32 sl = 0;
            String trCode = "";

            String[] groupValue = modifiedStr.Split(' ');

            for (Int32 i = 0; i < groupValue.Length - 1; i++)
            {

                if (groupValue[i].Length > 0)
                {
                    tmpres = tmpres + groupValue[i] + " ";
                    j++;
                    if (j == 9)
                    {
                        String[] valstr = tmpres.Split(' ');
                        for (int k = 0; k < valstr.Length-1; k++)
                        {
                       
                            if (k == 0)
                                trCode = (valstr[k].ToString());
                            else if (k == 1)
                                Open = Convert.ToDecimal(valstr[k].ToString());
                            else if (k == 2)
                                High = Convert.ToDecimal(valstr[k]);
                            else if (k == 3)
                                Low = Convert.ToDecimal(valstr[k]);
                            else if (k == 4)
                                Close = Convert.ToDecimal(valstr[k]);
                            else if (k == 5)
                                Change = Convert.ToDecimal(valstr[k]);
                            else if (k == 6)
                                Trade = Convert.ToDecimal(valstr[k]);
                            else if (k == 7)
                                Volume = Convert.ToDecimal(valstr[k]);
                            else if (k == 8)
                                Value = Convert.ToDecimal(valstr[k]);
                        }
                        dtClosingPrice.Rows.Add(groupName,trCode,Open,High,Low,Close,Change,Trade,Volume,Value);
                        tmpres = "";
                        j = 0;
                    }
                }

            }
        }

    }
}


