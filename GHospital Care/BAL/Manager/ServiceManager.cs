using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DevExpress.Data.WcfLinq.Helpers;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL.Manager
{
    public class ServiceManager : MessageModel
    {
        MessageModel messageModel = new MessageModel();

        public MessageModel DeleteService(Service service)
        {
            ServiceGateway aServiceGateway=new ServiceGateway();
            MessageModel aMessageModel = new MessageModel();
            if (aServiceGateway.DeleteService(service) > 0)
            {
                aMessageModel.MessageTitle = "Successfull";
                aMessageModel.MessageBody = "Service deleted successfully.";
            }
            return aMessageModel;
        }

        public MessageModel SavePatientOT_OtherService(Service aService, Patient pService)
        {
            //Service otService = new Service();

            //otService.PatientService = aService;
            int IsExist = new ServiceGateway().DeleteAllService("OTSERVICE", aService);
            int saveService = new ServiceGateway().SavePatientOtherService(aService);
            if (saveService > 0)
            {
                messageModel.MessageBody = "Patient Other Service save successfully!";
                messageModel.MessageTitle = "Successfull";

            }
            return messageModel;
        }

        public DataTable GetPatientServiceByPatient(string Optid, DateTime IssueDate)
        {
            try
            {
                DataTable dt = new ServiceGateway().SaveGetOtherServiceByCategory(Optid, IssueDate);
                return dt;
            }
            catch (Exception ex)
            {
               // new MailServer.MailServerConnection().SentMail(ex.GetBaseException().Message);
                return null;
            }

        }
        public MessageModel SaveService(Service service)
        {
            int saveService = new ServiceGateway().ServiceSave(service);
            if (saveService > 0)
            {
                messageModel.MessageBody = "Service save successfully.";
                messageModel.MessageTitle = "Successfull";
            }
            return messageModel;
        }

        public MessageModel SavePathology(PathologyMaster Pathology)
        {
            int saveService = new ServiceGateway().PathologySave(Pathology);
            if (saveService > 0)
            {
                messageModel.MessageBody = "save successfully.";
                messageModel.MessageTitle = "Successfull";
            }
            return messageModel;
        }


        public MessageModel UpdatePathology(DAL.Model.PathologyMaster Pathology)
        {
            int UpdatePathology = new ServiceGateway().PathologyUpdate(Pathology);
            if (UpdatePathology > 0)
            {
                messageModel.MessageBody = "Update successfully.";
                messageModel.MessageTitle = "Successfull";
            }
            return messageModel;}

        public MessageModel UpdateService(Service service)
        {
            int saveService = new ServiceGateway().ServiceUpdate(service);
            if (saveService > 0)
            {
                messageModel.MessageBody = "Service updated successfully.";
                messageModel.MessageTitle = "Successfull";
            }
            return messageModel;
        }

        public MessageModel SaveOtService(Service service)
        {
           int update = new ServiceGateway().UpdateOtService(service);
            int saveService = new ServiceGateway().SaveOtService(service);
            if (saveService > 0)
            {
                messageModel.MessageBody = "O.T Service save successfully!";
                messageModel.MessageTitle = "Successfull";

            }
            return messageModel;
        }
        public DataTable GetAllIpdPatientSl()
        {
            return new ServiceGateway().GetIpdAllSerialNo();
        }


        public DataTable GetPathology()
        {
            return new ServiceGateway().GetPathology();
        }


        public DataTable GeneratePatholgyId()
        {
            return new ServiceGateway().GetPathologyID();
        }

        public DataTable GetPatientServiceBill(string Opid, string status, string Service, DateTime IssueDate)
        {
            DataTable dt = new ServiceGateway().GetAllPatientserviceBill(Opid, status, Service, IssueDate.Date);
            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            return dt;

        }

        public DataTable GetPatientServicePathology(string Opid, string status, string Service, DateTime IssueDate)
        {
            DataTable dt = new ServiceGateway().GetAllPatientservicePathology(Opid, status, Service, IssueDate.Date);
            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            return dt;

        }
        public DataTable GetPatientServiceBillOnly_OT()
        {
            DataTable view = new ServiceGateway().GetPatientBillService().AsEnumerable().Where(a => a["Catgory"].ToString() == "OT").CopyToDataTable();
            return view;
        }

        public DataTable GetConsultServiceBill(string Opid, string status, string Service, DateTime IssueDate)
        {
            DataTable dt = new ServiceGateway().GetAllConsultserviceBill(Opid, status, Service, IssueDate.Date);
            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            return dt;
        }

        public DataTable GetPatientServiceBillWithoutOT()
        {
            return new ServiceGateway().GetPatientServiceBillWithoutOT();
        }
        public DataTable GetPatientService(string Category)
        {
            return new ServiceGateway().GetPatientService(Category);
        }

        public DataTable GetPathologyMaster()
        {
            return new ServiceGateway().GetPathologyMaster();
        }

        public string GenerateSlNo()
        {
            long slNo = new ServiceGateway().GenerateSlNo();

            string GenerateSl = "OT-0" + slNo;

            return GenerateSl;
        }

        public MessageModel SavePatientService(Service aService)
        {
            int IsExist = new ServiceManager().UpdateService("PatientService", aService);

            int saveService = new ServiceGateway().SavePatientService(aService);
            if (saveService > 0)
            {
                messageModel.MessageBody = "Patient Service save successfully!";
                messageModel.MessageTitle = "Successfull";

            }
            return messageModel;
        }
        public MessageModel SavePathologyService(Service aService)
        {
            int IsExist = new ServiceManager().UpdateService("Pathology", aService);

            int saveService = new ServiceGateway().SavePathologyService(aService);
            if (saveService > 0)
            {
                messageModel.MessageBody = "Pathology Service save successfully!";
                messageModel.MessageTitle = "Successfull";

            }
            return messageModel;
        }
        List<ConsultBillService> ConsutlService = new List<ConsultBillService>();
        public List<ConsultBillService> GetConsultBillServicesByPatientId(string opid, string status, string service, DateTime IssueDate)
        {
            try
            {
                DataTable list = new ServiceGateway().GetAllConsultserviceBill(opid, status, service, IssueDate);
                foreach (DataRow dataRow in list.Rows)
                {
                    ConsutlService.Add(new ConsultBillService { ConsultId = dataRow["ConsultId"].ToString(), ConFee = Convert.ToDouble(dataRow["ConFee"]), TotalConsFee = Convert.ToDouble(dataRow["TotalConsFee"]), ConQty = Convert.ToInt16(dataRow["ConQty"]), VchNo = Convert.ToInt64(dataRow["VchNo"]), Specialization = Convert.ToString(dataRow["Specialization"]), Degree = Convert.ToString(dataRow["Degree"]), ConsultBillDate = dataRow["ConsultBillDate"].ToString(), OPID = dataRow["OPID"].ToString() });

                }
                ConsutlService.Add(new ConsultBillService());
                return ConsutlService;
            }
            catch (Exception)
            {
                return null;
            }

        }
        List<PatientService> PatientService = new List<PatientService>();
        public List<PatientService> GetPatientServiceByPatientId(string opid, string status, string service, DateTime IssueDate)
        {
            PatientService.Clear();

            try
            {
                DataTable list = new ServiceGateway().GetAllPatientserviceBill(opid, status, service, IssueDate);
                foreach (DataRow dataRow in list.Rows)
                {
                    PatientService.Add(new PatientService { ServiceId = dataRow["ServiceId"].ToString(), Rate = Convert.ToDouble(dataRow["PsRate"]), Qty = Convert.ToInt16(dataRow["PSQty"]), VoucherNo = Convert.ToInt64(dataRow["VchNo"]), IssueDate = Convert.ToDateTime(dataRow["serviceDate"]), OPID = dataRow["OPID"].ToString(), Total = Convert.ToDouble(dataRow["PsSubTotal"]) });

                }
                PatientService.Add(new PatientService());
                return PatientService;
            }
            catch (Exception)
            {
                return null;
            }

        }

        List<PatientService> PathologyService = new List<PatientService>();
        public List<PatientService> GetPathologyServiceByPatientId(string opid, string status, string service, DateTime IssueDate)
        {
            PathologyService.Clear();
            try
            {
                DataTable list = new ServiceGateway().GetAllPatientservicePathology(opid, status, service, IssueDate);
                foreach (DataRow dataRow in list.Rows)
                {
                    PathologyService.Add(new PatientService { ServiceId = dataRow["ServiceId"].ToString(), Rate = Convert.ToDouble(dataRow["PsRate"]), Qty = Convert.ToInt16(dataRow["PSQty"]), VoucherNo = Convert.ToInt64(dataRow["VchNo"]), IssueDate = Convert.ToDateTime(dataRow["serviceDate"]), OPID = dataRow["OPID"].ToString(), Total = Convert.ToDouble(dataRow["PsSubTotal"]), Pathology = dataRow["Alias"].ToString(), PathId = dataRow["PathID"].ToString() });

                }
                PathologyService.Add(new PatientService());
                return PathologyService;
            }
            catch (Exception)
            {
                return null;
            }

        }

        List<IssueMedine> OPMedicnineList = new List<IssueMedine>();
        public List<IssueMedine> GetOPMedicineListByPatientId(Service paitentId)
        {
            try
            {
                DataTable list = new OpdGateway().GetOPMedicineConsumListByPatientId(paitentId);
                foreach (DataRow dataRow in list.Rows)
                {
                    OPMedicnineList.Add(new IssueMedine { batchId = dataRow["batchId"].ToString(), ProductId = dataRow["ProductId"].ToString(), ProductName = dataRow["ProductName"].ToString(), Qty = Convert.ToInt16(dataRow["Qty"]), Rate = Convert.ToDecimal(dataRow["Rate"]), date = Convert.ToDateTime(dataRow["date"]), VoucherNo = Convert.ToInt64(dataRow["VoucherNo"]), BatchName = Convert.ToString(dataRow["batchName"]), expd = Convert.ToString(dataRow["expd"]), ServiceTotal = Convert.ToString(dataRow["TotalAmount"]) });
                }
                OPMedicnineList.Add(new IssueMedine());

                return OPMedicnineList;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public int UpdateService(string serviceType, Service aService)
        {
            int updateService = new ServiceGateway().DeleteAllService(serviceType, aService);
            return updateService;
        }
        public DataTable GetAllRetriveServiceEditValue(string Opid, DataTable TempdataTable, string status)
        {
            DataTable fetchData = new ServiceGateway().GetAllRetriveServiceEditValue(Opid, status);
            if (fetchData.Rows.Count > 0)
            {
               
                for (int i = 0; i < fetchData.Rows.Count; i++)
                {

                    DataRow row = TempdataTable.NewRow();
                    if (fetchData.Rows[i]["ConsultId"].ToString()==string.Empty)
                    {
                        break;
                    }
                    row["DocID"] = fetchData.Rows[i]["ConsultId"];
                    row["DocName"] = fetchData.Rows[i]["DoctorName"];
                    row["Degree"] = fetchData.Rows[i]["DocDegree"];
                    row["ConDate"] = fetchData.Rows[i]["ConsultBillDate"];
                    row["ConQty"] = fetchData.Rows[i]["ConQty"];
                    row["ConFee"] = fetchData.Rows[i]["ConFee"];
                    row["TotalConsFee"] = Convert.ToInt16(fetchData.Rows[i]["ConQty"]) * Convert.ToDecimal(fetchData.Rows[i]["ConFee"]);
                    int contains = TempdataTable.AsEnumerable().Count(a => a["DocID"].ToString() == fetchData.Rows[i]["ConsultId"].ToString());
                    if (contains == 0)
                    {
                        TempdataTable.Rows.Add(row);
                    }
                    
                }
             } 
            TempdataTable.Rows.Add();
            return TempdataTable;
        }
        public DataTable GetAllRetrivePatientServiceEditValue(string Opid, DataTable TempdataTable, string status)
        {
            try
            {
                DataTable fetchData = new ServiceGateway().GetAllRetriveServiceEditValue(Opid, status);
                if (fetchData.Rows.Count > 0)
                {

                    for (int i = 0; i < fetchData.Rows.Count; i++)
                    {

                        DataRow row = TempdataTable.NewRow();
                        row["ServiceName"] = fetchData.Rows[i]["ServiceName"];
                        row["Description"] = fetchData.Rows[i]["Description"];
                        row["Rate"] = fetchData.Rows[i]["PsRate"];
                        row["Qty"] = fetchData.Rows[i]["PSQty"];
                        row["ServiceTotal"] = Convert.ToInt16(fetchData.Rows[i]["PSQty"]) * Convert.ToDecimal(fetchData.Rows[i]["PsRate"]);
                        row["ID"] = fetchData.Rows[i]["ServiceId"];

                        int contains = TempdataTable.AsEnumerable().Count(a => a["ID"].ToString() == fetchData.Rows[i]["ServiceId"].ToString());
                        if (contains == 0)
                        {
                            TempdataTable.Rows.Add(row);
                        }



                    }



                }
                TempdataTable.Rows.Add();}
            catch (Exception)
            {
                
                
            }
        
            return TempdataTable;
        }
    }
}
