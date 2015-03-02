using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecDAL;
using UserSecBE;
using System.Data;

namespace UserSecBAL
{
    public class CompanyBAL
    {

        CommonDAL commonDAL = new CommonDAL();
        public bool ModifyCompanyRecords(CompanyBE company)
        {
            CompanyDAL companyDAL = new CompanyDAL();
            if (companyDAL.ModifyCompanyRecords(company))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetDetailsbyId(CompanyBE company, ref DataTable dt)
        {
            CompanyDAL companyDAL = new CompanyDAL();
            if (companyDAL.GetDetailsbyId(company, ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddCompany(CompanyBE company)
        {
            CompanyDAL companyDAL = new CompanyDAL();
            if (companyDAL.AddCompany(company))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetAllCompanyId(ref DataTable dt)
        {
            CompanyDAL companyDAL = new CompanyDAL();
            if (companyDAL.GetAllCompanyId(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetAllCompanyDetails(ref DataTable dt)
        {
            CompanyDAL companyDAL = new CompanyDAL();
            if (companyDAL.GetAllCompanyDetails(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActivateCompany(CompanyBE company)
        {
            CompanyDAL companyDAL = new CompanyDAL();
            if (companyDAL.ActivateCompany(company))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeActivateCompany(CompanyBE company)
        {
            CompanyDAL companyDAL = new CompanyDAL();
            if (companyDAL.DeActivateCompany(company))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCompany(CompanyBE company)
        {
            CompanyDAL companyDAL = new CompanyDAL();
            if (companyDAL.DeleteCompany(company))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
