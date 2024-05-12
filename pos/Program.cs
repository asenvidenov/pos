using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using GuerrillaNtp;
using System.Net;
using FP3530;

namespace pos
{
    public static class FP
    {
        static int _PortSpeed;
        static CFD_BGR _PosPrinter;

        public static string FiscalMemoryNumber
        {
            get
            {
                return "XXXXXX";
            }
        }
        public static int PortSpeed
        {
            get
            {
                return _PortSpeed;
            }
            set
            {
                _PortSpeed = value;
            }

        }

        public static CFD_BGR PosPrinter
        {
            get
            {
                return _PosPrinter;
            }
            set
            {
                _PosPrinter = value;
            }
        }
        public static int Execute_070_info_Get_CashIn_CashOut(  //
        CFD_BGR myFP,                          //
        ref string ErrorCode,                  //
        ref string CashSum,                    //
        ref string ServIn,                     //
        ref string ServOut                     //
    )                                          //
            {
                const string cmd = "070_info_Get_CashIn_CashOut";
                int result = -1;
                ErrorCode = "";
                if (myFP == null) return result;
                try
                {
                    if (!myFP.connected_ToDevice) return result;
                    if ((result = myFP.execute_Command_ByName(cmd)) != 0) return result;
                    if ((result = myFP.get_OutputParam_ByName(cmd, "ErrorCode", ref ErrorCode)) != 0) return result;
                    if ((result = myFP.get_OutputParam_ByName(cmd, "CashSum", ref CashSum)) != 0) return result;
                    if ((result = myFP.get_OutputParam_ByName(cmd, "ServIn", ref ServIn)) != 0) return result;
                    if ((result = myFP.get_OutputParam_ByName(cmd, "ServOut", ref ServOut)) != 0) return result;

                }
                catch
                {
                return result;
                }
                return myFP.lastError_Code;
            }

            public static int Execute_070_receipt_CashIn_CashOut(  //
               CFD_BGR myFP,                         //
               string Amount,                        //
               ref string ErrorCode
            )                                         //
            {
                const string cmd = "070_receipt_CashIn_CashOut";
                int result = -1;
                ErrorCode = "";
                if (myFP == null) return result;
                try
                {
               
                        if (!myFP.connected_ToDevice) return result;
                        if (myFP.set_InputParam_ByName(cmd, "Amount", Amount) != 0) return result;
                        if (myFP.execute_Command_ByName(cmd) != 0) return result;
                }
                catch
                {
                return result;
                }
                finally
                {
                    result = myFP.lastError_Code;
                    myFP.get_OutputParam_ByName(cmd, "ErrorCode", ErrorCode);
                }
                return result;
            }

        public static int Execute_060_receipt_Fiscal_Cancel(CFD_BGR myFP)
        {
            const string cmd = "060_receipt_Fiscal_Cancel";
            int result = -1;
            if (myFP == null) return result;
            try
            {
                if (!myFP.connected_ToDevice) return result;
                result = myFP.execute_Command_ByName(cmd);
                if (result != 0) return result;
            }
            catch
            {
                result = -1;
            }
            return result;
        }
    }
    public static class Globals
    {
        public const string PosCnnString = "Server=.; Database = pos; User Id = pos; Password = posUser;";
        static Int64 _OrderID;
        static Single _OrderSum;
        static int _OpID;
        static string _OpName;
        static string _OpCode;
        static int _CurrGoodsID;
        static int _CurrTblID;
        static int _ObjID;
        static SqlConnection _cnn;
        static string _NtpServer;
        static string _FlightNum = "";

        public static Single OrderSum
            {
                get
            {
                return _OrderSum;
            }
            set
            {
                _OrderSum = value;
            }
            }

        public static string OpCode
        {
            get
            {
                return _OpCode;
            }
            set
            {
                _OpCode = value;
            }
        }
        public static string OpName
        {
            get
            {
                return _OpName;
            }
            set
            {
                _OpName = value;
            }
        }
        public static string FlightNum
        {
            get
            {
                return _FlightNum;
            }
            set
            {
                _FlightNum = value;
            }
        }
        public static SqlConnection PosCnn
        {
            get
            {
                _cnn = new SqlConnection();
                _cnn.ConnectionString = PosCnnString;
                try
                {
                    if (_cnn.State == System.Data.ConnectionState.Closed)
                    {
                        _cnn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (_cnn.State == System.Data.ConnectionState.Open)
                {
                    return _cnn;
                }
                else
                {
                    return null;
                }
            }
        }



        public static Int64 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
            }
        }

        public static int OpID
        {
            get
            {
                return _OpID;
            }
            set
            {
                _OpID = value;
            }
        }

        public static int CurrGoodsID
        {
            get
            {
                return _CurrGoodsID;
            }
            set
            {
                _CurrGoodsID = value;
            }
        }

        public static int CurrTblID
        {
            get
            {
                return _CurrTblID;
            }
            set
            {
                _CurrTblID = value;
            }
        }

        public static int ObjID
        {
            get
            {
                return _ObjID;
            }
            set
            {
                _ObjID = value;
            }

        }


        public static string NtpServer
        {
            get
            {
                return _NtpServer;
            }
            set
            {
                _NtpServer = value;
            }
        }
        public static DateTime AccTime
        {
            get
            {
                TimeSpan offset;
                try
                {
                    using (var ntp = new NtpClient(Dns.GetHostAddresses(NtpServer)[0]))
                        offset = ntp.GetCorrectionOffset();
                }
                catch
                {
                    // timeout or bad SNTP reply
                    offset = TimeSpan.Zero;
                }

                // use the offset throughout your app
                DateTime accurateTime = DateTime.UtcNow + offset;
                return accurateTime;
            }
        }

}


class posProgram : ApplicationContext
    {

        private posProgram()
        {
            new CashLogin().Show();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            posProgram poscontext = new posProgram();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(poscontext);
        }
        
    }
}
