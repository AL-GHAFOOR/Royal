using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    class NICUBillManager
    {
        NICUBillGateway aBillGateway = new NICUBillGateway();

        public DataTable GetAllNICUPatienSlNo()
        {
            return aBillGateway.GetNICUAllSerialNo();
        }


        public DataTable GetNICUServiceBill(string Opid, string status, string Service, DateTime IssueDate)
        {
            DataTable dt = new NICUBillGateway().GetAllNICUserviceBill(Opid, status, Service, IssueDate.Date);
            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            return dt;

        }

        public NicuAddmission GetNICUPatientInfo(string pid)
        {
          DataTable ListofNICUPatient = new NICUBillGateway().GetNICUPatientByID(pid);
           NicuAddmission setup=new NicuAddmission();
            if (ListofNICUPatient.Rows.Count > 0)
            {
                setup.RegNo = ListofNICUPatient.Rows[0]["RegNo"].ToString();
                setup.Age = ListofNICUPatient.Rows[0]["Age"].ToString();
                setup.FatherName = ListofNICUPatient.Rows[0]["FatherName"].ToString();
                setup.MotherName = ListofNICUPatient.Rows[0]["MotherName"].ToString();
                setup.AdmitDate = Convert.ToDateTime(ListofNICUPatient.Rows[0]["AdmitDate"].ToString());
                setup.Address = ListofNICUPatient.Rows[0]["Address"].ToString();
                setup.Bed = ListofNICUPatient.Rows[0]["BedName"].ToString();
                setup.BabysBloodGroup = ListofNICUPatient.Rows[0]["BabysBloodGroup"].ToString();
                setup.ContactNo = ListofNICUPatient.Rows[0]["ContactNo"].ToString();
                setup.Sex = ListofNICUPatient.Rows[0]["Sex"].ToString();
               
            }
            return setup;
        }

        public DataTable getNICUBillID()
        {
            return new NICUBillGateway().NICUBillID();
        }

        public DataTable DischargeRequestNICU()
        {
            return new NICUBillGateway().DischargeRequestNICU();
        }


        public DischargeBillNICU GetDischargeBillNICU(DischargeBillNICU aNicuDischargeBill)
        {
            DataTable dt = new NICUBillGateway().GetDischargeBillNICUByPatient(aNicuDischargeBill.OPID);
            aNicuDischargeBill.OPID = dt.Rows[0]["OPID"].ToString();
            aNicuDischargeBill.PatientName = dt.Rows[0]["MotherName"].ToString();
            aNicuDischargeBill.DiscTime = dt.Rows[0]["DischargeTime"].ToString();
            aNicuDischargeBill.NoOfDay = dt.Rows[0]["NoOfDay"].ToString();
            //aNicuDischargeBill.DeisDate = Convert.ToDateTime(dt.Rows[0]["DischargeOn"]).Date;
            aNicuDischargeBill.RegNo = dt.Rows[0]["RegNo"].ToString();
            aNicuDischargeBill.PatientBill = dt;
            //aNicuDischargeBill.OTMedicine = Convert.ToDouble(dt.Rows[0]["OT_Med_Total"]);
            //aNicuDischargeBill.HospitalCharge = Convert.ToDouble(dt.Rows[0]["Hsptl_Total"]);
            //aNicuDischargeBill.OTservice = Convert.ToDouble(dt.Rows[0]["OT_Total"]);
            //aNicuDischargeBill.PharmacyBill = Convert.ToDouble(dt.Rows[0]["Phar_Total"]);
            //aNicuDischargeBill.Age = dt.Rows[0]["Age"].ToString();
            //aNicuDischargeBill.BloodGroup = dt.Rows[0]["BloodGroup"].ToString();
            ////  opidDischargeBill.OT_TOtalBill = dt.Rows[0]["OT_TOtalBill"].ToString();
            //aNicuDischargeBill.PBill = Convert.ToDouble(dt.Rows[0]["Path_Total"].ToString());
            //aNicuDischargeBill.NoOfDay = dt.Rows[0]["NoOfDay"].ToString();
            //aNicuDischargeBill.TotalBedCharge = dt.Rows[0]["cabin_Total"].ToString();
            //aNicuDischargeBill.TConsultBill = dt.Rows[0]["Con_Total"].ToString();
            //aNicuDischargeBill.TotalBill = Convert.ToDouble(dt.Rows[0]["TotalBill"]);
            //aNicuDischargeBill.AdvancedPayble = Convert.ToDouble(dt.Rows[0]["Advance"]);
            return aNicuDischargeBill;
        }

        public MessageModel SaveDischargeBill(DischargeBillNICU aDischargeBill, List<DischargeBillNICU> aDischargeBillNicus )
        {
            MessageModel message = new MessageModel();
            int count = new NICUBillGateway().SaveDischargeBill(aDischargeBill);
            if (count>0)
            {
                count = new NICUBillGateway().SaveParticular(aDischargeBillNicus);
            }
            if (count > 0)
            {
                message.MessageBody = "Save Discharge Bill Successfully";
                message.MessageTitle = "NICU Discharge";
            }
            return message;

        }

        public static DischargeBillNICU VateCalcule(DischargeBillNICU dischargeBill)
        {
            try
            {
                double totalBill = dischargeBill.TotalBill;
                double serviceCharge = (totalBill * dischargeBill.servicePercent) / 100;
                double taxAmount = ((totalBill + serviceCharge) * dischargeBill.Tax) / 100;

                dischargeBill.ServiceCharge = serviceCharge;
                dischargeBill.Tax = taxAmount;
                dischargeBill.SubTotal = taxAmount + dischargeBill.TotalBill + serviceCharge;
                dischargeBill.discount = dischargeBill.discount;
                double afterDiscount = Convert.ToDouble(dischargeBill.SubTotal - dischargeBill.discount - dischargeBill.AdvancedPayble);
                dischargeBill.NetPayble = afterDiscount;
                // dischargeBill.TotalBill = totalBill;
                return dischargeBill;
            }
            catch (Exception)
            {

            }
            return dischargeBill;
        }
        public DataTable PrintDischare(string PatientID)
        {
            return new NICUBillGateway().PrintDischarge(PatientID);
        }

        public DataTable BedHistory(string PatientID)
        {
            return new NICUBillGateway().BedHistory(PatientID);
        }

        public DataTable AdvanceInfo(string PatientID)
        {
            return new NICUBillGateway().AdvanceInfo(PatientID);
        }
        public DataTable ViewDicharge(DateTime fromDate, DateTime toDate)
        {
            return new NICUBillGateway().ViewDicharge(fromDate, toDate);
        }
    }
   }
