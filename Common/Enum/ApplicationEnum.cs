using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ApplicationEnums
    {
        public enum EntityEnum
        {
            SecurityExchange,
            CompanyInformation,
            MarketType,
            TradeAccountType,
            SubAccount,
            ParentAccount,
            Trader,
            BankAccountType,
            BankBranch,
            Bank,
            Country,
            District,
            BrokerBranch,
            BOAccountStatus,
            TradeTransactionMode,
            InstrumentSectorType,
            InstrumentType,
            Category,
            SystemDate,
            AccountTransactionMode,
            NonTradingDayType,
            ActiveInvestorList,
            BOAccountOperationType,
            BOInvestorType,
            FeeChargeType,
            ChargeSettingsType,
            ChargeInformation,
            CustomerBusinessNature,
            CDBLUploadableFilesList,
            InstrumentSectorInfo,
            CorporateActionType,
            DatabaseNameList,
            WithdrawLimitBasisOn,
            EmployeeList
        };

        public enum VoucherType
        {
            TBL_CASH_CHQ_COLLECTION_VOUCHER_NO,
            TBL_CASH_CHQ_PAYMENT_VOUCHER_NO,
            TBL_INST_TRANSACTION_MASTER_VOUCHER_NO,
            TBL_ACCOUNTS_TRANSACTION_MASTER_VOUCHER_NO
        };

        public enum ReportPreviewType
        {
            VIEW,
            PDF,
            EXCEL, //EXCEL
            EXCELDATA, //EXCEL DATA
            DOC
        };

        public enum UIOperationMode
        {
            INSERT,
            UPDATE,
            REFRESH
        };

        public enum ApplicationMessageType
        {
            Informaiton,
            Warning,
            Error
        };

        public enum SessionVariablesType
        {
            CURRENT_USER_ID,
            CURRENT_USER_NAME,
            USER_FULL_NAME,
            REPORTPARAMETERLIST,
            REPORTMANAGEMENT,
            PARAMETERCONTROLSINFO
        }
    }
}
