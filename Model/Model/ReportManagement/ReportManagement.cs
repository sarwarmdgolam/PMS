using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Model
{
    [Serializable]
    public class ReportManagement
    {
        private String _ReportServerUrl;

        public String ReportServerUrl 
        {
            get { return _ReportServerUrl; }
            set { _ReportServerUrl = value; }
        }

        private String _ReportPath;

        public String ReportPath 
        {
            get { return _ReportPath; }
            set { _ReportPath = value; }
        }

        private String _Title;

        public String Title 
        {
            get { return _Title; }
            set { _Title = value; }
        }


        private ApplicationEnums.ReportPreviewType _PreviewType;

        public ApplicationEnums.ReportPreviewType PreviewType
        {
            get { return _PreviewType; }
            set { _PreviewType = value; }
        }

    }
}
