using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CResult
/// </summary>
/// 
namespace Common
{
    public class CResult
    {
        public CResult()
        {
            //
            // TODO: Add constructor logic here
            //
            _IsSuccess = false;
            _AffectedRows = 0;
            _Message = String.Empty;
            _Data = new DataTable();
            _Object = new object();
        }


        private bool _IsSuccess;

        public bool IsSuccess
        {
            get { return _IsSuccess; }
            set { _IsSuccess = value; }
        }

        private int _AffectedRows;

        public int AffectedRows
        {
            get { return _AffectedRows; }
            set { _AffectedRows = value; }
        }

        private String _Message;

        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        private DataTable _Data;

        public DataTable Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        private object _Object;

        public object Object
        {
            get { return _Object; }
            set { _Object = value; }
        }
    }
}