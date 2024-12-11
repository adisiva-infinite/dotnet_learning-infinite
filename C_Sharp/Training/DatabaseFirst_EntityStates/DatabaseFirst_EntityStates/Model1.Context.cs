﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirst_EntityStates
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InfiniteDBEntities : DbContext
    {
        public InfiniteDBEntities()
            : base("name=InfiniteDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
    
        [DbFunction("InfiniteDBEntities", "fn_GetEmpByGender")]
        public virtual IQueryable<fn_GetEmpByGender_Result> fn_GetEmpByGender(string gen)
        {
            var genParameter = gen != null ?
                new ObjectParameter("gen", gen) :
                new ObjectParameter("gen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_GetEmpByGender_Result>("[InfiniteDBEntities].[fn_GetEmpByGender](@gen)", genParameter);
        }
    
        public virtual int sp_getsalary(string ename, ObjectParameter salary)
        {
            var enameParameter = ename != null ?
                new ObjectParameter("ename", ename) :
                new ObjectParameter("ename", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_getsalary", enameParameter, salary);
        }
    }
}