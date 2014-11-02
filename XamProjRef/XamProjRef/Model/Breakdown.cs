using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Model.BreakdownCreate
{
    public class Location
    {
        public string Accuracy { get; set; }
        public string Altitude { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class MembershipDetails
    {
        public string MembershipNo { get; set; }
        public string MobileNumber { get; set; }
        public string Name { get; set; }
        public string VehicleReg { get; set; }
    }

    public class BreakdownCallInfo
    {
        public string Company { get; set; }
        public string Key { get; set; }
        public Location Location { get; set; }
        public MembershipDetails MembershipDetails { get; set; }
    }

    public class BreakdownCallCREATE
    {
        public BreakdownCallInfo BreakdownCallInfo { get; set; }
    }

    public class BreakDownRootObject
    {
        public BreakdownCallCREATE breakdownCall_CREATE { get; set; }
    }
}

namespace XamProjRef1.Model.BreakdownCreateResult
{

    public class BreakdownCallCREATE
    {
        public int result { get; set; }
    }

    public class BreakdownCallCreateResult
    {
        public BreakdownCallCREATE breakdownCall_CREATE { get; set; }

        public string BreakDownCallMessage
        {
            // can have the enum if required. 
            get
            {
                var msg = string.Empty;
                switch (breakdownCall_CREATE.result)
                {
                    case 0:
                        {
                            msg = "Success";
                            break;
                        }
                    case 1:
                        {
                            msg = "UnknownCompany";
                            break;
                        }
                    case 2:
                        {
                            msg = "Keyinvalid";
                            break;
                        }
                    case 3:
                        {
                            msg = "MobileNumberInvalid";
                            break;
                        }
                    case 4:
                        {
                            msg = "LocationRejected";
                            break;
                        }
                    case 5:
                        {
                            msg = "ServiceUnavailable";
                            break;
                        }

                    default:
                        break;
                }
                return msg;
            }
        }
    }


    public enum BreakdownStatus
    {
        Success,
        UnknownCompany,
        Keyinvalid,
        MobileNumberInvalid,
        LocationRejected,
        ServiceUnavailable
    }
}
